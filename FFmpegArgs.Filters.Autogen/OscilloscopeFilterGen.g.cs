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
public class OscilloscopeFilterGen : ImageToImageFilter,ITimelineSupport,ICommandSupport
{
internal OscilloscopeFilterGen(ImageMap input) : base("oscilloscope",input) { AddMapOut(); }
/// <summary>
///  set scope x position (from 0 to 1) (default 0.5)
/// </summary>
public OscilloscopeFilterGen x(float x) => this.SetOptionRange("x", x,0,1);
/// <summary>
///  set scope y position (from 0 to 1) (default 0.5)
/// </summary>
public OscilloscopeFilterGen y(float y) => this.SetOptionRange("y", y,0,1);
/// <summary>
///  set scope size (from 0 to 1) (default 0.8)
/// </summary>
public OscilloscopeFilterGen s(float s) => this.SetOptionRange("s", s,0,1);
/// <summary>
///  set scope tilt (from 0 to 1) (default 0.5)
/// </summary>
public OscilloscopeFilterGen t(float t) => this.SetOptionRange("t", t,0,1);
/// <summary>
///  set trace opacity (from 0 to 1) (default 0.8)
/// </summary>
public OscilloscopeFilterGen o(float o) => this.SetOptionRange("o", o,0,1);
/// <summary>
///  set trace x position (from 0 to 1) (default 0.5)
/// </summary>
public OscilloscopeFilterGen tx(float tx) => this.SetOptionRange("tx", tx,0,1);
/// <summary>
///  set trace y position (from 0 to 1) (default 0.9)
/// </summary>
public OscilloscopeFilterGen ty(float ty) => this.SetOptionRange("ty", ty,0,1);
/// <summary>
///  set trace width (from 0.1 to 1) (default 0.8)
/// </summary>
public OscilloscopeFilterGen tw(float tw) => this.SetOptionRange("tw", tw,0.1,1);
/// <summary>
///  set trace height (from 0.1 to 1) (default 0.3)
/// </summary>
public OscilloscopeFilterGen th(float th) => this.SetOptionRange("th", th,0.1,1);
/// <summary>
///  set components to trace (from 0 to 15) (default 7)
/// </summary>
public OscilloscopeFilterGen c(int c) => this.SetOptionRange("c", c,0,15);
/// <summary>
///  draw trace grid (default true)
/// </summary>
public OscilloscopeFilterGen g(bool flag) => this.SetOption("g",flag.ToFFmpegFlag());
/// <summary>
///  draw statistics (default true)
/// </summary>
public OscilloscopeFilterGen st(bool flag) => this.SetOption("st",flag.ToFFmpegFlag());
/// <summary>
///  draw scope (default true)
/// </summary>
public OscilloscopeFilterGen sc(bool flag) => this.SetOption("sc",flag.ToFFmpegFlag());
}
public static class OscilloscopeFilterGenExtensions
{
/// <summary>
/// 2D Video Oscilloscope.
/// </summary>
public static OscilloscopeFilterGen OscilloscopeFilterGen(this ImageMap input) => new OscilloscopeFilterGen(input);
}
}
