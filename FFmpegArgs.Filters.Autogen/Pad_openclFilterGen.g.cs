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
public class Pad_openclFilterGen : ImageToImageFilter
{
internal Pad_openclFilterGen(ImageMap input) : base("pad_opencl",input) { AddMapOut(); }
/// <summary>
///  set the pad area width (default "iw")
/// </summary>
public Pad_openclFilterGen width(string width) => this.SetOption("width",width);
/// <summary>
///  set the pad area width (default "iw")
/// </summary>
public Pad_openclFilterGen w(string w) => this.SetOption("w",w);
/// <summary>
///  set the pad area height (default "ih")
/// </summary>
public Pad_openclFilterGen height(string height) => this.SetOption("height",height);
/// <summary>
///  set the pad area height (default "ih")
/// </summary>
public Pad_openclFilterGen h(string h) => this.SetOption("h",h);
/// <summary>
///  set the x offset for the input image position (default "0")
/// </summary>
public Pad_openclFilterGen x(string x) => this.SetOption("x",x);
/// <summary>
///  set the y offset for the input image position (default "0")
/// </summary>
public Pad_openclFilterGen y(string y) => this.SetOption("y",y);
/// <summary>
///  set the color of the padded area border (default "black")
/// </summary>
public Pad_openclFilterGen color(Color color) => this.SetOption("color",color.ToHexStringRGBA());
/// <summary>
///  pad to fit an aspect instead of a resolution (from 0 to 32767) (default 0/1)
/// </summary>
public Pad_openclFilterGen aspect(string aspect) => this.SetOption("aspect",aspect);
}
public static class Pad_openclFilterGenExtensions
{
/// <summary>
/// Pad the input video.
/// </summary>
public static Pad_openclFilterGen Pad_openclFilterGen(this ImageMap input0) => new Pad_openclFilterGen(input0);
}
}
