using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TestApplication
{
    internal sealed class SupportForm : Form
    {
        private Label lblIpValue;
        private Label lblDomainValue;
        private Label lblPrivateValue;
        private Label lblPublicValue;
        private RadioButton rbFirewallOn;
        private RadioButton rbFirewallOff;
        private Button btnApply;
        private Button btnRefresh;
        private Button btnClose;

        internal SupportForm()
        {
            InitializeComponent();
            try { Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); } catch { }
            Shown += delegate { RefreshSystemInformation(); };
        }

        private void InitializeComponent()
        {
            Text = "پشتیبانی سیستم";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(720, 600);
            BackColor = Color.FromArgb(241, 245, 249);
            Font = new Font("Tahoma", 9F);
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = false;

            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 86,
                BackColor = Color.FromArgb(15, 23, 42)
            };

            Label title = new Label
            {
                Text = "پشتیبانی و اطلاعات سیستم",
                ForeColor = Color.White,
                Font = new Font("Tahoma", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(28, 14),
                Size = new Size(660, 34)
            };

            Label subtitle = new Label
            {
                Text = "مشاهده IP و مدیریت وضعیت Windows Firewall",
                ForeColor = Color.FromArgb(148, 163, 184),
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(28, 50),
                Size = new Size(660, 22)
            };

            header.Controls.Add(title);
            header.Controls.Add(subtitle);

            Panel infoPanel = CreateCard(new Point(28, 108), new Size(664, 190));
            Label infoTitle = CreateSectionTitle("اطلاعات شبکه و Firewall", 18);
            infoPanel.Controls.Add(infoTitle);

            infoPanel.Controls.Add(CreateCaption("IPv4 سیستم :", 62));
            lblIpValue = CreateValueLabel(62);
            infoPanel.Controls.Add(lblIpValue);

            infoPanel.Controls.Add(CreateCaption("Domain :", 96));
            lblDomainValue = CreateValueLabel(96);
            infoPanel.Controls.Add(lblDomainValue);

            infoPanel.Controls.Add(CreateCaption("Private :", 126));
            lblPrivateValue = CreateValueLabel(126);
            infoPanel.Controls.Add(lblPrivateValue);

            infoPanel.Controls.Add(CreateCaption("Public :", 156));
            lblPublicValue = CreateValueLabel(156);
            infoPanel.Controls.Add(lblPublicValue);

            Panel actionPanel = CreateCard(new Point(28, 316), new Size(664, 176));
            actionPanel.Controls.Add(CreateSectionTitle("تغییر وضعیت Firewall", 18));

            Label hint = new Label
            {
                Text = "وضعیت موردنظر را انتخاب کنید. هیچ تغییری تا زمان زدن «اعمال تغییرات» انجام نمی‌شود.",
                ForeColor = Color.FromArgb(100, 116, 139),
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(24, 52),
                Size = new Size(610, 24)
            };
            actionPanel.Controls.Add(hint);

            rbFirewallOn = new RadioButton
            {
                Text = "Firewall روشن باشد",
                Font = new Font("Tahoma", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(22, 101, 52),
                Location = new Point(410, 88),
                Size = new Size(220, 30)
            };

            rbFirewallOff = new RadioButton
            {
                Text = "Firewall خاموش باشد",
                Font = new Font("Tahoma", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(185, 28, 28),
                Location = new Point(170, 88),
                Size = new Size(220, 30)
            };

            btnApply = new Button
            {
                Text = "اعمال تغییرات",
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Tahoma", 9.5F, FontStyle.Bold),
                Location = new Point(410, 126),
                Size = new Size(220, 38)
            };
            btnApply.FlatAppearance.BorderSize = 0;
            btnApply.Click += btnApply_Click;

            btnRefresh = new Button
            {
                Text = "بروزرسانی وضعیت",
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 65, 85),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(170, 126),
                Size = new Size(220, 38)
            };
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnRefresh.Click += delegate { RefreshSystemInformation(); };

            actionPanel.Controls.Add(rbFirewallOn);
            actionPanel.Controls.Add(rbFirewallOff);
            actionPanel.Controls.Add(btnApply);
            actionPanel.Controls.Add(btnRefresh);

            btnClose = new Button
            {
                Text = "بستن",
                DialogResult = DialogResult.Cancel,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 65, 85),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(28, 514),
                Size = new Size(130, 42)
            };
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);

            Controls.Add(btnClose);
            Controls.Add(actionPanel);
            Controls.Add(infoPanel);
            Controls.Add(header);
            CancelButton = btnClose;
        }

        private Panel CreateCard(Point location, Size size)
        {
            return new Panel
            {
                Location = location,
                Size = size,
                BackColor = Color.White
            };
        }

        private Label CreateSectionTitle(string text, int top)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Tahoma", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(24, top),
                Size = new Size(610, 28)
            };
        }

        private Label CreateCaption(string text, int top)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Tahoma", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(71, 85, 105),
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(500, top),
                Size = new Size(130, 24)
            };
        }

        private Label CreateValueLabel(int top)
        {
            return new Label
            {
                Text = "در حال بررسی...",
                ForeColor = Color.FromArgb(15, 23, 42),
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(24, top),
                Size = new Size(465, 24)
            };
        }

        private void RefreshSystemInformation()
        {
            lblIpValue.Text = GetIPv4Addresses();

            bool? domain = ReadFirewallState("DomainProfile");
            bool? privateProfile = ReadFirewallState("StandardProfile");
            bool? publicProfile = ReadFirewallState("PublicProfile");

            SetFirewallLabel(lblDomainValue, domain);
            SetFirewallLabel(lblPrivateValue, privateProfile);
            SetFirewallLabel(lblPublicValue, publicProfile);

            bool allOn = domain == true && privateProfile == true && publicProfile == true;
            bool allOff = domain == false && privateProfile == false && publicProfile == false;

            rbFirewallOn.Checked = allOn;
            rbFirewallOff.Checked = allOff;
        }

        private string GetIPv4Addresses()
        {
            try
            {
                List<string> addresses = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == OperationalStatus.Up &&
                                n.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                                n.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                    .SelectMany(n => n.GetIPProperties().UnicastAddresses)
                    .Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork)
                    .Select(a => a.Address.ToString())
                    .Distinct()
                    .ToList();

                return addresses.Count == 0 ? "IPv4 فعال پیدا نشد" : string.Join("   |   ", addresses);
            }
            catch
            {
                return "خواندن IP انجام نشد";
            }
        }

        private bool? ReadFirewallState(string profileKey)
        {
            try
            {
                string path = @"SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\" + profileKey;
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(path))
                {
                    if (key == null)
                        return null;

                    object value = key.GetValue("EnableFirewall");
                    if (value == null)
                        return null;

                    return Convert.ToInt32(value) != 0;
                }
            }
            catch
            {
                return null;
            }
        }

        private void SetFirewallLabel(Label label, bool? enabled)
        {
            if (!enabled.HasValue)
            {
                label.Text = "نامشخص";
                label.ForeColor = Color.FromArgb(100, 116, 139);
                return;
            }

            label.Text = enabled.Value ? "روشن" : "خاموش";
            label.ForeColor = enabled.Value
                ? Color.FromArgb(22, 163, 74)
                : Color.FromArgb(220, 38, 38);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!rbFirewallOn.Checked && !rbFirewallOff.Checked)
            {
                UiMessage.Warning(this, "ابتدا وضعیت روشن یا خاموش را انتخاب کنید.", "Windows Firewall");
                return;
            }

            bool enable = rbFirewallOn.Checked;
            string message = enable
                ? "آیا Windows Firewall برای همه پروفایل‌ها روشن شود؟"
                : "خاموش کردن Firewall می‌تواند امنیت سیستم را کاهش دهد.\nآیا مطمئن هستید که Firewall برای همه پروفایل‌ها خاموش شود؟";

            if (UiMessage.Confirm(this, message, "تأیید تغییر Firewall") != DialogResult.Yes)
                return;

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "netsh.exe",
                    Arguments = "advfirewall set allprofiles state " + (enable ? "on" : "off"),
                    UseShellExecute = true,
                    Verb = "runas",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                using (Process process = Process.Start(startInfo))
                {
                    if (process == null)
                        throw new InvalidOperationException("اجرای دستور Firewall انجام نشد.");

                    process.WaitForExit();
                    if (process.ExitCode != 0)
                        throw new InvalidOperationException("Windows تغییر Firewall را نپذیرفت.");
                }

                RefreshSystemInformation();
                UiMessage.Info(this, "وضعیت Windows Firewall با موفقیت بروزرسانی شد.", "پشتیبانی سیستم");
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == 1223)
                {
                    UiMessage.Info(this, "درخواست دسترسی Administrator لغو شد و تغییری انجام نشد.", "پشتیبانی سیستم");
                    return;
                }

                UiMessage.Error(this, "تغییر Firewall انجام نشد.\n" + ex.Message, "پشتیبانی سیستم");
            }
            catch (Exception ex)
            {
                UiMessage.Error(this, "تغییر Firewall انجام نشد.\n" + ex.Message, "پشتیبانی سیستم");
            }
        }
    }
}
