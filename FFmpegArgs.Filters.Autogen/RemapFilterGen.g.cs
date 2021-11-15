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
public class RemapFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading
{
internal RemapFilterGen(params ImageMap[] inputs) : base("remap",inputs) { AddMapOut(); }
/// <summary>
///  set output format (from 0 to 1) (default color)
/// </summary>
public RemapFilterGen format(RemapFilterGenFormat format) => this.SetOption("format", format.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set the color of the unmapped pixels (default "black")
/// </summary>
public RemapFilterGen fill(Color fill) => this.SetOption("fill",fill.ToHexStringRGBA());
}
public static class RemapFilterGenExtensions
{
/// <summary>
/// Remap pixels.
/// </summary>
public static RemapFilterGen RemapFilterGen(this ImageMap input0, ImageMap input1, ImageMap input2) => new RemapFilterGen(input0, input1, input2);
}
public enum RemapFilterGenFormat
{
[Name("color")] color,
[Name("gray")] gray,
}

}