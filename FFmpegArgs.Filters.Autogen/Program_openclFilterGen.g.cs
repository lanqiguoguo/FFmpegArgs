namespace FFmpegArgs.Filters.Autogens
{
public class Program_openclFilterGen : SourceImageFilter
{
internal Program_openclFilterGen(FilterGraph input) : base("program_opencl",input) { AddMapOut(); }
/// <summary>
///  OpenCL program source file
/// </summary>
public Program_openclFilterGen source(string source) => this.SetOption("source",source);
/// <summary>
///  Kernel name in program
/// </summary>
public Program_openclFilterGen kernel(string kernel) => this.SetOption("kernel",kernel);
/// <summary>
///  Number of inputs (from 1 to INT_MAX) (default 1)
/// </summary>
public Program_openclFilterGen inputs(int inputs) => this.SetOptionRange("inputs", inputs,1,INT_MAX);
/// <summary>
///  Video size
/// </summary>
public Program_openclFilterGen size(Size size) => this.SetOption("size",$"{size.Width}x{size.Height}");
}
public static class Program_openclFilterGenExtensions
{
/// <summary>
/// Filter video using an OpenCL program
/// </summary>
public static Program_openclFilterGen Program_openclFilterGen(this FilterGraph input0) => new Program_openclFilterGen(input0);
/// <summary>
/// Filter video using an OpenCL program
/// </summary>
public static Program_openclFilterGen Program_openclFilterGen(this FilterGraph input0,Program_openclFilterGenConfig config)
{
var result = new Program_openclFilterGen(input0);
if(!string.IsNullOrWhiteSpace(config?.source)) result.source(config.source);
if(!string.IsNullOrWhiteSpace(config?.kernel)) result.kernel(config.kernel);
if(config?.inputs != null) result.inputs(config.inputs.Value);
if(config?.size != null) result.size(config.size.Value);
return result;
}
}
public class Program_openclFilterGenConfig
{
/// <summary>
///  OpenCL program source file
/// </summary>
public string source { get; set; }
/// <summary>
///  Kernel name in program
/// </summary>
public string kernel { get; set; }
/// <summary>
///  Number of inputs (from 1 to INT_MAX) (default 1)
/// </summary>
public int? inputs { get; set; }
/// <summary>
///  Video size
/// </summary>
public Size? size { get; set; }
}
}
