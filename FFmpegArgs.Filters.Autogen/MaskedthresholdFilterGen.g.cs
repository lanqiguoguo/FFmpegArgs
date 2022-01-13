namespace FFmpegArgs.Filters.Autogens
{
public class MaskedthresholdFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading,ICommandSupport
{
internal MaskedthresholdFilterGen(params ImageMap[] inputs) : base("maskedthreshold",inputs) { AddMapOut(); }
/// <summary>
///  set threshold (from 0 to 65535) (default 1)
/// </summary>
public MaskedthresholdFilterGen threshold(int threshold) => this.SetOptionRange("threshold", threshold,0,65535);
/// <summary>
///  set planes (from 0 to 15) (default 15)
/// </summary>
public MaskedthresholdFilterGen planes(int planes) => this.SetOptionRange("planes", planes,0,15);
}
public static class MaskedthresholdFilterGenExtensions
{
/// <summary>
/// Pick pixels comparing absolute difference of two streams with threshold.
/// </summary>
public static MaskedthresholdFilterGen MaskedthresholdFilterGen(this ImageMap input0, ImageMap input1) => new MaskedthresholdFilterGen(input0, input1);
/// <summary>
/// Pick pixels comparing absolute difference of two streams with threshold.
/// </summary>
public static MaskedthresholdFilterGen MaskedthresholdFilterGen(this ImageMap input0, ImageMap input1,MaskedthresholdFilterGenConfig config)
{
var result = new MaskedthresholdFilterGen(input0, input1);
if(config?.threshold != null) result.threshold(config.threshold.Value);
if(config?.planes != null) result.planes(config.planes.Value);
if(!string.IsNullOrWhiteSpace(config?.TimelineSupport)) result.Enable(config.TimelineSupport);
return result;
}
}
public class MaskedthresholdFilterGenConfig
:ITimelineSupportConfig
{
/// <summary>
///  set threshold (from 0 to 65535) (default 1)
/// </summary>
public int? threshold { get; set; }
/// <summary>
///  set planes (from 0 to 15) (default 15)
/// </summary>
public int? planes { get; set; }
public string TimelineSupport { get; set; }
}
}
