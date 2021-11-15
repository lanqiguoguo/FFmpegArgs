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
public class MestimateFilterGen : ImageToImageFilter
{
internal MestimateFilterGen(ImageMap input) : base("mestimate",input) { AddMapOut(); }
/// <summary>
///  motion estimation method (from 1 to 9) (default esa)
/// </summary>
public MestimateFilterGen method(MestimateFilterGenMethod method) => this.SetOption("method", method.GetAttribute<NameAttribute>().Name);
/// <summary>
///  macroblock size (from 8 to INT_MAX) (default 16)
/// </summary>
public MestimateFilterGen mb_size(int mb_size) => this.SetOptionRange("mb_size", mb_size,8,INT_MAX);
/// <summary>
///  search parameter (from 4 to INT_MAX) (default 7)
/// </summary>
public MestimateFilterGen search_param(int search_param) => this.SetOptionRange("search_param", search_param,4,INT_MAX);
}
public static class MestimateFilterGenExtensions
{
/// <summary>
/// Generate motion vectors.
/// </summary>
public static MestimateFilterGen MestimateFilterGen(this ImageMap input0) => new MestimateFilterGen(input0);
}
public enum MestimateFilterGenMethod
{
[Name("esa")] esa,
[Name("tss")] tss,
[Name("tdls")] tdls,
[Name("ntss")] ntss,
[Name("fss")] fss,
[Name("ds")] ds,
[Name("hexbs")] hexbs,
[Name("epzs")] epzs,
[Name("umh")] umh,
}

}