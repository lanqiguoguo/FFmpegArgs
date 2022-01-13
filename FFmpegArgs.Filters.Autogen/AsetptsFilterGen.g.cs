namespace FFmpegArgs.Filters.Autogens
{
public class AsetptsFilterGen : AudioToAudioFilter
{
internal AsetptsFilterGen(AudioMap input) : base("asetpts",input) { AddMapOut(); }
/// <summary>
///  Expression determining the frame timestamp (default "PTS")
/// </summary>
public AsetptsFilterGen expr(string expr) => this.SetOption("expr",expr);
}
public static class AsetptsFilterGenExtensions
{
/// <summary>
/// Set PTS for the output audio frame.
/// </summary>
public static AsetptsFilterGen AsetptsFilterGen(this AudioMap input0) => new AsetptsFilterGen(input0);
/// <summary>
/// Set PTS for the output audio frame.
/// </summary>
public static AsetptsFilterGen AsetptsFilterGen(this AudioMap input0,AsetptsFilterGenConfig config)
{
var result = new AsetptsFilterGen(input0);
if(!string.IsNullOrWhiteSpace(config?.expr)) result.expr(config.expr);
return result;
}
}
public class AsetptsFilterGenConfig
{
/// <summary>
///  Expression determining the frame timestamp (default "PTS")
/// </summary>
public string expr { get; set; }
}
}
