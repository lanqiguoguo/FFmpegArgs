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
public class Lut3dFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading,ICommandSupport
{
internal Lut3dFilterGen(ImageMap input) : base("lut3d",input) { AddMapOut(); }
/// <summary>
///  set 3D LUT file name
/// </summary>
public Lut3dFilterGen file(string file) => this.SetOption("file",file);
/// <summary>
///  select interpolation mode (from 0 to 4) (default tetrahedral)
/// </summary>
public Lut3dFilterGen interp(Lut3dFilterGenInterp interp) => this.SetOption("interp", interp.GetAttribute<NameAttribute>().Name);
}
public static class Lut3dFilterGenExtensions
{
/// <summary>
/// Adjust colors using a 3D LUT.
/// </summary>
public static Lut3dFilterGen Lut3dFilterGen(this ImageMap input0) => new Lut3dFilterGen(input0);
}
public enum Lut3dFilterGenInterp
{
[Name("nearest")] nearest,
[Name("trilinear")] trilinear,
[Name("tetrahedral")] tetrahedral,
[Name("pyramid")] pyramid,
[Name("prism")] prism,
}

}