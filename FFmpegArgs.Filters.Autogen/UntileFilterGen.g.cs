namespace FFmpegArgs.Filters.Autogens
{
public class UntileFilterGen : ImageToImageFilter
{
internal UntileFilterGen(ImageMap input) : base("untile",input) { AddMapOut(); }
/// <summary>
///  set grid size (default "6x5")
/// </summary>
public UntileFilterGen layout(Size layout) => this.SetOption("layout",$"{layout.Width}x{layout.Height}");
}
public static class UntileFilterGenExtensions
{
/// <summary>
/// Untile a frame into a sequence of frames.
/// </summary>
public static UntileFilterGen UntileFilterGen(this ImageMap input0) => new UntileFilterGen(input0);
/// <summary>
/// Untile a frame into a sequence of frames.
/// </summary>
public static UntileFilterGen UntileFilterGen(this ImageMap input0,UntileFilterGenConfig config)
{
var result = new UntileFilterGen(input0);
if(config?.layout != null) result.layout(config.layout.Value);
return result;
}
}
public class UntileFilterGenConfig
{
/// <summary>
///  set grid size (default "6x5")
/// </summary>
public Size? layout { get; set; }
}
}
