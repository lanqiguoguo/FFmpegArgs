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
public class AtadenoiseFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading,ICommandSupport
{
internal AtadenoiseFilterGen(ImageMap input) : base("atadenoise",input) { AddMapOut(); }
/// <summary>
///  set threshold A for 1st plane (from 0 to 0.3) (default 0.02)
/// </summary>
public AtadenoiseFilterGen _0a(float _0a) => this.SetOptionRange("0a", _0a,0,0.3);
/// <summary>
///  set threshold B for 1st plane (from 0 to 5) (default 0.04)
/// </summary>
public AtadenoiseFilterGen _0b(float _0b) => this.SetOptionRange("0b", _0b,0,5);
/// <summary>
///  set threshold A for 2nd plane (from 0 to 0.3) (default 0.02)
/// </summary>
public AtadenoiseFilterGen _1a(float _1a) => this.SetOptionRange("1a", _1a,0,0.3);
/// <summary>
///  set threshold B for 2nd plane (from 0 to 5) (default 0.04)
/// </summary>
public AtadenoiseFilterGen _1b(float _1b) => this.SetOptionRange("1b", _1b,0,5);
/// <summary>
///  set threshold A for 3rd plane (from 0 to 0.3) (default 0.02)
/// </summary>
public AtadenoiseFilterGen _2a(float _2a) => this.SetOptionRange("2a", _2a,0,0.3);
/// <summary>
///  set threshold B for 3rd plane (from 0 to 5) (default 0.04)
/// </summary>
public AtadenoiseFilterGen _2b(float _2b) => this.SetOptionRange("2b", _2b,0,5);
/// <summary>
///  set how many frames to use (from 5 to 129) (default 9)
/// </summary>
public AtadenoiseFilterGen s(int s) => this.SetOptionRange("s", s,5,129);
/// <summary>
///  set what planes to filter (default 7)
/// </summary>
public AtadenoiseFilterGen p(AtadenoiseFilterGenP p) => this.SetOption("p", p.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set variant of algorithm (from 0 to 1) (default p)
/// </summary>
public AtadenoiseFilterGen a(AtadenoiseFilterGenA a) => this.SetOption("a", a.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set sigma for 1st plane (from 0 to 32767) (default 32767)
/// </summary>
public AtadenoiseFilterGen _0s(float _0s) => this.SetOptionRange("0s", _0s,0,32767);
/// <summary>
///  set sigma for 2nd plane (from 0 to 32767) (default 32767)
/// </summary>
public AtadenoiseFilterGen _1s(float _1s) => this.SetOptionRange("1s", _1s,0,32767);
/// <summary>
///  set sigma for 3rd plane (from 0 to 32767) (default 32767)
/// </summary>
public AtadenoiseFilterGen _2s(float _2s) => this.SetOptionRange("2s", _2s,0,32767);
}
public static class AtadenoiseFilterGenExtensions
{
/// <summary>
/// Apply an Adaptive Temporal Averaging Denoiser.
/// </summary>
public static AtadenoiseFilterGen AtadenoiseFilterGen(this ImageMap input0) => new AtadenoiseFilterGen(input0);
}
public enum AtadenoiseFilterGenP
{
}

public enum AtadenoiseFilterGenA
{
[Name("p")] p,
[Name("s")] s,
}

}