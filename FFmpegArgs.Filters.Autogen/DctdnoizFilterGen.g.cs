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
public class DctdnoizFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading
{
internal DctdnoizFilterGen(ImageMap input) : base("dctdnoiz",input) { AddMapOut(); }
/// <summary>
///  set noise sigma constant (from 0 to 999) (default 0)
/// </summary>
public DctdnoizFilterGen sigma(float sigma) => this.SetOptionRange("sigma", sigma,0,999);
/// <summary>
///  set noise sigma constant (from 0 to 999) (default 0)
/// </summary>
public DctdnoizFilterGen s(float s) => this.SetOptionRange("s", s,0,999);
/// <summary>
///  set number of block overlapping pixels (from -1 to 15) (default -1)
/// </summary>
public DctdnoizFilterGen overlap(int overlap) => this.SetOptionRange("overlap", overlap,-1,15);
/// <summary>
///  set coefficient factor expression
/// </summary>
public DctdnoizFilterGen expr(string expr) => this.SetOption("expr",expr);
/// <summary>
///  set coefficient factor expression
/// </summary>
public DctdnoizFilterGen e(string e) => this.SetOption("e",e);
/// <summary>
///  set the block size, expressed in bits (from 3 to 4) (default 3)
/// </summary>
public DctdnoizFilterGen n(int n) => this.SetOptionRange("n", n,3,4);
}
public static class DctdnoizFilterGenExtensions
{
/// <summary>
/// Denoise frames using 2D DCT.
/// </summary>
public static DctdnoizFilterGen DctdnoizFilterGen(this ImageMap input0) => new DctdnoizFilterGen(input0);
}
}