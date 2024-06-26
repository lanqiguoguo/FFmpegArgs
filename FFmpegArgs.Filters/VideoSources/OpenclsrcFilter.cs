﻿namespace FFmpegArgs.Filters.VideoSources
{
    /// <summary>
    /// ... openclsrc         |->V       Generate video using an OpenCL program<br>
    /// </br>https://ffmpeg.org/ffmpeg-filters.html#openclsrc
    /// </summary>
    public class OpenclsrcFilter : SourceToImageFilter
    {
        internal OpenclsrcFilter(IImageFilterGraph filterGraph) : base("openclsrc", filterGraph)
        {
            AddMapOut();
        }

        /// <summary>
        /// Size of frames to generate.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public OpenclsrcFilter Size(Size size) => this.SetOption("s", $"{size.Width}x{size.Height}");

        /// <summary>
        /// Pixel format to use for the generated frames
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public OpenclsrcFilter Format(PixFmt format) => this.SetOption("format", format);

        /// <summary>
        /// OpenCL program source file.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public OpenclsrcFilter Source(string source)
          => this.SetOption("source", source);
        /// <summary>
        /// Kernel name in program.
        /// </summary>
        /// <param name="kernel"></param>
        /// <returns></returns>
        public OpenclsrcFilter Kernel(string kernel)
          => this.SetOption("kernel", kernel);
        /// <summary>
        /// Number of frames generated every second. Default value is ’25’.
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public OpenclsrcFilter Rate(int r)
         => this.SetOptionRange("r", r, 1, int.MaxValue);
    }
    /// <summary>
    /// 
    /// </summary>
    public static class OpenclsrcFilterExtensions
    {
        /// <summary>
        /// Generate video using an OpenCL program.
        /// </summary>
        /// <param name="filterGraph"></param>
        /// <returns></returns>
        public static OpenclsrcFilter OpenclsrcFilter(this IImageFilterGraph filterGraph)
          => new OpenclsrcFilter(filterGraph);
    }
}
