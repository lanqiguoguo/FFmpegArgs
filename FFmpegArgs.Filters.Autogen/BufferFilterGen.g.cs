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
public class BufferFilterGen : SourceImageFilter
{
internal BufferFilterGen(FilterGraph input) : base("buffer",input) { AddMapOut(); }
/// <summary>
///  (from 0 to INT_MAX) (default 0)
/// </summary>
public BufferFilterGen width(int width) => this.SetOptionRange("width", width,0,INT_MAX);
/// <summary>
/// 
/// </summary>
public BufferFilterGen video_size(Size size) => this.SetOption("video_size",$"{size.Width}x{size.Height}");
/// <summary>
///  (from 0 to INT_MAX) (default 0)
/// </summary>
public BufferFilterGen height(int height) => this.SetOptionRange("height", height,0,INT_MAX);
/// <summary>
///  (default none)
/// </summary>
public BufferFilterGen pix_fmt(PixFmt pix_fmt) => this.SetOption("pix_fmt",pix_fmt.ToString());
/// <summary>
///  sample aspect ratio (from 0 to DBL_MAX) (default 0/1)
/// </summary>
public BufferFilterGen sar(Rational sar) => this.SetOption("sar",sar.Check(0,DBL_MAX));
/// <summary>
///  sample aspect ratio (from 0 to DBL_MAX) (default 0/1)
/// </summary>
public BufferFilterGen pixel_aspect(Rational pixel_aspect) => this.SetOption("pixel_aspect",pixel_aspect.Check(0,DBL_MAX));
/// <summary>
///  (from 0 to DBL_MAX) (default 0/1)
/// </summary>
public BufferFilterGen time_base(Rational time_base) => this.SetOption("time_base",time_base.Check(0,DBL_MAX));
/// <summary>
///  (from 0 to DBL_MAX) (default 0/1)
/// </summary>
public BufferFilterGen frame_rate(Rational frame_rate) => this.SetOption("frame_rate",frame_rate.Check(0,DBL_MAX));
/// <summary>
/// 
/// </summary>
public BufferFilterGen sws_param(string sws_param) => this.SetOption("sws_param",sws_param);
}
public static class BufferFilterGenExtensions
{
/// <summary>
/// Buffer video frames, and make them accessible to the filterchain.
/// </summary>
public static BufferFilterGen BufferFilterGen(this FilterGraph input0) => new BufferFilterGen(input0);
}
}
