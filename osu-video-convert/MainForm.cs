using Microsoft.Win32;
using osu_video_convert.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osu_video_convert
{
    public partial class MainForm : Form
    {
        public const string OsuRootPathKey = "osu_video_convert_osu_root_path";
        public const string LanguageKey = "osu_video_convert_language";

        private FileSystemWatcher Watcher;

        private readonly Config Config = new Config();

        private SynchronizationContext Context;

        public MainForm()
        {
            Context = SynchronizationContext.Current;
            if (Context == null)
            {
                Context = new SynchronizationContext();
            }
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            object obj = Registry.CurrentUser.GetValue(LanguageKey);
            if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
            {
                languageCB.Text = obj.ToString();
            }

            obj = Registry.CurrentUser.GetValue(OsuRootPathKey);
            if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
            {
                Config.OsuRootPath = obj.ToString();
                osuPathTB.Text = obj.ToString();
            }

            
        }

        private void Log(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                Context.Post(new SendOrPostCallback(delegate (object obj)
                {
                    logTB.AppendText($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]: {obj}\r\n");
                }), message);

            }
        }

        public static string GetOsuPath()
        {
            try
            {
                object value = RegGet(Registry.ClassesRoot, @"osu!\shell\open\command");
                if (value == null)
                {
                    value = RegGet(Registry.LocalMachine, @"SOFTWARE\Classes\osu!\shell\open\command");
                }
                if (value == null)
                {
                    return string.Empty;
                }

                string osuPath = value.ToString();
                if (osuPath != null)
                {
                    Regex regex = new Regex(@"[A-Za-z].+\\");
                    Match match = regex.Match(osuPath.ToString());
                    osuPath = match.Value.Substring(0, match.Value.Length - 1);
                    osuPath = String.IsNullOrEmpty(osuPath) ? string.Empty : osuPath;
                    return osuPath;
                }
            }
            catch
            {
                return string.Empty;
            }

            return null;
        }

        public static object RegGet(RegistryKey registry, string Subkey)
        {
            return RegGet(registry, Subkey, "");
        }

        public static object RegGet(RegistryKey registry, string Subkey, string key)
        {
            try
            {
                using (var reg = registry.OpenSubKey(Subkey, false))
                {
                    return reg.GetValue(key);
                }
            }
            catch
            {
                return null;
            }
        }

        private void BrowserBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (HasOsu(dialog.SelectedPath))
                    {
                        osuPathTB.Text = dialog.SelectedPath;
                    }
                    else
                    {
                        MessageBox.Show(Config.NotOsuPath);
                    }

                }
            }
        }

        private bool HasOsu(string path)
        {
            if (path != null)
            {
                if (File.Exists(Path.Combine(path, "osu!.exe")) && Directory.Exists(Path.Combine(path, "Songs")))
                {
                    Registry.CurrentUser.SetValue(OsuRootPathKey, path);
                    Config.OsuRootPath = path;
                    return true;
                }
            }
            return false;
        }

        private void osuPathTB_TextChanged(object sender, EventArgs e)
        {
            lock (this)
            {
                if (!Directory.Exists(Config.TempPath))
                {
                    Directory.CreateDirectory(Config.TempPath);
                    if (!Directory.Exists(Config.TempPath))
                    {
                        string message = String.Format(Config.CantCreateCache, Config.TempPath);
                        Log(message);
                        MessageBox.Show(message);
                        return;
                    }
                    else
                    {
                        Log(String.Format(Config.CreatedCache, Config.TempPath));
                    }
                }


                if (!HasFFmpeg())
                {
                    File.WriteAllBytes(Config.FFmpegPath, Resources.ffmpeg);
                }

                if (HasFFmpeg())
                {
                    Log(String.Format(Config.LoadedFFMpeg, Config.FFmpegPath));
                }
                else
                {

                    Log(String.Format(Config.CantLoadFFMpeg, Config.FFmpegPath));
                }


                if (Watcher != null)
                {
                    Watcher.Dispose();
                    Watcher = null;
                }

                Watcher = new FileSystemWatcher();
                Watcher.Path = Path.Combine(osuPathTB.Text, "Songs");
                Watcher.Created += OnCreated;
                Watcher.Renamed += OnRenamed;
                Watcher.Changed += OnChanged;
                Watcher.Error += OnWatcherError;
                Watcher.EnableRaisingEvents = true;

                Log(Config.FileMonitorStarted);
            }
        }

        private bool HasFFmpeg()
        {
            return File.Exists(Config.FFmpegPath) && Resources.FFmpegMD5.Equals(GetFileMd5(Config.FFmpegPath));
        }

        public static string GetFileMd5(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant();
                }
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            FixVideo(e.FullPath);
        }

        private void OnWatcherError(object sender, ErrorEventArgs e)
        {
            Log(String.Format(Config.FileMonitorError, e.GetException().Message, e.GetException().StackTrace));
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            FixVideo(e.FullPath);
        }


        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            FixVideo(e.FullPath);
        }

        private static string[] Extensions = new[] { ".avi", ".mp4", "*.flv"};
        private void FixVideo(string fullPath)
        {
            if (Directory.Exists(fullPath))
            {
                //new DirectoryInfo(fullPath).GetFiles()
                foreach (var item in new DirectoryInfo(fullPath)
                    .GetFiles()
                    .Where(file => Extensions.Any(file.FullName.ToLower().EndsWith))
                    .ToList())
                {
                    lock (this)
                    {
                        if (IsMp4(item.FullName))
                        {
                            //string originalName = item.Name;
                            //string tempFile = Path.Combine(Config.TempPath, originalName);
                            //File.Copy(item.FullName, tempFile, true);
                            ConvertToFlv(item.FullName);
                            if (!IsMp4(item.FullName))
                            {
                                Log(String.Format(Config.FixSuccess, item.FullName));
                            }
                            else
                            {
                                Log(String.Format(Config.FixFailure, item.FullName));
                            }
                            return;
                        }
                        else
                        {
                            Log(String.Format(Config.FixedVideo, item.FullName));
                        }
                    }
                }
            }
        }

        private bool ConvertToFlv(string originalFile)
        {
            string outputFile = Path.Combine(Config.TempPath, $"osu_video_convert_temp.flv");

            string convertCommand = $"-i \"{originalFile}\" -vcodec copy -an -y \"{outputFile}\"";

            string infoCommand = $"-i \"{originalFile}\"";

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = Config.FFmpegPath;
            info.Arguments = convertCommand;
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.CreateNoWindow = true;

            //一次转换(无损)
            using (Process proc = Process.Start(info))
            {
                int maxCount = 10;
                int count = 0;
                string tmp;
                while ((tmp = proc.StandardError.ReadLine()) != null || count > maxCount)
                {
                    if (string.IsNullOrWhiteSpace(tmp))
                    {
                        count++;
                    }
                }
            }
            int birate = 0;
            if (File.ReadAllBytes(outputFile).Length <= 0)
            {
                //需要完整转码

                //读取码率信息
                info.Arguments = infoCommand;
                using (Process proc = Process.Start(info))
                {
                    int maxCount = 10;
                    int count = 0;
                    string tmp;
                    StringBuilder sb = new StringBuilder();
                    while ((tmp = proc.StandardError.ReadLine()) != null || count > maxCount)
                    {
                        sb.AppendLine(tmp);
                        if (string.IsNullOrWhiteSpace(tmp))
                        {
                            count++;
                        }
                    }

                    Match match = Regex.Match(sb.ToString(), "Duration.+");
                    if (match.Success)
                    {
                        string[] buff = match.Value.Split(' ');
                        if (buff.Length > 2 && int.TryParse(buff[buff.Length - 2], out int num))
                        {
                            birate = num;
                        }
                    }
                }
            }
            if (birate > 0)
            {
                info.Arguments = $"-i \"{originalFile}\" -b:v {birate}k -an -y \"{outputFile}\"";
                //二次转换(有损)
                using (Process proc = Process.Start(info))
                {
                    Log(String.Format(Config.CantConvedrtToFlv, originalFile));// $"由于视频编码不兼容flv，正在二次转换, 本次转换耗时会长一点 {originalFile}.");
                    int maxCount = 10;
                    int count = 0;
                    string tmp;
                    while ((tmp = proc.StandardError.ReadLine()) != null || count > maxCount)
                    {
                        if (string.IsNullOrWhiteSpace(tmp))
                        {
                            count++;
                        }
                    }
                }
            }

            if (File.ReadAllBytes(outputFile).Length > 0)
            {
                File.Copy(outputFile, originalFile, true);
                File.Delete(outputFile);
                return File.ReadAllBytes(originalFile).Length > 0;
            }
            else
            {
                Log(String.Format(Config.ConversionFailed, originalFile));
            }
            File.Delete(outputFile);

            return false;
        }

        private bool IsMp4(string fullName)
        {
            try
            {
                byte[] buff = File.ReadAllBytes(fullName);
                if (buff.Length < 4)
                {
                    Log(String.Format(Config.FileIsEmpty, fullName));
                    return false;
                }
                return (buff[0] == 0 && buff[1] == 0 && buff[2] == 0);
            }
            catch (Exception e)
            {
                Log(string.Format(Config.IsMp4Error, e.Message, fullName));
                return false;
            }
        }

        private void readDefaultBtn_Click(object sender, EventArgs e)
        {
            string path = GetOsuPath();
            if (HasOsu(path))
            {
                osuPathTB.Text = path;
            }
            else
            {
                MessageBox.Show(Config.CantGetOsuPath);
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            this.Show();
            this.TopMost = true;
        }

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt32() & 0xFFF0) == SC_MINIMIZE)
            {
                // 隐藏窗体而不是最小化它
                this.Hide();
                return;
            }
            base.WndProc(ref m);
        }

        private void fixAll_Click(object sender, EventArgs e)
        {
            new Thread(Run).Start();
            fixAllBtn.Enabled = false;
        }

        private void Run()
        {
            if (string.IsNullOrWhiteSpace(Config.OsuRootPath))
            {
                Context.Post(new SendOrPostCallback(delegate (object obj)
                {
                    MessageBox.Show(Config.NotFoundIOsuPath);
                }), null);
                return;
            }
            Log(Config.StartAll);
            foreach (var item in Directory.GetDirectories(Config.OsuSongsPath))
            {
                FixVideo(item);
            }
            Log(Config.FinishAll);
            Context.Post(new SendOrPostCallback(delegate (object obj)
            {
                fixAllBtn.Enabled = true;
            }), null);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(Config.IsExit, Config.Messages, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(languageCB.Text))
            {
                Registry.CurrentUser.SetValue(LanguageKey, languageCB.Text);
                if (languageCB.Text.Equals("English"))
                {
                    SetEnglish();
                }
                else if (languageCB.Text.Equals("中文"))
                {
                    SetChinese();
                }
            }
        }

        private void SetChinese()
        {
            osuRootPathLabel.Text = "osu!根目录";
            languageLabel.Text = "语言";
            RunningLogLabel.Text = "运行日志";
            BrowserBtn.Text = "浏览";
            fixAllBtn.Text = "修复本地所有视频";
            readDefaultBtn.Text = "自动获取路径";
            this.Text = "osu!stable 视频格式修复(mp42flv) by wanjia";
            notifyIcon.Text = $"双击恢复窗口";
            HintLabel.Text = "*长时间运行本程序可实时监控新图并转换.";

            Config.IsExit = "是否退出程序";
            Config.Messages = "提示";
            Config.FinishAll = "已全部处理.";
            Config.StartAll = "开始处理本地所有视频文件.";
            Config.NotFoundIOsuPath = "未选择osu!根目录，请选择后再使用";
            Config.CantGetOsuPath = "未找到默认路径，请手动选择";
            Config.FileIsEmpty = "文件'{0}'为空!";
            Config.IsMp4Error = "{0} 请稍后重试! {1}";
            Config.ConversionFailed = "转换失败: {0}";
            Config.CantConvedrtToFlv = "由于视频编码不兼容flv，正在二次转换, 本次转换耗时会长一点 {0}";

            Config.FixedVideo = "视频已经过处理，无需再次修复'{0}'";
            Config.FixSuccess = "视频'{0}'修复完成.";
            Config.FixFailure = "视频'{0}'修复失败.";
            Config.FileMonitorError = "文件监视器发生错误:\n{0}:\n{1}";
            Config.FileMonitorStarted = "文件监视器已启动.";
            Config.CantLoadFFMpeg = "无法加载ffmpeg {0}";
            Config.LoadedFFMpeg = "已加载ffmpeg {0}";
            Config.CantCreateCache = "无法创建缓存目录!  {0}";
            Config.CreatedCache = "已创建缓存目录  {0}";
            Config.NotOsuPath = "该路径不是osu!根目录，请重新选择";
        }

        private void SetEnglish()
        {
            osuRootPathLabel.Text = "osu! root Path";
            languageLabel.Text = "Language";
            RunningLogLabel.Text = "Running logs";
            BrowserBtn.Text = "Browse";
            fixAllBtn.Text = "Fix all local videos";
            readDefaultBtn.Text = "Get local osu! path";
            this.Text = "osu!stable Video format repair(mp42flv) by wanjia";
            notifyIcon.Text = $"Double click on the recovery window";
            HintLabel.Text = "*Running this program for a long time can monitor new map in real-time and convert them.";


            Config.IsExit = "Do you want to exit the program?";
            Config.Messages = "Message";
            Config.FinishAll = "All processed.";
            Config.StartAll = "Start processing all local video files.";
            Config.NotFoundIOsuPath = "osu! root path not selected, please select before using.";
            Config.CantGetOsuPath = "Can't get osu! path, please manually select.";
            Config.FileIsEmpty = "File '{0}' is empty!";

            Config.IsMp4Error = "{0} Please try again later! {1}";
            Config.ConversionFailed = $"Video format conversion failed: {0}";
            Config.CantConvedrtToFlv = $"Due to video encoding incompatibility with FLV, it is undergoing a second conversion, which will take a little longer to complete. {0}";

            Config.FixedVideo = "The video has been processed and does not need to be repaired again '{0}'";
            Config.FixSuccess = "Video '{0}' repair completed.";
            Config.FixFailure = "Video '{0}' repair failed.";
            Config.FileMonitorError = "File monitor encountered an error:\n{0}:\n{1}";
            Config.FileMonitorStarted = "File monitor started.";
            Config.CantLoadFFMpeg = "Can't load ffmpeg {0}";
            Config.LoadedFFMpeg = "ffmpeg loaded {0}";
            Config.CantCreateCache = "Unable to create cache directory!  {0}";
            Config.CreatedCache = "Created cache directory.  {0}";
            Config.NotOsuPath = "This path is not osu! Root directory, please reselect.";

        }
    }
}

