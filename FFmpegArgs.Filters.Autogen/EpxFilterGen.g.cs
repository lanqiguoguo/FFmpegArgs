namespace FFmpegArgs.Filters.Autogens
{
public class EpxFilterGen : ImageToImageFilter,ISliceThreading
{
internal EpxFilterGen(ImageMap input) : base("epx",input) { AddMapOut(); }
/// <summary>
///  set scale factor (from 2 to 3) (default 3)
/// </summary>
public EpxFilterGen n(int n) => this.SetOptionRange("n", n,2,3);
}
public static class EpxFilterGenExtensions
{
/// <summary>
/// Scale the input using EPX algorithm.
/// </summary>
public static EpxFilterGen EpxFilterGen(this ImageMap input0) => new EpxFilterGen(input0);
/// <summary>
/// Scale the input using EPX algorithm.
/// </summary>
public static EpxFilterGen EpxFilterGen(this ImageMap input0,EpxFilterGenConfig config)
{
var result = new EpxFilterGen(input0);
if(config?.n != null) result.n(config.n.Value);
return result;
}
}
public class EpxFilterGenConfig
{
/// <summary>
///  set scale factor (from 2 to 3) (default 3)
/// </summary>
public int? n { get; set; }
}
}
