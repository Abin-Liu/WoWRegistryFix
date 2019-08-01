using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MFGLib;
using System.Threading;
using System.ComponentModel;

namespace WoWRegistryFix
{
	public partial class MainForm : Form
	{
		const string REG_FILE = "WoWFix.reg";
		private LocaleCollection m_locales = new LocaleCollection();

		public MainForm()
		{
			InitializeComponent();

			Locale locale;
			locale = m_locales.RegisterLocale("zh-CN");
			locale["OK"] = "确定";
			locale["Exit"] = "退出";
			locale["Please select game programe (wow.exe)"] = "请选择游戏程序文件（wow.exe）";
			locale["Registry file created successfully, please double-click to run \"{0}\" in the folder opens shortly."] = "注册表文件已创建成功，请在即将自动打开的文件夹中双击运行\"{0}\"。";

			locale = m_locales.RegisterLocale("zh-TW");
			locale["OK"] = "確定";
			locale["Exit"] = "退出";
			locale["Please select game programe (wow.exe)"] = "請選擇遊戲程序文件（wow.exe）";
			locale["Registry file created successfully, please double-click to run \"{0}\" in the folder opens shortly."] = "註冊表文件已創建生成，請在即將自動打開的文件夾中雙擊運行\"{0}\"。";
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			lblWoWPath.Text = m_locales.GetLocalizedString("Please select game programe (wow.exe):");
			btnOK.Text = m_locales.GetLocalizedString("OK");
			btnCancel.Text = m_locales.GetLocalizedString("Exit");

			string wowPath = ReadWowPathFromRegistry();
			if (!string.IsNullOrEmpty(wowPath))
			{
				txtWowPath.Text = wowPath + "\\wow.exe";
			}			
		}

		private void OnFileOK(object sender, CancelEventArgs e)
		{
			string filePath = (sender as OpenFileDialog).FileName;
			if (string.IsNullOrEmpty(filePath) || Path.GetFileName(filePath).ToLower() != "wow.exe")
			{
				e.Cancel = true;
				MessageBox.Show(this, m_locales.GetLocalizedString("Please select game programe (wow.exe)"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			string message = m_locales.GetLocalizedString("Please select game programe (wow.exe)");
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Title = message;
			dialog.Filter = "Applications (*.exe)|*.exe";
			dialog.FileName = "wow.exe";
			dialog.FileOk += OnFileOK;

			if (txtWowPath.Text != "")
			{
				dialog.InitialDirectory = Path.GetDirectoryName(txtWowPath.Text);
			}
			
			if (dialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}			

			txtWowPath.Text = dialog.FileName;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtWowPath.Text))
			{
				return;
			}

			string regPath = CreateRegFile(Path.GetDirectoryName(txtWowPath.Text));
			if (regPath == null)
			{
				return;
			}

			string message = string.Format(m_locales.GetLocalizedString("Registry file created successfully, please double-click to run \"{0}\" in the folder opens shortly."), REG_FILE);
			MessageBox.Show(this, message, Application.ProductName);

			Process proc = Process.Start("explorer", "/select,\"" + regPath + "\"");			
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private string CreateRegFile(string wowPath)
		{
			string[] lines =
			{
				"Windows Registry Editor Version 5.00",
				"",
				"[HKEY_LOCAL_MACHINE\\SOFTWARE\\Blizzard Entertainment\\World of Warcraft]",
				string.Format("\"InstallPath\"=\"{0}\\\\\"", wowPath.Replace("\\", "\\\\")),
				"",
			};

			string regPath = AppDomain.CurrentDomain.BaseDirectory + "bin";
			Directory.CreateDirectory(regPath);
			regPath += "\\" + REG_FILE;

			try
			{
				File.WriteAllLines(regPath, lines, Encoding.Unicode);
				return regPath;
			}
			catch (Exception e)
			{
				MessageBox.Show(this, e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return null;
			}
		}

		private static string ReadWowPathFromRegistry()
		{
			string wowPath = null;
			RegistryKey root = Registry.LocalMachine;
			try
			{
				RegistryKey rk = root.OpenSubKey("SOFTWARE\\Blizzard Entertainment\\World of Warcraft", false);
				if (rk != null)
				{
					wowPath = rk.GetValue("InstallPath", "").ToString().TrimEnd(new char[] { '/', '\\' }); // 去除尾\\
					rk.Close();
				}				
			}
			catch
			{				
			}

			return wowPath;
		}		
	}
}
