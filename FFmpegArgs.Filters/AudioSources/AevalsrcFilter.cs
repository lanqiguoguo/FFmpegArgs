﻿using FFmpegArgs.Utils;
using System;
using System.Collections.Generic;

namespace FFmpegArgs.Filters.AudioSources
{
  /// <summary>
  ///  ... aevalsrc          |->A       Generate an audio signal generated by an expression.<br>
  ///  </br>https://ffmpeg.org/ffmpeg-filters.html#aevalsrc
  /// </summary>
  public class AevalsrcFilter : SourceAudioFilter
  {
    static readonly IEnumerable<string> _variables = new List<string>()
    {
      "n","t","s"
    };
    readonly Expression expression = new Expression(_variables);
    internal AevalsrcFilter(FilterGraph filterGraph, Action<Expression> exprs) : base("aevalsrc", filterGraph)
    {
      this.SetOption("exprs", exprs.Run(expression));
      AddMapOut();
    }

    /// <summary>
    /// Set the channel layout. The number of channels in the specified layout must be equal to the number of specified expressions.
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public AevalsrcFilter ChannelLayout(int c)
      => this.SetOptionRange("c", c, 0, int.MaxValue);

    /// <summary>
    /// Set the minimum duration of the sourced audio.<br>
    /// </br> Note that the resulting duration may be greater than the specified duration, as the generated audio is always cut at the end of a complete frame.
    /// If not specified, or the expressed duration is negative, the audio is supposed to be generated forever.
    /// </summary>
    /// <param name="duration">seconds</param>
    /// <returns></returns>
    public AevalsrcFilter Duration(TimeSpan duration)
      => this.SetOptionRange("d", duration, TimeSpan.Zero, TimeSpan.MaxValue);

    /// <summary>
    /// Set the number of samples per channel per each output frame, default to 1024.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public AevalsrcFilter NbSamples(int n)
      => this.SetOptionRange("n", n, 0, int.MaxValue);

    /// <summary>
    /// Specify the sample rate, default to 44100.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public AevalsrcFilter SampleRate(int s)
      => this.SetOptionRange("s", s, 0, int.MaxValue);
  }

  public static class AevalsrcFilterExtensions
  {
    /// <summary>
    /// Generate an audio signal specified by an expression.<br></br>
    /// This source accepts in input one or more expressions(one for each channel), which are evaluated and used to generate a corresponding audio signal.
    /// </summary>
    /// <param name="filterGraph"></param>
    /// <param name="exprs">Set the ’|’-separated expressions list for each separate channel.<br>
    /// </br> In case the channel_layout option is not specified, the selected channel layout depends on the number of provided expressions.<br>
    /// </br> Otherwise the last specified expression is applied to the remaining output channels.</param>
    /// <returns></returns>
    public static AevalsrcFilter AevalsrcFilter(this FilterGraph filterGraph, string exprs)
      => new AevalsrcFilter(filterGraph, exprs.Expression());

    /// <summary>
    /// Generate an audio signal specified by an expression.<br></br>
    /// This source accepts in input one or more expressions(one for each channel), which are evaluated and used to generate a corresponding audio signal.
    /// </summary>
    /// <param name="filterGraph"></param>
    /// <param name="exprs">Set the ’|’-separated expressions list for each separate channel.<br>
    /// </br> In case the channel_layout option is not specified, the selected channel layout depends on the number of provided expressions.<br>
    /// </br> Otherwise the last specified expression is applied to the remaining output channels.</param>
    /// <returns></returns>
    public static AevalsrcFilter AevalsrcFilter(this FilterGraph filterGraph, Action<Expression> exprs)
      => new AevalsrcFilter(filterGraph, exprs);
  }
}
