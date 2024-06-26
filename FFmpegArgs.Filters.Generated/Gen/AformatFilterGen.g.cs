namespace FFmpegArgs.Filters.Generated
{
/// <summary>
/// ... aformat           A-&gt;A       Convert the input audio to one of the specified formats.
/// </summary>
public class AformatFilterGen : AudioToAudioFilter
{
internal AformatFilterGen(AudioMap input) : base("aformat",input) { AddMapOut(); }
/// <summary>
///  A &#39;|&#39;-separated list of sample formats.
/// </summary>
public AformatFilterGen sample_fmts(string sample_fmts) => this.SetOption("sample_fmts",sample_fmts);
/// <summary>
///  A &#39;|&#39;-separated list of sample formats.
/// </summary>
public AformatFilterGen f(string f) => this.SetOption("f",f);
/// <summary>
///  A &#39;|&#39;-separated list of sample rates.
/// </summary>
public AformatFilterGen sample_rates(string sample_rates) => this.SetOption("sample_rates",sample_rates);
/// <summary>
///  A &#39;|&#39;-separated list of sample rates.
/// </summary>
public AformatFilterGen r(string r) => this.SetOption("r",r);
/// <summary>
///  A &#39;|&#39;-separated list of channel layouts.
/// </summary>
public AformatFilterGen channel_layouts(string channel_layouts) => this.SetOption("channel_layouts",channel_layouts);
/// <summary>
///  A &#39;|&#39;-separated list of channel layouts.
/// </summary>
public AformatFilterGen cl(string cl) => this.SetOption("cl",cl);
}
/// <summary>
/// </summary>
public static partial class FilterGeneratedExtensions
{
/// <summary>
/// Convert the input audio to one of the specified formats.
/// </summary>
public static AformatFilterGen AformatFilterGen(this AudioMap input0) => new AformatFilterGen(input0);
}
}
