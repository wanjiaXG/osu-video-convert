using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_video_convert
{
    public class Config
    {
        public string OsuRootPath = string.Empty;

        public string OsuSongsPath => Path.Combine(OsuRootPath, "Songs");

        public string TempPath => Path.Combine(OsuRootPath, "Temp");

        public string FFmpegPath => Path.Combine(TempPath, "ffmpeg.exe");

        public string IsExit = "是否退出程序";

        public string Messages = "提示";

        public string FinishAll = "已全部处理.";

        public string StartAll = "开始处理本地所有视频文件.";

        public string NotFoundIOsuPath = "未选择osu根目录，请选择后再使用";

        public string CantGetOsuPath = "未找到默认路径，请手动选择";

        public string FileIsEmpty = $"文件'{0}'为空!";

        public string IsMp4Error = $"{0} 请稍后重试! {1}";

        public string ConversionFailed = $"转换失败: {0}.";

        public string CantConvedrtToFlv = $"由于视频编码不兼容flv，正在二次转换, 本次转换耗时会长一点 {0}.";

        public string FixedVideo = $"视频已经过处理，无需再次修复'{0}'";

        public string FixSuccess = $"视频'{0}'修复完成.";

        public string FixFailure = $"视频'{0}'修复失败.";

        public string FileMonitorError = $"文件监视器发生错误:\n{0}:\n{1}";

        public string FileMonitorStarted = $"文件监视器已启动.";

        public string CantLoadFFMpeg = $"无法加载ffmpeg {0}";

        public string LoadedFFMpeg = $"已加载ffmpeg {0}";

        public string CantCreateCache = $"无法创建缓存目录!  {0}";

        public string CreatedCache = $"已创建缓存目录  {0}";

        public string NotOsuPath = $"该路径不是osu!根目录，请重新选择";

        public string NotifyText = "双击恢复窗口 osu!stable 视频格式修复(mp42flv)";
    }
}
