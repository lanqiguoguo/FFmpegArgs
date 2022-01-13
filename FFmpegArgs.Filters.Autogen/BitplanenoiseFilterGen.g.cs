namespace FFmpegArgs.Filters.Autogens
{
public class BitplanenoiseFilterGen : ImageToImageFilter,ITimelineSupport
{
internal BitplanenoiseFilterGen(ImageMap input) : base("bitplanenoise",input) { AddMapOut(); }
/// <summary>
///  set bit plane to use for measuring noise (from 1 to 16) (default 1)
/// </summary>
public BitplanenoiseFilterGen bitplane(int bitplane) => this.SetOptionRange("bitplane", bitplane,1,16);
/// <summary>
///  show noisy pixels (default false)
/// </summary>
public BitplanenoiseFilterGen filter(bool filter) => this.SetOption("filter",filter.ToFFmpegFlag());
}
public static class BitplanenoiseFilterGenExtensions
{
/// <summary>
/// Measure bit plane noise.
/// </summary>
public static BitplanenoiseFilterGen BitplanenoiseFilterGen(this ImageMap input0) => new BitplanenoiseFilterGen(input0);
/// <summary>
/// Measure bit plane noise.
/// </summary>
public static BitplanenoiseFilterGen BitplanenoiseFilterGen(this ImageMap input0,BitplanenoiseFilterGenConfig config)
{
var result = new BitplanenoiseFilterGen(input0);
if(config?.bitplane != null) result.bitplane(config.bitplane.Value);
if(config?.filter != null) result.filter(config.filter.Value);
if(!string.IsNullOrWhiteSpace(config?.TimelineSupport)) result.Enable(config.TimelineSupport);
return result;
}
}
public class BitplanenoiseFilterGenConfig
:ITimelineSupportConfig
{
/// <summary>
///  set bit plane to use for measuring noise (from 1 to 16) (default 1)
/// </summary>
public int? bitplane { get; set; }
/// <summary>
///  show noisy pixels (default false)
/// </summary>
public bool? filter { get; set; }
public string TimelineSupport { get; set; }
}
}
