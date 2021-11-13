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
public class ColorcontrastFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading,ICommandSupport
{
internal ColorcontrastFilterGen(ImageMap input) : base("colorcontrast",input) { AddMapOut(); }
/// <summary>
///  set the red-cyan contrast (from -1 to 1) (default 0)
/// </summary>
public ColorcontrastFilterGen rc(float rc) => this.SetOptionRange("rc", rc,-1,1);
/// <summary>
///  set the green-magenta contrast (from -1 to 1) (default 0)
/// </summary>
public ColorcontrastFilterGen gm(float gm) => this.SetOptionRange("gm", gm,-1,1);
/// <summary>
///  set the blue-yellow contrast (from -1 to 1) (default 0)
/// </summary>
public ColorcontrastFilterGen by(float by) => this.SetOptionRange("by", by,-1,1);
/// <summary>
///  set the red-cyan weight (from 0 to 1) (default 0)
/// </summary>
public ColorcontrastFilterGen rcw(float rcw) => this.SetOptionRange("rcw", rcw,0,1);
/// <summary>
///  set the green-magenta weight (from 0 to 1) (default 0)
/// </summary>
public ColorcontrastFilterGen gmw(float gmw) => this.SetOptionRange("gmw", gmw,0,1);
/// <summary>
///  set the blue-yellow weight (from 0 to 1) (default 0)
/// </summary>
public ColorcontrastFilterGen byw(float byw) => this.SetOptionRange("byw", byw,0,1);
/// <summary>
///  set the amount of preserving lightness (from 0 to 1) (default 0)
/// </summary>
public ColorcontrastFilterGen pl(float pl) => this.SetOptionRange("pl", pl,0,1);
}
public static class ColorcontrastFilterGenExtensions
{
/// <summary>
/// Adjust color contrast between RGB components.
/// </summary>
public static ColorcontrastFilterGen ColorcontrastFilterGen(this ImageMap input0) => new ColorcontrastFilterGen(input0);
}
}
