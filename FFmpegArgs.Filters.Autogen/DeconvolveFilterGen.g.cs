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
public class DeconvolveFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading
{
internal DeconvolveFilterGen(params ImageMap[] inputs) : base("deconvolve",inputs) { AddMapOut(); }
/// <summary>
///  set planes to deconvolve (from 0 to 15) (default 7)
/// </summary>
public DeconvolveFilterGen planes(int planes) => this.SetOptionRange("planes", planes,0,15);
/// <summary>
///  when to process impulses (from 0 to 1) (default all)
/// </summary>
public DeconvolveFilterGen impulse(DeconvolveFilterGenImpulse impulse) => this.SetOption("impulse", impulse.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set noise (from 0 to 1) (default 1e-07)
/// </summary>
public DeconvolveFilterGen noise(float noise) => this.SetOptionRange("noise", noise,0,1);
}
public static class DeconvolveFilterGenExtensions
{
/// <summary>
/// Deconvolve first video stream with second video stream.
/// </summary>
public static DeconvolveFilterGen DeconvolveFilterGen(this ImageMap input0, ImageMap input1) => new DeconvolveFilterGen(input0, input1);
}
public enum DeconvolveFilterGenImpulse
{
[Name("first")] first,
[Name("all")] all,
}

}