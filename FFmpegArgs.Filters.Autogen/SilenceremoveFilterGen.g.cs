using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using FFmpegArgs;
using FFmpegArgs.Cores;
using FFmpegArgs.Cores.Filters;
using FFmpegArgs.Cores.Maps;
using FFmpegArgs.Expressions;
using FFmpegArgs.Filters;
using FFmpegArgs.Filters.Enums;
namespace FFmpegArgs.Filters.Autogens
{
public class SilenceremoveFilterGen : AudioToAudioFilter
{
internal SilenceremoveFilterGen(AudioMap input) : base("silenceremove",input) { AddMapOut(); }
/// <summary>
///  (from 0 to 9000) (default 0)
/// </summary>
public SilenceremoveFilterGen start_periods(int start_periods) => this.SetOptionRange("start_periods", start_periods,0,9000);
/// <summary>
///  set start duration of non-silence part (default 0)
/// </summary>
public SilenceremoveFilterGen start_duration(TimeSpan start_duration) => this.SetOptionRange("start_duration",start_duration,TimeSpan.Zero,TimeSpan.MaxValue);
/// <summary>
///  set threshold for start silence detection (from 0 to DBL_MAX) (default 0)
/// </summary>
public SilenceremoveFilterGen start_threshold(double start_threshold) => this.SetOptionRange("start_threshold", start_threshold,0,DBL_MAX);
/// <summary>
///  set start duration of silence part to keep (default 0)
/// </summary>
public SilenceremoveFilterGen start_silence(TimeSpan start_silence) => this.SetOptionRange("start_silence",start_silence,TimeSpan.Zero,TimeSpan.MaxValue);
/// <summary>
///  set which channel will trigger trimming from start (from 0 to 1) (default any)
/// </summary>
public SilenceremoveFilterGen start_mode(SilenceremoveFilterGenStart_mode start_mode) => this.SetOption("start_mode", start_mode.GetAttribute<NameAttribute>().Name);
/// <summary>
///  (from -9000 to 9000) (default 0)
/// </summary>
public SilenceremoveFilterGen stop_periods(int stop_periods) => this.SetOptionRange("stop_periods", stop_periods,-9000,9000);
/// <summary>
///  set stop duration of non-silence part (default 0)
/// </summary>
public SilenceremoveFilterGen stop_duration(TimeSpan stop_duration) => this.SetOptionRange("stop_duration",stop_duration,TimeSpan.Zero,TimeSpan.MaxValue);
/// <summary>
///  set threshold for stop silence detection (from 0 to DBL_MAX) (default 0)
/// </summary>
public SilenceremoveFilterGen stop_threshold(double stop_threshold) => this.SetOptionRange("stop_threshold", stop_threshold,0,DBL_MAX);
/// <summary>
///  set stop duration of silence part to keep (default 0)
/// </summary>
public SilenceremoveFilterGen stop_silence(TimeSpan stop_silence) => this.SetOptionRange("stop_silence",stop_silence,TimeSpan.Zero,TimeSpan.MaxValue);
/// <summary>
///  set which channel will trigger trimming from end (from 0 to 1) (default any)
/// </summary>
public SilenceremoveFilterGen stop_mode(SilenceremoveFilterGenStop_mode stop_mode) => this.SetOption("stop_mode", stop_mode.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set how silence is detected (from 0 to 1) (default rms)
/// </summary>
public SilenceremoveFilterGen detection(SilenceremoveFilterGenDetection detection) => this.SetOption("detection", detection.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set duration of window in seconds (from 0 to 10) (default 0.02)
/// </summary>
public SilenceremoveFilterGen window(double window) => this.SetOptionRange("window", window,0,10);
}
public static class SilenceremoveFilterGenExtensions
{
/// <summary>
/// Remove silence.
/// </summary>
public static SilenceremoveFilterGen SilenceremoveFilterGen(this AudioMap input) => new SilenceremoveFilterGen(input);
}
public enum SilenceremoveFilterGenStart_mode
{
[Name("any")] any,
[Name("all")] all,
}

public enum SilenceremoveFilterGenStop_mode
{
[Name("any")] any,
[Name("all")] all,
}

public enum SilenceremoveFilterGenDetection
{
[Name("peak")] peak,
[Name("rms")] rms,
}

}
