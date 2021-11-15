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
public class ScaleFilterGen : ImageToImageFilter,ICommandSupport
{
internal ScaleFilterGen(ImageMap input) : base("scale",input) { AddMapOut(); }
/// <summary>
///  Output video width
/// </summary>
public ScaleFilterGen w(string w) => this.SetOption("w",w);
/// <summary>
///  Output video width
/// </summary>
public ScaleFilterGen width(string width) => this.SetOption("width",width);
/// <summary>
///  Output video height
/// </summary>
public ScaleFilterGen h(string h) => this.SetOption("h",h);
/// <summary>
///  Output video height
/// </summary>
public ScaleFilterGen height(string height) => this.SetOption("height",height);
/// <summary>
///  Flags to pass to libswscale (default "bilinear")
/// </summary>
public ScaleFilterGen flags(string flags) => this.SetOption("flags",flags);
/// <summary>
///  set interlacing (default false)
/// </summary>
public ScaleFilterGen interl(bool flag) => this.SetOption("interl",flag.ToFFmpegFlag());
/// <summary>
///  set input YCbCr type (default "auto")
/// </summary>
public ScaleFilterGen in_color_matrix(string in_color_matrix) => this.SetOption("in_color_matrix",in_color_matrix);
/// <summary>
///  set output YCbCr type
/// </summary>
public ScaleFilterGen out_color_matrix(string out_color_matrix) => this.SetOption("out_color_matrix",out_color_matrix);
/// <summary>
///  set input color range (from 0 to 2) (default auto)
/// </summary>
public ScaleFilterGen in_range(ScaleFilterGenIn_range in_range) => this.SetOption("in_range", in_range.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set output color range (from 0 to 2) (default auto)
/// </summary>
public ScaleFilterGen out_range(ScaleFilterGenOut_range out_range) => this.SetOption("out_range", out_range.GetAttribute<NameAttribute>().Name);
/// <summary>
///  input vertical chroma position in luma grid/256 (from -513 to 512) (default -513)
/// </summary>
public ScaleFilterGen in_v_chr_pos(int in_v_chr_pos) => this.SetOptionRange("in_v_chr_pos", in_v_chr_pos,-513,512);
/// <summary>
///  input horizontal chroma position in luma grid/256 (from -513 to 512) (default -513)
/// </summary>
public ScaleFilterGen in_h_chr_pos(int in_h_chr_pos) => this.SetOptionRange("in_h_chr_pos", in_h_chr_pos,-513,512);
/// <summary>
///  output vertical chroma position in luma grid/256 (from -513 to 512) (default -513)
/// </summary>
public ScaleFilterGen out_v_chr_pos(int out_v_chr_pos) => this.SetOptionRange("out_v_chr_pos", out_v_chr_pos,-513,512);
/// <summary>
///  output horizontal chroma position in luma grid/256 (from -513 to 512) (default -513)
/// </summary>
public ScaleFilterGen out_h_chr_pos(int out_h_chr_pos) => this.SetOptionRange("out_h_chr_pos", out_h_chr_pos,-513,512);
/// <summary>
///  decrease or increase w/h if necessary to keep the original AR (from 0 to 2) (default disable)
/// </summary>
public ScaleFilterGen force_original_aspect_ratio(ScaleFilterGenForce_original_aspect_ratio force_original_aspect_ratio) => this.SetOption("force_original_aspect_ratio", force_original_aspect_ratio.GetAttribute<NameAttribute>().Name);
/// <summary>
///  enforce that the output resolution is divisible by a defined integer when force_original_aspect_ratio is used (from 1 to 256) (default 1)
/// </summary>
public ScaleFilterGen force_divisible_by(int force_divisible_by) => this.SetOptionRange("force_divisible_by", force_divisible_by,1,256);
/// <summary>
///  Scaler param 0 (from INT_MIN to INT_MAX) (default 123456)
/// </summary>
public ScaleFilterGen param0(double param0) => this.SetOptionRange("param0", param0,INT_MIN,INT_MAX);
/// <summary>
///  Scaler param 1 (from INT_MIN to INT_MAX) (default 123456)
/// </summary>
public ScaleFilterGen param1(double param1) => this.SetOptionRange("param1", param1,INT_MIN,INT_MAX);
/// <summary>
///  set the number of slices (debug purpose only) (from 0 to INT_MAX) (default 0)
/// </summary>
public ScaleFilterGen nb_slices(int nb_slices) => this.SetOptionRange("nb_slices", nb_slices,0,INT_MAX);
/// <summary>
///  specify when to evaluate expressions (from 0 to 1) (default init)
/// </summary>
public ScaleFilterGen eval(ScaleFilterGenEval eval) => this.SetOption("eval", eval.GetAttribute<NameAttribute>().Name);
}
public static class ScaleFilterGenExtensions
{
/// <summary>
/// Scale the input video size and/or convert the image format.
/// </summary>
public static ScaleFilterGen ScaleFilterGen(this ImageMap input0) => new ScaleFilterGen(input0);
}
public enum ScaleFilterGenIn_range
{
[Name("auto")] auto,
[Name("unknown")] unknown,
[Name("full")] full,
[Name("limited")] limited,
[Name("jpeg")] jpeg,
[Name("mpeg")] mpeg,
[Name("tv")] tv,
[Name("pc")] pc,
}

public enum ScaleFilterGenOut_range
{
[Name("auto")] auto,
[Name("unknown")] unknown,
[Name("full")] full,
[Name("limited")] limited,
[Name("jpeg")] jpeg,
[Name("mpeg")] mpeg,
[Name("tv")] tv,
[Name("pc")] pc,
}

public enum ScaleFilterGenForce_original_aspect_ratio
{
[Name("disable")] disable,
[Name("decrease")] decrease,
[Name("increase")] increase,
}

public enum ScaleFilterGenEval
{
[Name("init")] init,
[Name("frame")] frame,
}

}