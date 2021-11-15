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
public class HaldclutsrcFilterGen : SourceImageFilter
{
internal HaldclutsrcFilterGen(FilterGraph input) : base("haldclutsrc",input) { AddMapOut(); }
/// <summary>
///  set level (from 2 to 16) (default 6)
/// </summary>
public HaldclutsrcFilterGen level(int level) => this.SetOptionRange("level", level,2,16);
/// <summary>
///  set video rate (default "25")
/// </summary>
public HaldclutsrcFilterGen Rate(string r) => this.SetOption("rate", r);
/// <summary>
///  set video rate (default "25")
/// </summary>
public HaldclutsrcFilterGen rate(int r) => this.SetOptionRange("rate", r, 1, int.MaxValue);
/// <summary>
///  set video rate (default "25")
/// </summary>
public HaldclutsrcFilterGen R(string r) => this.SetOption("r", r);
/// <summary>
///  set video rate (default "25")
/// </summary>
public HaldclutsrcFilterGen r(int r) => this.SetOptionRange("r", r, 1, int.MaxValue);
/// <summary>
///  set video duration (default -0.000001)
/// </summary>
public HaldclutsrcFilterGen duration(TimeSpan duration) => this.SetOptionRange("duration",duration,TimeSpan.Zero,TimeSpan.MaxValue);
/// <summary>
///  set video duration (default -0.000001)
/// </summary>
public HaldclutsrcFilterGen d(TimeSpan d) => this.SetOptionRange("d",d,TimeSpan.Zero,TimeSpan.MaxValue);
/// <summary>
///  set video sample aspect ratio (from 0 to INT_MAX) (default 1/1)
/// </summary>
public HaldclutsrcFilterGen sar(Rational sar) => this.SetOption("sar",sar.Check(0,INT_MAX));
}
public static class HaldclutsrcFilterGenExtensions
{
/// <summary>
/// Provide an identity Hald CLUT.
/// </summary>
public static HaldclutsrcFilterGen HaldclutsrcFilterGen(this FilterGraph input0) => new HaldclutsrcFilterGen(input0);
}
}
