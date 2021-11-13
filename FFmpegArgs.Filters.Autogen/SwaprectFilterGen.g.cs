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
public class SwaprectFilterGen : ImageToImageFilter,ITimelineSupport,ICommandSupport
{
internal SwaprectFilterGen(ImageMap input) : base("swaprect",input) { AddMapOut(); }
/// <summary>
///  set rect width (default "w/2")
/// </summary>
public SwaprectFilterGen w(string w) => this.SetOption("w",w);
/// <summary>
///  set rect height (default "h/2")
/// </summary>
public SwaprectFilterGen h(string h) => this.SetOption("h",h);
/// <summary>
///  set 1st rect x top left coordinate (default "w/2")
/// </summary>
public SwaprectFilterGen x1(string x1) => this.SetOption("x1",x1);
/// <summary>
///  set 1st rect y top left coordinate (default "h/2")
/// </summary>
public SwaprectFilterGen y1(string y1) => this.SetOption("y1",y1);
/// <summary>
///  set 2nd rect x top left coordinate (default "0")
/// </summary>
public SwaprectFilterGen x2(string x2) => this.SetOption("x2",x2);
/// <summary>
///  set 2nd rect y top left coordinate (default "0")
/// </summary>
public SwaprectFilterGen y2(string y2) => this.SetOption("y2",y2);
}
public static class SwaprectFilterGenExtensions
{
/// <summary>
/// Swap 2 rectangular objects in video.
/// </summary>
public static SwaprectFilterGen SwaprectFilterGen(this ImageMap input) => new SwaprectFilterGen(input);
}
}
