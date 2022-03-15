﻿namespace FFmpegArgs.Outputs
{
    /// <summary>
    /// Image/Video non audio
    /// </summary>
    public class ImageUrlOutput : ImageOutput
    {
        readonly Uri _url;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="format"></param>
        /// <param name="imageMap"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ImageUrlOutput(Uri url, MuxingFileFormat format, ImageMap imageMap) : base(imageMap)
        {
            this._url = url ?? throw new ArgumentNullException(nameof(url));
            this.Format(format);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            List<string> args = new List<string>()
            {
                GetArgs(),
                "-map",
                ImageMap.IsInput ? ImageMap.MapName : $"[{ImageMap.MapName}]",
                _url.ToString()
            };
            return string.Join(" ", args.Where(x => !string.IsNullOrWhiteSpace(x)));
        }
    }
}
