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
public DeconvolveFilterGen impulse(DeconvolveFilterGenImpulse impulse) => this.SetOption("impulse", impulse.GetEnumAttribute<NameAttribute>().Name);
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
/// <summary>
/// Deconvolve first video stream with second video stream.
/// </summary>
public static DeconvolveFilterGen DeconvolveFilterGen(this ImageMap input0, ImageMap input1,DeconvolveFilterGenConfig config)
{
var result = new DeconvolveFilterGen(input0, input1);
if(config?.planes != null) result.planes(config.planes.Value);
if(config?.impulse != null) result.impulse(config.impulse.Value);
if(config?.noise != null) result.noise(config.noise.Value);
if(!string.IsNullOrWhiteSpace(config?.TimelineSupport)) result.Enable(config.TimelineSupport);
return result;
}
}
public class DeconvolveFilterGenConfig
:ITimelineSupportConfig
{
/// <summary>
///  set planes to deconvolve (from 0 to 15) (default 7)
/// </summary>
public int? planes { get; set; }
/// <summary>
///  when to process impulses (from 0 to 1) (default all)
/// </summary>
public DeconvolveFilterGenImpulse? impulse { get; set; }
/// <summary>
///  set noise (from 0 to 1) (default 1e-07)
/// </summary>
public float? noise { get; set; }
public string TimelineSupport { get; set; }
}
public enum DeconvolveFilterGenImpulse
{
[Name("first")] first,
[Name("all")] all,
}

}
