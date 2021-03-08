using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace DarkSoulsRemastest_Installer
{
    public partial class MainForm : Form
    {
        readonly string tempPath = Path.GetTempPath() + "darksoulsremastest" + Guid.NewGuid().ToString() + "\\";

        public MainForm()
        {
            InitializeComponent();
            string installDir = GetInstallDir();
            textBoxDir.Text = installDir;

            if (IsModded(installDir))
                labelModded.Text = "Yes, version " + GetInstalledVer(installDir);
            else
                labelModded.Text = "No.";

            labelModVerOnline.Text = GetOnlineVer();
        }
        private string GetInstallDir()
        {
            try
            {
                RegistryKey dir = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 211420", false);
                return dir.GetValue("InstallLocation").ToString();
            }
            catch (NullReferenceException)
            {
                return "not found.";
            }
        }
        private bool IsModded(string installDir)
        {
            if (System.IO.File.Exists(installDir + @"\DATA\DS_Overhaul.dll"))
                return true;
            else
                return false;
        } 
        private string GetInstalledVer(string installDir)
        {
            string fileLoc = installDir + @"\DATA\OverhaulVersion.txt";
            if (System.IO.File.Exists(fileLoc))
                return System.IO.File.ReadLines(fileLoc).First();
            else
                return "unknown";
        }
        private string GetDownloadStr()
        {
            string postUrl = @"https://www.patreon.com/api/posts/46865100";
            string webContent;
            try
            {
                using (WebClient c = new WebClient())
                {
                    webContent = c.DownloadString(postUrl);
                }
                var pattern = @"https:\/\/www\.patreon\.com\/file\?h=\d+&amp;i=\d+";
                Regex rgx = new Regex(pattern);
                var matches = rgx.Matches(webContent);
                StringBuilder builder = new StringBuilder(matches[0].ToString());
                builder.Replace("&amp;", "&");
                return builder.ToString();
            }
            catch (WebException)
            {
                MessageBox.Show("Connection failed. Please check your internet connection.", "Connection error.");
                Application.Exit();
                return null;
            }
        }
        private string GetOnlineVer()
        {
            string postUrl = @"https://www.patreon.com/api/posts/46865100";
            string webContent;
            try
            {
                using (WebClient c = new WebClient())
                {
                    c.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:86.0) Gecko/20100101 Firefox/86.0";
                    webContent = c.DownloadString(postUrl);
                }
                var pattern = @"\d\.\d\.\d\.zip";
                Regex rgx = new Regex(pattern);
                var matches = rgx.Matches(webContent);
                string version = matches[0].ToString();
                version = version.Substring(0, version.Length - 4);
                return version;
            }
            catch (WebException)
            {
                MessageBox.Show("Connection failed. Please check your internet connection.","Connection error.");
                Application.Exit();
                return null;
            }
        }
        private void ButtonInstall_Click(object sender, EventArgs e)
        {
            bool doInstall = false;
            if (GetInstalledVer(textBoxDir.Text) == GetOnlineVer())
            {
                DialogResult dialogResult = MessageBox.Show("Most recent version already installed. Reinstall?", "Reinstall?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    doInstall = true;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("This will install the Dark Souls Remastest mod by InfernoPlus, which may take a while.\nContinue?", "Continue?", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                    doInstall = true;
            }

            if (doInstall)
            {
                try
                {
                    using (FileStream fs = System.IO.File.Create(textBoxDir.Text + "\\writetestfile"))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                        fs.Write(info, 0, info.Length);
                    }
                    System.IO.File.Delete(textBoxDir.Text + "\\writetestfile");
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("It appears you need administrator privileges to write to your game folder.\n" +
                        "Please restart this application as an administrator");
                    Application.Exit();
                }
                InstallStep1();
            }
        }
        private void InstallStep1()
        {
            textBoxDir.Enabled = false;
            buttonDirSel.Enabled = false;
            buttonInstall.Enabled = false;

            Directory.CreateDirectory(tempPath);
            labelProgress.Text = "Download started.";
            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DlCompleted);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DlProgressChanged);
                client.DownloadFileAsync(new Uri(GetDownloadStr()), tempPath + "mod.zip");
            }
        }

        private void DlProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void DlCompleted(object sender, AsyncCompletedEventArgs e)
        {
            labelProgress.Text = "Download completed.";
            InstallStep2();
        }
        private void InstallStep2()
        {
            string gameDir = textBoxDir.Text + "\\";

            progressBar1.Style = ProgressBarStyle.Marquee;
            ZipFile.ExtractToDirectory(tempPath + "mod.zip", tempPath);
            labelProgress.Text = "Extraction completed.";
            if (!IsModded(gameDir)) //Extraction is not necessary if it is already modded.
            {
                labelProgress.Text = "Started game unpack.";
                System.IO.File.Copy(tempPath + "UnpackDarkSoulsForModding.exe", gameDir + "DATA\\UnpackDarkSoulsForModding.exe", true);
                Process process = new Process();
                process.StartInfo.WorkingDirectory = Path.Combine(gameDir, "DATA");
                process.StartInfo.FileName = "UnpackDarkSoulsForModding.exe";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
                process.WaitForExit();
                labelProgress.Text = "Game unpack completed.";
            }
            labelProgress.Text = "Started copying modified game files.";

            CopyFolder(Path.Combine(tempPath, "DATA"), Path.Combine(gameDir, "DATA"));
            System.IO.File.Copy(tempPath + "DSCM.exe", gameDir + "DATA\\DSCM.exe", true);
            CreateShortcut("DSCM", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), gameDir + "DATA\\DSCM.exe", "Dark Souls Connectivitiy Mod");
            labelProgress.Text = "Done!";
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Value = progressBar1.Maximum;

            using (FileStream fs = System.IO.File.Create(Path.Combine(gameDir, "DATA", "OverhaulVersion.txt")))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(GetOnlineVer());
                fs.Write(info, 0, info.Length);
            }

            textBoxDir.Enabled = true;
            buttonDirSel.Enabled = true;
            Directory.Delete(tempPath, true);
            labelModded.Text = "Yes, version " + GetInstalledVer(gameDir);
            buttonInstall.Enabled = true;
            MessageBox.Show("Installation completed.\nFor multiplayer to work, you have to run DSCM before starting the game!");
        }
        private void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                System.IO.File.Copy(file, dest, true);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }
        private void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation, string description)
        {
            // It seems unnecessarily complex to create a simple shortcut using C#. Oh well.
            string shortcutLocation = Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = description;
            shortcut.TargetPath = targetFileLocation;
            shortcut.Save();
        }
        private void ButtonDirSel_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
