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
public class PpFilterGen : ImageToImageFilter,ITimelineSupport,ICommandSupport
{
internal PpFilterGen(ImageMap input) : base("pp",input) { AddMapOut(); }
/// <summary>
///  set postprocess subfilters (default "de")
/// </summary>
public PpFilterGen subfilters(string subfilters) => this.SetOption("subfilters",subfilters);
}
public static class PpFilterGenExtensions
{
/// <summary>
/// Filter video using libpostproc.
/// </summary>
public static PpFilterGen PpFilterGen(this ImageMap input0) => new PpFilterGen(input0);
}
}