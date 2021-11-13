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
public class VflipFilterGen : ImageToImageFilter,ITimelineSupport
{
internal VflipFilterGen(ImageMap input) : base("vflip",input) { AddMapOut(); }
}
public static class VflipFilterGenExtensions
{
/// <summary>
/// Flip the input video vertically.
/// </summary>
public static VflipFilterGen VflipFilterGen(this ImageMap input) => new VflipFilterGen(input);
}
}
