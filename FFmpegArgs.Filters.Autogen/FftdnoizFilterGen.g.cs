namespace FFmpegArgs.Filters.Autogens
{
public class FftdnoizFilterGen : ImageToImageFilter,ITimelineSupport
{
internal FftdnoizFilterGen(ImageMap input) : base("fftdnoiz",input) { AddMapOut(); }
/// <summary>
///  set denoise strength (from 0 to 30) (default 1)
/// </summary>
public FftdnoizFilterGen sigma(float sigma) => this.SetOptionRange("sigma", sigma,0,30);
/// <summary>
///  set amount of denoising (from 0.01 to 1) (default 1)
/// </summary>
public FftdnoizFilterGen amount(float amount) => this.SetOptionRange("amount", amount,0.01,1);
/// <summary>
///  set block log2(size) (from 3 to 6) (default 4)
/// </summary>
public FftdnoizFilterGen block(int block) => this.SetOptionRange("block", block,3,6);
/// <summary>
///  set block overlap (from 0.2 to 0.8) (default 0.5)
/// </summary>
public FftdnoizFilterGen overlap(float overlap) => this.SetOptionRange("overlap", overlap,0.2,0.8);
/// <summary>
///  set number of previous frames for temporal denoising (from 0 to 1) (default 0)
/// </summary>
public FftdnoizFilterGen prev(int prev) => this.SetOptionRange("prev", prev,0,1);
/// <summary>
///  set number of next frames for temporal denoising (from 0 to 1) (default 0)
/// </summary>
public FftdnoizFilterGen next(int next) => this.SetOptionRange("next", next,0,1);
/// <summary>
///  set planes to filter (from 0 to 15) (default 7)
/// </summary>
public FftdnoizFilterGen planes(int planes) => this.SetOptionRange("planes", planes,0,15);
}
public static class FftdnoizFilterGenExtensions
{
/// <summary>
/// Denoise frames using 3D FFT.
/// </summary>
public static FftdnoizFilterGen FftdnoizFilterGen(this ImageMap input0) => new FftdnoizFilterGen(input0);
/// <summary>
/// Denoise frames using 3D FFT.
/// </summary>
public static FftdnoizFilterGen FftdnoizFilterGen(this ImageMap input0,FftdnoizFilterGenConfig config)
{
var result = new FftdnoizFilterGen(input0);
if(config?.sigma != null) result.sigma(config.sigma.Value);
if(config?.amount != null) result.amount(config.amount.Value);
if(config?.block != null) result.block(config.block.Value);
if(config?.overlap != null) result.overlap(config.overlap.Value);
if(config?.prev != null) result.prev(config.prev.Value);
if(config?.next != null) result.next(config.next.Value);
if(config?.planes != null) result.planes(config.planes.Value);
if(!string.IsNullOrWhiteSpace(config?.TimelineSupport)) result.Enable(config.TimelineSupport);
return result;
}
}
public class FftdnoizFilterGenConfig
:ITimelineSupportConfig
{
/// <summary>
///  set denoise strength (from 0 to 30) (default 1)
/// </summary>
public float? sigma { get; set; }
/// <summary>
///  set amount of denoising (from 0.01 to 1) (default 1)
/// </summary>
public float? amount { get; set; }
/// <summary>
///  set block log2(size) (from 3 to 6) (default 4)
/// </summary>
public int? block { get; set; }
/// <summary>
///  set block overlap (from 0.2 to 0.8) (default 0.5)
/// </summary>
public float? overlap { get; set; }
/// <summary>
///  set number of previous frames for temporal denoising (from 0 to 1) (default 0)
/// </summary>
public int? prev { get; set; }
/// <summary>
///  set number of next frames for temporal denoising (from 0 to 1) (default 0)
/// </summary>
public int? next { get; set; }
/// <summary>
///  set planes to filter (from 0 to 15) (default 7)
/// </summary>
public int? planes { get; set; }
public string TimelineSupport { get; set; }
}
}
