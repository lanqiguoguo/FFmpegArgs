﻿using FFmpegArgs.Filters.Enums;

namespace FFmpegArgs.Filters.AudioSources
{
    /// <summary>
    /// ... abuffer           |->A       Buffer audio frames, and make them accessible to the filterchain.<br>
    /// </br>https://ffmpeg.org/ffmpeg-filters.html#abuffer
    /// </summary>
    public class AbufferFilter : SourceAudioFilter
    {
        internal AbufferFilter(FilterGraph filterGraph) : base("abuffer", filterGraph)
        {
            AddMapOut();
        }

        /// <summary>
        /// The timebase which will be used for timestamps of submitted frames. It must be either a floating-point number or in numerator/denominator form.
        /// </summary>
        /// <param name="time_base"></param>
        /// <returns></returns>
        public AbufferFilter TimeBase(double time_base)
          => this.SetOptionRange("time_base", time_base, 0, double.MaxValue);

        /// <summary>
        /// The sample rate of the incoming audio buffers.
        /// </summary>
        /// <param name="sample_rate"></param>
        /// <returns></returns>
        public AbufferFilter SampleRate(int sample_rate)
          => this.SetOptionRange("sample_rate", sample_rate, 0, int.MaxValue);

        /// <summary>
        /// The sample format of the incoming audio buffers.<br>
        /// </br> Either a sample format name or its corresponding integer representation from the enum AVSampleFormat in libavutil/samplefmt.h
        /// </summary>
        /// <param name="sample_fmt"></param>
        /// <returns></returns>
        public AbufferFilter SampleFmt(AVSampleFormat sample_fmt)
          => this.SetOption("sample_fmt", sample_fmt.ToString().Replace("AV_SAMPLE_FMT_", "").ToLower());

        /// <summary>
        /// The channel layout of the incoming audio buffers.<br>
        /// </br> Either a channel layout name from channel_layout_map in libavutil/channel_layout.c or its corresponding integer representation from the AV_CH_LAYOUT_* macros in libavutil/channel_layout.h
        /// </summary>
        /// <param name="channel_layout"></param>
        /// <returns></returns>
        public AbufferFilter ChannelLayout(AV_CH_LAYOUT channel_layout)
          => this.SetOption("channel_layout", channel_layout.GetAttribute<NameAttribute>().Name);

        /// <summary>
        /// The number of channels of the incoming audio buffers. If both channels and channel_layout are specified, then they must be consistent.
        /// </summary>
        /// <param name="channels"></param>
        /// <returns></returns>
        public AbufferFilter Channels(int channels)
          => this.SetOptionRange("channels", channels, 0, int.MaxValue);
    }

    public static class AbufferFilterExtensions
    {
        /// <summary>
        /// Buffer audio frames, and make them available to the filter chain.<br></br>
        /// This source is mainly intended for a programmatic use, in particular through the interface defined in libavfilter/buffersrc.h.
        /// </summary>
        /// <param name="filterGraph"></param>
        /// <returns></returns>
        public static AbufferFilter AbufferFilter(this FilterGraph filterGraph)
          => new AbufferFilter(filterGraph);
    }
}