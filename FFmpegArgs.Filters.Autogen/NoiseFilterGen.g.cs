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
public class NoiseFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading
{
internal NoiseFilterGen(ImageMap input) : base("noise",input) { AddMapOut(); }
/// <summary>
///  set component #0 noise seed (from -1 to INT_MAX) (default -1)
/// </summary>
public NoiseFilterGen all_seed(int all_seed) => this.SetOptionRange("all_seed", all_seed,-1,INT_MAX);
/// <summary>
///  set component #0 strength (from 0 to 100) (default 0)
/// </summary>
public NoiseFilterGen all_strength(int all_strength) => this.SetOptionRange("all_strength", all_strength,0,100);
/// <summary>
///  set component #0 strength (from 0 to 100) (default 0)
/// </summary>
public NoiseFilterGen alls(int alls) => this.SetOptionRange("alls", alls,0,100);
/// <summary>
///  set component #0 flags (default 0)
/// </summary>
public NoiseFilterGen all_flags(NoiseFilterGenAll_flags all_flags) => this.SetOption("all_flags", all_flags.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set component #0 flags (default 0)
/// </summary>
public NoiseFilterGen allf(NoiseFilterGenAllf allf) => this.SetOption("allf", allf.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set component #0 noise seed (from -1 to INT_MAX) (default -1)
/// </summary>
public NoiseFilterGen c0_seed(int c0_seed) => this.SetOptionRange("c0_seed", c0_seed,-1,INT_MAX);
/// <summary>
///  set component #0 strength (from 0 to 100) (default 0)
/// </summary>
public NoiseFilterGen c0_strength(int c0_strength) => this.SetOptionRange("c0_strength", c0_strength,0,100);
/// <summary>
///  set component #0 strength (from 0 to 100) (default 0)
/// </summary>
public NoiseFilterGen c0s(int c0s) => this.SetOptionRange("c0s", c0s,0,100);
/// <summary>
///  set component #0 flags (default 0)
/// </summary>
public NoiseFilterGen c0_flags(NoiseFilterGenC0_flags c0_flags) => this.SetOption("c0_flags", c0_flags.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set component #0 flags (default 0)
/// </summary>
public NoiseFilterGen c0f(NoiseFilterGenC0f c0f) => this.SetOption("c0f", c0f.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set component #1 noise seed (from -1 to INT_MAX) (default -1)
/// </summary>
public NoiseFilterGen c1_seed(int c1_seed) => this.SetOptionRange("c1_seed", c1_seed,-1,INT_MAX);
/// <summary>
///  set component #1 strength (from 0 to 100) (default 0)
/// </summary>
public NoiseFilterGen c1_strength(int c1_strength) => this.SetOptionRange("c1_strength", c1_strength,0,100);
/// <summary>
///  set component #1 strength (from 0 to 100) (default 0)
/// </summary>
public NoiseFilterGen c1s(int c1s) => this.SetOptionRange("c1s", c1s,0,100);
/// <summary>
///  set component #1 flags (default 0)
/// </summary>
public NoiseFilterGen c1_flags(NoiseFilterGenC1_flags c1_flags) => this.SetOption("c1_flags", c1_flags.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set component #1 flags (default 0)
/// </summary>
public NoiseFilterGen c1f(NoiseFilterGenC1f c1f) => this.SetOption("c1f", c1f.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set component #2 noise seed (from -1 to INT_MAX) (default -1)
/// </summary>
public NoiseFilterGen c2_seed(int c2_seed) => this.SetOptionRange("c2_seed", c2_seed,-1,INT_MAX);
/// <summary>
///  set component #2 strength (from 0 to 100) (default 0)
/// </summary>
public NoiseFilterGen c2_strength(int c2_strength) => this.SetOptionRange("c2_strength", c2_strength,0,100);
/// <summary>
///  set component #2 strength (from 0 to 100) (default 0)
/// </summary>
public NoiseFilterGen c2s(int c2s) => this.SetOptionRange("c2s", c2s,0,100);
/// <summary>
///  set component #2 flags (default 0)
/// </summary>
public NoiseFilterGen c2_flags(NoiseFilterGenC2_flags c2_flags) => this.SetOption("c2_flags", c2_flags.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set component #2 flags (default 0)
/// </summary>
public NoiseFilterGen c2f(NoiseFilterGenC2f c2f) => this.SetOption("c2f", c2f.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set component #3 noise seed (from -1 to INT_MAX) (default -1)
/// </summary>
public NoiseFilterGen c3_seed(int c3_seed) => this.SetOptionRange("c3_seed", c3_seed,-1,INT_MAX);
/// <summary>
///  set component #3 strength (from 0 to 100) (default 0)
/// </summary>
public NoiseFilterGen c3_strength(int c3_strength) => this.SetOptionRange("c3_strength", c3_strength,0,100);
/// <summary>
///  set component #3 strength (from 0 to 100) (default 0)
/// </summary>
public NoiseFilterGen c3s(int c3s) => this.SetOptionRange("c3s", c3s,0,100);
/// <summary>
///  set component #3 flags (default 0)
/// </summary>
public NoiseFilterGen c3_flags(NoiseFilterGenC3_flags c3_flags) => this.SetOption("c3_flags", c3_flags.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set component #3 flags (default 0)
/// </summary>
public NoiseFilterGen c3f(NoiseFilterGenC3f c3f) => this.SetOption("c3f", c3f.GetAttribute<NameAttribute>().Name);
}
public static class NoiseFilterGenExtensions
{
/// <summary>
/// Add noise.
/// </summary>
public static NoiseFilterGen NoiseFilterGen(this ImageMap input0) => new NoiseFilterGen(input0);
}
public enum NoiseFilterGenAll_flags
{
[Name("a")] a,
[Name("p")] p,
[Name("t")] t,
[Name("u")] u,
}

public enum NoiseFilterGenAllf
{
[Name("a")] a,
[Name("p")] p,
[Name("t")] t,
[Name("u")] u,
}

public enum NoiseFilterGenC0_flags
{
[Name("a")] a,
[Name("p")] p,
[Name("t")] t,
[Name("u")] u,
}

public enum NoiseFilterGenC0f
{
[Name("a")] a,
[Name("p")] p,
[Name("t")] t,
[Name("u")] u,
}

public enum NoiseFilterGenC1_flags
{
[Name("a")] a,
[Name("p")] p,
[Name("t")] t,
[Name("u")] u,
}

public enum NoiseFilterGenC1f
{
[Name("a")] a,
[Name("p")] p,
[Name("t")] t,
[Name("u")] u,
}

public enum NoiseFilterGenC2_flags
{
[Name("a")] a,
[Name("p")] p,
[Name("t")] t,
[Name("u")] u,
}

public enum NoiseFilterGenC2f
{
[Name("a")] a,
[Name("p")] p,
[Name("t")] t,
[Name("u")] u,
}

public enum NoiseFilterGenC3_flags
{
[Name("a")] a,
[Name("p")] p,
[Name("t")] t,
[Name("u")] u,
}

public enum NoiseFilterGenC3f
{
[Name("a")] a,
[Name("p")] p,
[Name("t")] t,
[Name("u")] u,
}

}
