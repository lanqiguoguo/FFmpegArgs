namespace FFmpegArgs.Filters.Autogens
{
/// <summary>
/// ... haldclutsrc       |->V       Provide an identity Hald CLUT.
/// </summary>
public class HaldclutsrcFilterGen : SourceImageFilter
{
internal HaldclutsrcFilterGen(BaseFilterGraph input) : base("haldclutsrc",input) { AddMapOut(); }
/// <summary>
///  set level (from 2 to 16) (default 6)
/// </summary>
public HaldclutsrcFilterGen level(int level) => this.SetOptionRange("level", level,2,16);
/// <summary>
///  set video rate (default "25")
/// </summary>
public HaldclutsrcFilterGen rate(Rational rate) => this.SetOption("rate",rate);
/// <summary>
///  set video duration (default -0.000001)
/// </summary>
public HaldclutsrcFilterGen duration(TimeSpan duration) => this.SetOptionRange("duration",duration,TimeSpan.Zero,TimeSpan.MaxValue);
/// <summary>
///  set video sample aspect ratio (from 0 to INT_MAX) (default 1/1)
/// </summary>
public HaldclutsrcFilterGen sar(Rational sar) => this.SetOption("sar",sar.Check(0,INT_MAX));
}
/// <summary>
/// </summary>
public static class HaldclutsrcFilterGenExtensions
{
/// <summary>
/// Provide an identity Hald CLUT.
/// </summary>
public static HaldclutsrcFilterGen HaldclutsrcFilterGen(this BaseFilterGraph input0) => new HaldclutsrcFilterGen(input0);
}
}
