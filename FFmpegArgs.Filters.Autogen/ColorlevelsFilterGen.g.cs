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
public class ColorlevelsFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading,ICommandSupport
{
internal ColorlevelsFilterGen(ImageMap input) : base("colorlevels",input) { AddMapOut(); }
/// <summary>
///  set input red black point (from -1 to 1) (default 0)
/// </summary>
public ColorlevelsFilterGen rimin(double rimin) => this.SetOptionRange("rimin", rimin,-1,1);
/// <summary>
///  set input green black point (from -1 to 1) (default 0)
/// </summary>
public ColorlevelsFilterGen gimin(double gimin) => this.SetOptionRange("gimin", gimin,-1,1);
/// <summary>
///  set input blue black point (from -1 to 1) (default 0)
/// </summary>
public ColorlevelsFilterGen bimin(double bimin) => this.SetOptionRange("bimin", bimin,-1,1);
/// <summary>
///  set input alpha black point (from -1 to 1) (default 0)
/// </summary>
public ColorlevelsFilterGen aimin(double aimin) => this.SetOptionRange("aimin", aimin,-1,1);
/// <summary>
///  set input red white point (from -1 to 1) (default 1)
/// </summary>
public ColorlevelsFilterGen rimax(double rimax) => this.SetOptionRange("rimax", rimax,-1,1);
/// <summary>
///  set input green white point (from -1 to 1) (default 1)
/// </summary>
public ColorlevelsFilterGen gimax(double gimax) => this.SetOptionRange("gimax", gimax,-1,1);
/// <summary>
///  set input blue white point (from -1 to 1) (default 1)
/// </summary>
public ColorlevelsFilterGen bimax(double bimax) => this.SetOptionRange("bimax", bimax,-1,1);
/// <summary>
///  set input alpha white point (from -1 to 1) (default 1)
/// </summary>
public ColorlevelsFilterGen aimax(double aimax) => this.SetOptionRange("aimax", aimax,-1,1);
/// <summary>
///  set output red black point (from 0 to 1) (default 0)
/// </summary>
public ColorlevelsFilterGen romin(double romin) => this.SetOptionRange("romin", romin,0,1);
/// <summary>
///  set output green black point (from 0 to 1) (default 0)
/// </summary>
public ColorlevelsFilterGen gomin(double gomin) => this.SetOptionRange("gomin", gomin,0,1);
/// <summary>
///  set output blue black point (from 0 to 1) (default 0)
/// </summary>
public ColorlevelsFilterGen bomin(double bomin) => this.SetOptionRange("bomin", bomin,0,1);
/// <summary>
///  set output alpha black point (from 0 to 1) (default 0)
/// </summary>
public ColorlevelsFilterGen aomin(double aomin) => this.SetOptionRange("aomin", aomin,0,1);
/// <summary>
///  set output red white point (from 0 to 1) (default 1)
/// </summary>
public ColorlevelsFilterGen romax(double romax) => this.SetOptionRange("romax", romax,0,1);
/// <summary>
///  set output green white point (from 0 to 1) (default 1)
/// </summary>
public ColorlevelsFilterGen gomax(double gomax) => this.SetOptionRange("gomax", gomax,0,1);
/// <summary>
///  set output blue white point (from 0 to 1) (default 1)
/// </summary>
public ColorlevelsFilterGen bomax(double bomax) => this.SetOptionRange("bomax", bomax,0,1);
/// <summary>
///  set output alpha white point (from 0 to 1) (default 1)
/// </summary>
public ColorlevelsFilterGen aomax(double aomax) => this.SetOptionRange("aomax", aomax,0,1);
}
public static class ColorlevelsFilterGenExtensions
{
/// <summary>
/// Adjust the color levels.
/// </summary>
public static ColorlevelsFilterGen ColorlevelsFilterGen(this ImageMap input) => new ColorlevelsFilterGen(input);
}
}
