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
public class FillbordersFilterGen : ImageToImageFilter,ITimelineSupport,ICommandSupport
{
internal FillbordersFilterGen(ImageMap input) : base("fillborders",input) { AddMapOut(); }
/// <summary>
///  set the left fill border (from 0 to INT_MAX) (default 0)
/// </summary>
public FillbordersFilterGen left(int left) => this.SetOptionRange("left", left,0,INT_MAX);
/// <summary>
///  set the right fill border (from 0 to INT_MAX) (default 0)
/// </summary>
public FillbordersFilterGen right(int right) => this.SetOptionRange("right", right,0,INT_MAX);
/// <summary>
///  set the top fill border (from 0 to INT_MAX) (default 0)
/// </summary>
public FillbordersFilterGen top(int top) => this.SetOptionRange("top", top,0,INT_MAX);
/// <summary>
///  set the bottom fill border (from 0 to INT_MAX) (default 0)
/// </summary>
public FillbordersFilterGen bottom(int bottom) => this.SetOptionRange("bottom", bottom,0,INT_MAX);
/// <summary>
///  set the fill borders mode (from 0 to 5) (default smear)
/// </summary>
public FillbordersFilterGen mode(FillbordersFilterGenMode mode) => this.SetOption("mode", mode.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set the color for the fixed/fade mode (default "black")
/// </summary>
public FillbordersFilterGen color(Color color) => this.SetOption("color",color.ToHexStringRGBA());
}
public static class FillbordersFilterGenExtensions
{
/// <summary>
/// Fill borders of the input video.
/// </summary>
public static FillbordersFilterGen FillbordersFilterGen(this ImageMap input0) => new FillbordersFilterGen(input0);
}
public enum FillbordersFilterGenMode
{
[Name("smear")] smear,
[Name("mirror")] mirror,
[Name("fixed")] _fixed,
[Name("reflect")] reflect,
[Name("wrap")] wrap,
[Name("fade")] fade,
}

}