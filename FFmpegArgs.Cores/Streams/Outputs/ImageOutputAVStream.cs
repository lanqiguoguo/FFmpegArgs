﻿namespace FFmpegArgs.Cores.Streams
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageOutputAVStream : OutputAVStream,
        IImage, IImageCodec, IImageStream,
        ICodec, ICodecEncoder, IImageCodecEncoder,
        IStream, IImageOutputStream
    {
        /// <summary>
        /// 
        /// </summary>
        public ImageMap ImageMap { get; }

        /// <summary>
        /// 
        /// </summary>
        internal ImageOutputAVStream(ImageMap imageMap, int streamIndex) : base(imageMap, streamIndex)
        {
            this.ImageMap = imageMap;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            List<string> options = base.Options.Select(x => $"{x.Key}:v:{StreamIndex} {x.Value}").ToList();
            options.AddRange(base.Flags.Select(x => x));
            if (this.ImageMap.IsInput) options.Add($"-map {this.ImageMap.MapName}");
            else options.Add($"-map [{this.ImageMap.MapName}]");
            return string.Join(" ", options);
        }
    }
}
