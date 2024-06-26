namespace FFmpegArgs.Filters.Generated
{
/// <summary>
/// ... aecho             A-&gt;A       Add echoing to the audio.
/// </summary>
public class AechoFilterGen : AudioToAudioFilter
{
internal AechoFilterGen(AudioMap input) : base("aecho",input) { AddMapOut(); }
/// <summary>
///  set signal input gain (from 0 to 1) (default 0.6)
/// </summary>
public AechoFilterGen in_gain(float in_gain) => this.SetOptionRange("in_gain", in_gain,0,1);
/// <summary>
///  set signal output gain (from 0 to 1) (default 0.3)
/// </summary>
public AechoFilterGen out_gain(float out_gain) => this.SetOptionRange("out_gain", out_gain,0,1);
/// <summary>
///  set list of signal delays (default &quot;1000&quot;)
/// </summary>
public AechoFilterGen delays(string delays) => this.SetOption("delays",delays);
/// <summary>
///  set list of signal decays (default &quot;0.5&quot;)
/// </summary>
public AechoFilterGen decays(string decays) => this.SetOption("decays",decays);
}
/// <summary>
/// </summary>
public static partial class FilterGeneratedExtensions
{
/// <summary>
/// Add echoing to the audio.
/// </summary>
public static AechoFilterGen AechoFilterGen(this AudioMap input0) => new AechoFilterGen(input0);
}
}
