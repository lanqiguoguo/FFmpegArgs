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
public class AfftfiltFilterGen : AudioToAudioFilter
{
internal AfftfiltFilterGen(AudioMap input) : base("afftfilt",input) { AddMapOut(); }
/// <summary>
///  set channels real expressions (default "re")
/// </summary>
public AfftfiltFilterGen real(string real) => this.SetOption("real",real);
/// <summary>
///  set channels imaginary expressions (default "im")
/// </summary>
public AfftfiltFilterGen imag(string imag) => this.SetOption("imag",imag);
/// <summary>
///  set window size (from 16 to 131072) (default 4096)
/// </summary>
public AfftfiltFilterGen win_size(int win_size) => this.SetOptionRange("win_size", win_size,16,131072);
/// <summary>
///  set window function (from 0 to 19) (default hann)
/// </summary>
public AfftfiltFilterGen win_func(AfftfiltFilterGenWin_func win_func) => this.SetOption("win_func", win_func.GetAttribute<NameAttribute>().Name);
/// <summary>
///  set window overlap (from 0 to 1) (default 0.75)
/// </summary>
public AfftfiltFilterGen overlap(float overlap) => this.SetOptionRange("overlap", overlap,0,1);
}
public static class AfftfiltFilterGenExtensions
{
/// <summary>
/// Apply arbitrary expressions to samples in frequency domain.
/// </summary>
public static AfftfiltFilterGen AfftfiltFilterGen(this AudioMap input0) => new AfftfiltFilterGen(input0);
}
public enum AfftfiltFilterGenWin_func
{
[Name("rect")] rect,
[Name("bartlett")] bartlett,
[Name("hann")] hann,
[Name("hanning")] hanning,
[Name("hamming")] hamming,
[Name("blackman")] blackman,
[Name("welch")] welch,
[Name("flattop")] flattop,
[Name("bharris")] bharris,
[Name("bnuttall")] bnuttall,
[Name("bhann")] bhann,
[Name("sine")] sine,
[Name("nuttall")] nuttall,
[Name("lanczos")] lanczos,
[Name("gauss")] gauss,
[Name("tukey")] tukey,
[Name("dolph")] dolph,
[Name("cauchy")] cauchy,
[Name("parzen")] parzen,
[Name("poisson")] poisson,
[Name("bohman")] bohman,
}

}