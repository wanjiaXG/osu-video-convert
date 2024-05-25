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

        
    }
}
