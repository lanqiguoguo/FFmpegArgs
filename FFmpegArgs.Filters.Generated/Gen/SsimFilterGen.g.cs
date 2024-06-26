namespace FFmpegArgs.Filters.Generated
{
/// <summary>
/// TS. ssim              VV-&gt;V      Calculate the SSIM between two video streams.
/// </summary>
public class SsimFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading
{
internal SsimFilterGen(params ImageMap[] inputs) : base("ssim",inputs) { AddMapOut(); }
/// <summary>
///  Set file where to store per-frame difference information
/// </summary>
public SsimFilterGen stats_file(string stats_file) => this.SetOption("stats_file",stats_file);
/// <summary>
///  Set file where to store per-frame difference information
/// </summary>
public SsimFilterGen f(string f) => this.SetOption("f",f);
}
/// <summary>
/// </summary>
public static partial class FilterGeneratedExtensions
{
/// <summary>
/// Calculate the SSIM between two video streams.
/// </summary>
public static SsimFilterGen SsimFilterGen(this ImageMap input0, ImageMap input1) => new SsimFilterGen(input0, input1);
}
}
