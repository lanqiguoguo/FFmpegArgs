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
public class BboxFilterGen : ImageToImageFilter,ITimelineSupport,ICommandSupport
{
internal BboxFilterGen(ImageMap input) : base("bbox",input) { AddMapOut(); }
/// <summary>
///  set minimum luminance value for bounding box (from 0 to 65535) (default 16)
/// </summary>
public BboxFilterGen min_val(int min_val) => this.SetOptionRange("min_val", min_val,0,65535);
}
public static class BboxFilterGenExtensions
{
/// <summary>
/// Compute bounding box for each frame.
/// </summary>
public static BboxFilterGen BboxFilterGen(this ImageMap input0) => new BboxFilterGen(input0);
}
}