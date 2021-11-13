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
public class LumakeyFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading,ICommandSupport
{
internal LumakeyFilterGen(ImageMap input) : base("lumakey",input) { AddMapOut(); }
/// <summary>
///  set the threshold value (from 0 to 1) (default 0)
/// </summary>
public LumakeyFilterGen threshold(double threshold) => this.SetOptionRange("threshold", threshold,0,1);
/// <summary>
///  set the tolerance value (from 0 to 1) (default 0.01)
/// </summary>
public LumakeyFilterGen tolerance(double tolerance) => this.SetOptionRange("tolerance", tolerance,0,1);
/// <summary>
///  set the softness value (from 0 to 1) (default 0)
/// </summary>
public LumakeyFilterGen softness(double softness) => this.SetOptionRange("softness", softness,0,1);
}
public static class LumakeyFilterGenExtensions
{
/// <summary>
/// Turns a certain luma into transparency.
/// </summary>
public static LumakeyFilterGen LumakeyFilterGen(this ImageMap input) => new LumakeyFilterGen(input);
}
}
