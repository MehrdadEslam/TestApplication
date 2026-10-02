using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace TestApplication
{
    internal sealed class PatientDatabase
    {
        private readonly string _databasePath;
        private readonly string _connectionString;

        public PatientDatabase()
        {
            string appData = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "TestApplication");

            Directory.CreateDirectory(appData);
            _databasePath = Path.Combine(appData, "PatientRecords.db");
            _connectionString = "Data Source=" + _databasePath + ";Version=3;Foreign Keys=True;";

            Initialize();
            MigrateLegacyRecords();
        }

        public string DatabasePath
        {
            get { return _databasePath; }
        }

        private SQLiteConnection OpenConnection()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }

        private void Initialize()
        {
            if (!File.Exists(_databasePath))
                SQLiteConnection.CreateFile(_databasePath);

            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "CREATE TABLE IF NOT EXISTS Patients (" +
                    "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "FirstName TEXT NOT NULL, " +
                    "LastName TEXT NOT NULL, " +
                    "FileNumber TEXT NOT NULL UNIQUE COLLATE NOCASE, " +
                    "Mobile TEXT NOT NULL, " +
                    "ImageData BLOB NULL, " +
                    "ImageFileName TEXT NULL, " +
                    "RegisteredAt TEXT NOT NULL, " +
                    "UpdatedAt TEXT NOT NULL" +
                    ");" +
                    "CREATE INDEX IF NOT EXISTS IX_Patients_Name ON Patients(LastName, FirstName);" +
                    "CREATE INDEX IF NOT EXISTS IX_Patients_Mobile ON Patients(Mobile);" +
                    "CREATE TABLE IF NOT EXISTS AppSettings (" +
                    "SettingKey TEXT PRIMARY KEY, SettingValue TEXT NULL" +
                    ");";
                command.ExecuteNonQuery();
            }
        }

        public List<PatientRecord> Search(string searchText)
        {
            var result = new List<PatientRecord>();
            string query = (searchText ?? string.Empty).Trim();

            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT Id, FirstName, LastName, FileNumber, Mobile, ImageData, ImageFileName, RegisteredAt, UpdatedAt " +
                    "FROM Patients " +
                    "WHERE @Query = '' " +
                    "OR FirstName LIKE @LikeQuery " +
                    "OR LastName LIKE @LikeQuery " +
                    "OR (FirstName || ' ' || LastName) LIKE @LikeQuery " +
                    "OR FileNumber LIKE @LikeQuery " +
                    "OR Mobile LIKE @LikeQuery " +
                    "ORDER BY Id DESC;";

                command.Parameters.AddWithValue("@Query", query);
                command.Parameters.AddWithValue("@LikeQuery", "%" + query + "%");

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        result.Add(ReadPatient(reader));
                }
            }

            return result;
        }

        public PatientRecord GetById(long id)
        {
            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT Id, FirstName, LastName, FileNumber, Mobile, ImageData, ImageFileName, RegisteredAt, UpdatedAt " +
                    "FROM Patients WHERE Id = @Id LIMIT 1;";
                command.Parameters.AddWithValue("@Id", id);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    return reader.Read() ? ReadPatient(reader) : null;
                }
            }
        }

        public bool FileNumberExists(string fileNumber, long excludeId)
        {
            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT COUNT(1) FROM Patients WHERE FileNumber = @FileNumber AND Id <> @ExcludeId;";
                command.Parameters.AddWithValue("@FileNumber", fileNumber.Trim());
                command.Parameters.AddWithValue("@ExcludeId", excludeId);
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        public long Save(PatientRecord patient)
        {
            string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteTransaction transaction = connection.BeginTransaction())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;

                if (patient.Id <= 0)
                {
                    command.CommandText =
                        "INSERT INTO Patients " +
                        "(FirstName, LastName, FileNumber, Mobile, ImageData, ImageFileName, RegisteredAt, UpdatedAt) " +
                        "VALUES (@FirstName, @LastName, @FileNumber, @Mobile, @ImageData, @ImageFileName, @RegisteredAt, @UpdatedAt); " +
                        "SELECT last_insert_rowid();";
                    command.Parameters.AddWithValue("@RegisteredAt", now);
                }
                else
                {
                    command.CommandText =
                        "UPDATE Patients SET " +
                        "FirstName=@FirstName, LastName=@LastName, FileNumber=@FileNumber, Mobile=@Mobile, " +
                        "ImageData=@ImageData, ImageFileName=@ImageFileName, UpdatedAt=@UpdatedAt " +
                        "WHERE Id=@Id; " +
                        "SELECT @Id;";
                    command.Parameters.AddWithValue("@Id", patient.Id);
                }

                command.Parameters.AddWithValue("@FirstName", patient.FirstName.Trim());
                command.Parameters.AddWithValue("@LastName", patient.LastName.Trim());
                command.Parameters.AddWithValue("@FileNumber", patient.FileNumber.Trim());
                command.Parameters.AddWithValue("@Mobile", patient.Mobile.Trim());
                command.Parameters.AddWithValue("@ImageFileName",
                    string.IsNullOrWhiteSpace(patient.ImageFileName) ? (object)DBNull.Value : patient.ImageFileName);
                command.Parameters.AddWithValue("@UpdatedAt", now);

                SQLiteParameter imageParameter = command.Parameters.Add("@ImageData", DbType.Binary);
                imageParameter.Value = patient.ImageData == null ? (object)DBNull.Value : patient.ImageData;

                long id = Convert.ToInt64(command.ExecuteScalar());
                transaction.Commit();
                return id;
            }
        }

        public void Delete(long id)
        {
            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Patients WHERE Id=@Id;";
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        private PatientRecord ReadPatient(SQLiteDataReader reader)
        {
            return new PatientRecord
            {
                Id = Convert.ToInt64(reader["Id"]),
                FirstName = Convert.ToString(reader["FirstName"]),
                LastName = Convert.ToString(reader["LastName"]),
                FileNumber = Convert.ToString(reader["FileNumber"]),
                Mobile = Convert.ToString(reader["Mobile"]),
                ImageData = reader["ImageData"] == DBNull.Value ? null : (byte[])reader["ImageData"],
                ImageFileName = reader["ImageFileName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ImageFileName"]),
                RegisteredAt = Convert.ToString(reader["RegisteredAt"]),
                UpdatedAt = Convert.ToString(reader["UpdatedAt"])
            };
        }

        private void MigrateLegacyRecords()
        {
            if (GetSetting("LegacyRecordsMigrated") == "1")
                return;

            string legacyRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PatientRecords");

            if (!Directory.Exists(legacyRoot))
            {
                SetSetting("LegacyRecordsMigrated", "1");
                return;
            }

            foreach (string folder in Directory.GetDirectories(legacyRoot))
            {
                try
                {
                    string infoPath = Path.Combine(folder, "PatientInfo.txt");
                    if (!File.Exists(infoPath))
                        continue;

                    string[] lines = File.ReadAllLines(infoPath, Encoding.UTF8);
                    string fileNumber = ReadLegacyValue(lines, "شماره پرونده:");

                    if (string.IsNullOrWhiteSpace(fileNumber) || FileNumberExists(fileNumber, 0))
                        continue;

                    string imagePath = Directory.GetFiles(folder, "Attachment.*").FirstOrDefault();
                    byte[] imageData = imagePath == null ? null : File.ReadAllBytes(imagePath);

                    var patient = new PatientRecord
                    {
                        FirstName = ReadLegacyValue(lines, "نام:"),
                        LastName = ReadLegacyValue(lines, "نام خانوادگی:"),
                        FileNumber = fileNumber,
                        Mobile = ReadLegacyValue(lines, "شماره موبایل:"),
                        ImageData = imageData,
                        ImageFileName = imagePath == null ? string.Empty : Path.GetFileName(imagePath)
                    };

                    if (!string.IsNullOrWhiteSpace(patient.FirstName) &&
                        !string.IsNullOrWhiteSpace(patient.LastName) &&
                        !string.IsNullOrWhiteSpace(patient.Mobile))
                    {
                        Save(patient);
                    }
                }
                catch
                {
                    // One damaged legacy record must not prevent the application from starting.
                }
            }

            SetSetting("LegacyRecordsMigrated", "1");
        }

        private string ReadLegacyValue(string[] lines, string key)
        {
            string line = lines.FirstOrDefault(x => x.StartsWith(key, StringComparison.Ordinal));
            return line == null ? string.Empty : line.Substring(key.Length).Trim();
        }

        private string GetSetting(string key)
        {
            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT SettingValue FROM AppSettings WHERE SettingKey=@Key LIMIT 1;";
                command.Parameters.AddWithValue("@Key", key);
                object value = command.ExecuteScalar();
                return value == null || value == DBNull.Value ? string.Empty : Convert.ToString(value);
            }
        }

        private void SetSetting(string key, string value)
        {
            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "INSERT OR REPLACE INTO AppSettings(SettingKey, SettingValue) VALUES(@Key, @Value);";
                command.Parameters.AddWithValue("@Key", key);
                command.Parameters.AddWithValue("@Value", value);
                command.ExecuteNonQuery();
            }
        }
    }

    internal sealed class PatientRecord
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FileNumber { get; set; }
        public string Mobile { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageFileName { get; set; }
        public string RegisteredAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
