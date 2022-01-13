namespace FFmpegArgs.Filters.Autogens
{
public class VignetteFilterGen : ImageToImageFilter,ITimelineSupport
{
internal VignetteFilterGen(ImageMap input) : base("vignette",input) { AddMapOut(); }
/// <summary>
///  set lens angle (default "PI/5")
/// </summary>
public VignetteFilterGen angle(string angle) => this.SetOption("angle",angle);
/// <summary>
///  set circle center position on x-axis (default "w/2")
/// </summary>
public VignetteFilterGen x0(string x0) => this.SetOption("x0",x0);
/// <summary>
///  set circle center position on y-axis (default "h/2")
/// </summary>
public VignetteFilterGen y0(string y0) => this.SetOption("y0",y0);
/// <summary>
///  set forward/backward mode (from 0 to 1) (default forward)
/// </summary>
public VignetteFilterGen mode(VignetteFilterGenMode mode) => this.SetOption("mode", mode.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  specify when to evaluate expressions (from 0 to 1) (default init)
/// </summary>
public VignetteFilterGen eval(VignetteFilterGenEval eval) => this.SetOption("eval", eval.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  set dithering (default true)
/// </summary>
public VignetteFilterGen dither(bool dither) => this.SetOption("dither",dither.ToFFmpegFlag());
/// <summary>
///  set aspect ratio (from 0 to DBL_MAX) (default 1/1)
/// </summary>
public VignetteFilterGen aspect(Rational aspect) => this.SetOption("aspect",aspect.Check(0,DBL_MAX));
}
public static class VignetteFilterGenExtensions
{
/// <summary>
/// Make or reverse a vignette effect.
/// </summary>
public static VignetteFilterGen VignetteFilterGen(this ImageMap input0) => new VignetteFilterGen(input0);
/// <summary>
/// Make or reverse a vignette effect.
/// </summary>
public static VignetteFilterGen VignetteFilterGen(this ImageMap input0,VignetteFilterGenConfig config)
{
var result = new VignetteFilterGen(input0);
if(!string.IsNullOrWhiteSpace(config?.angle)) result.angle(config.angle);
if(!string.IsNullOrWhiteSpace(config?.x0)) result.x0(config.x0);
if(!string.IsNullOrWhiteSpace(config?.y0)) result.y0(config.y0);
if(config?.mode != null) result.mode(config.mode.Value);
if(config?.eval != null) result.eval(config.eval.Value);
if(config?.dither != null) result.dither(config.dither.Value);
if(config?.aspect != null) result.aspect(config.aspect);
if(!string.IsNullOrWhiteSpace(config?.TimelineSupport)) result.Enable(config.TimelineSupport);
return result;
}
}
public class VignetteFilterGenConfig
:ITimelineSupportConfig
{
/// <summary>
///  set lens angle (default "PI/5")
/// </summary>
public string angle { get; set; }
/// <summary>
///  set circle center position on x-axis (default "w/2")
/// </summary>
public string x0 { get; set; }
/// <summary>
///  set circle center position on y-axis (default "h/2")
/// </summary>
public string y0 { get; set; }
/// <summary>
///  set forward/backward mode (from 0 to 1) (default forward)
/// </summary>
public VignetteFilterGenMode? mode { get; set; }
/// <summary>
///  specify when to evaluate expressions (from 0 to 1) (default init)
/// </summary>
public VignetteFilterGenEval? eval { get; set; }
/// <summary>
///  set dithering (default true)
/// </summary>
public bool? dither { get; set; }
/// <summary>
///  set aspect ratio (from 0 to DBL_MAX) (default 1/1)
/// </summary>
public Rational aspect { get; set; }
public string TimelineSupport { get; set; }
}
public enum VignetteFilterGenMode
{
[Name("forward")] forward,
[Name("backward")] backward,
}

public enum VignetteFilterGenEval
{
[Name("init")] init,
[Name("frame")] frame,
}

}
