namespace FFmpegArgs.Filters.Generated
{
/// <summary>
/// ... cellauto          |-&gt;V       Create pattern generated by an elementary cellular automaton.
/// </summary>
public class CellautoFilterGen : SourceToImageFilter
{
internal CellautoFilterGen(IImageFilterGraph input) : base("cellauto",input) { AddMapOut(); }
/// <summary>
///  read initial pattern from file
/// </summary>
public CellautoFilterGen filename(string filename) => this.SetOption("filename",filename);
/// <summary>
///  set initial pattern
/// </summary>
public CellautoFilterGen pattern(string pattern) => this.SetOption("pattern",pattern);
/// <summary>
///  set video rate (default &quot;25&quot;)
/// </summary>
public CellautoFilterGen rate(Rational rate) => this.SetOption("rate",rate);
/// <summary>
///  set video size
/// </summary>
public CellautoFilterGen size(Size size) => this.SetOption("size",$"{size.Width}x{size.Height}");
/// <summary>
///  set rule (from 0 to 255) (default 110)
/// </summary>
public CellautoFilterGen rule(int rule) => this.SetOptionRange("rule", rule,0,255);
/// <summary>
///  set fill ratio for filling initial grid randomly (from 0 to 1) (default 0.618034)
/// </summary>
public CellautoFilterGen random_fill_ratio(double random_fill_ratio) => this.SetOptionRange("random_fill_ratio", random_fill_ratio,0,1);
/// <summary>
///  set fill ratio for filling initial grid randomly (from 0 to 1) (default 0.618034)
/// </summary>
public CellautoFilterGen ratio(double ratio) => this.SetOptionRange("ratio", ratio,0,1);
/// <summary>
///  set the seed for filling the initial grid randomly (from -1 to UINT32_MAX) (default -1)
/// </summary>
public CellautoFilterGen random_seed(long random_seed) => this.SetOptionRange("random_seed", random_seed,-1,UINT32_MAX);
/// <summary>
///  set the seed for filling the initial grid randomly (from -1 to UINT32_MAX) (default -1)
/// </summary>
public CellautoFilterGen seed(long seed) => this.SetOptionRange("seed", seed,-1,UINT32_MAX);
/// <summary>
///  scroll pattern downward (default true)
/// </summary>
public CellautoFilterGen scroll(bool scroll) => this.SetOption("scroll",scroll.ToFFmpegFlag());
/// <summary>
///  start filling the whole video (default false)
/// </summary>
public CellautoFilterGen start_full(bool start_full) => this.SetOption("start_full",start_full.ToFFmpegFlag());
/// <summary>
///  start filling the whole video (default true)
/// </summary>
public CellautoFilterGen full(bool full) => this.SetOption("full",full.ToFFmpegFlag());
/// <summary>
///  stitch boundaries (default true)
/// </summary>
public CellautoFilterGen stitch(bool stitch) => this.SetOption("stitch",stitch.ToFFmpegFlag());
}
/// <summary>
/// </summary>
public static partial class FilterGeneratedExtensions
{
/// <summary>
/// Create pattern generated by an elementary cellular automaton.
/// </summary>
public static CellautoFilterGen CellautoFilterGen(this IImageFilterGraph input0) => new CellautoFilterGen(input0);
}
}
