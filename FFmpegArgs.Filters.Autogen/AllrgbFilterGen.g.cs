namespace FFmpegArgs.Filters.Autogens
{
public class AllrgbFilterGen : SourceImageFilter
{
internal AllrgbFilterGen(FilterGraph input) : base("allrgb",input) { AddMapOut(); }
/// <summary>
///  set video rate (default "25")
/// </summary>
public AllrgbFilterGen rate(Rational rate) => this.SetOption("rate",rate);
/// <summary>
///  set video duration (default -0.000001)
/// </summary>
public AllrgbFilterGen duration(TimeSpan duration) => this.SetOptionRange("duration",duration,TimeSpan.Zero,TimeSpan.MaxValue);
/// <summary>
///  set video sample aspect ratio (from 0 to INT_MAX) (default 1/1)
/// </summary>
public AllrgbFilterGen sar(Rational sar) => this.SetOption("sar",sar.Check(0,INT_MAX));
}
public static class AllrgbFilterGenExtensions
{
/// <summary>
/// Generate all RGB colors.
/// </summary>
public static AllrgbFilterGen AllrgbFilterGen(this FilterGraph input0) => new AllrgbFilterGen(input0);
/// <summary>
/// Generate all RGB colors.
/// </summary>
public static AllrgbFilterGen AllrgbFilterGen(this FilterGraph input0,AllrgbFilterGenConfig config)
{
var result = new AllrgbFilterGen(input0);
if(config?.rate != null) result.rate(config.rate);
if(config?.duration != null) result.duration(config.duration.Value);
if(config?.sar != null) result.sar(config.sar);
return result;
}
}
public class AllrgbFilterGenConfig
{
/// <summary>
///  set video rate (default "25")
/// </summary>
public Rational rate { get; set; }
/// <summary>
///  set video duration (default -0.000001)
/// </summary>
public TimeSpan? duration { get; set; }
/// <summary>
///  set video sample aspect ratio (from 0 to INT_MAX) (default 1/1)
/// </summary>
public Rational sar { get; set; }
}
}
