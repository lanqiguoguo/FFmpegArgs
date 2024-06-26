namespace FFmpegArgs.Filters.Generated
{
/// <summary>
/// ... pan               A-&gt;A       Remix channels with coefficients (panning).
/// </summary>
public class PanFilterGen : AudioToAudioFilter
{
internal PanFilterGen(AudioMap input) : base("pan",input) { AddMapOut(); }
/// <summary>
/// 
/// </summary>
public PanFilterGen args(string args) => this.SetOption("args",args);
}
/// <summary>
/// </summary>
public static partial class FilterGeneratedExtensions
{
/// <summary>
/// Remix channels with coefficients (panning).
/// </summary>
public static PanFilterGen PanFilterGen(this AudioMap input0) => new PanFilterGen(input0);
}
}
