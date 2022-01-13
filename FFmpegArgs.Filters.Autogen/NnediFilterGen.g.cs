namespace FFmpegArgs.Filters.Autogens
{
public class NnediFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading,ICommandSupport
{
internal NnediFilterGen(ImageMap input) : base("nnedi",input) { AddMapOut(); }
/// <summary>
///  set weights file (default "nnedi3_weights.bin")
/// </summary>
public NnediFilterGen weights(string weights) => this.SetOption("weights",weights);
/// <summary>
///  set which frames to deinterlace (from 0 to 1) (default all)
/// </summary>
public NnediFilterGen deint(NnediFilterGenDeint deint) => this.SetOption("deint", deint.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  set mode of operation (from -2 to 3) (default a)
/// </summary>
public NnediFilterGen field(NnediFilterGenField field) => this.SetOption("field", field.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  set which planes to process (from 0 to 15) (default 7)
/// </summary>
public NnediFilterGen planes(int planes) => this.SetOptionRange("planes", planes,0,15);
/// <summary>
///  set size of local neighborhood around each pixel, used by the predictor neural network (from 0 to 6) (default s32x4)
/// </summary>
public NnediFilterGen nsize(NnediFilterGenNsize nsize) => this.SetOption("nsize", nsize.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  set number of neurons in predictor neural network (from 0 to 4) (default n32)
/// </summary>
public NnediFilterGen nns(NnediFilterGenNns nns) => this.SetOption("nns", nns.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  set quality (from 1 to 2) (default fast)
/// </summary>
public NnediFilterGen qual(NnediFilterGenQual qual) => this.SetOption("qual", qual.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  set which set of weights to use in the predictor (from 0 to 1) (default a)
/// </summary>
public NnediFilterGen etype(NnediFilterGenEtype etype) => this.SetOption("etype", etype.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  set prescreening (from 0 to 4) (default new)
/// </summary>
public NnediFilterGen pscrn(NnediFilterGenPscrn pscrn) => this.SetOption("pscrn", pscrn.GetEnumAttribute<NameAttribute>().Name);
}
public static class NnediFilterGenExtensions
{
/// <summary>
/// Apply neural network edge directed interpolation intra-only deinterlacer.
/// </summary>
public static NnediFilterGen NnediFilterGen(this ImageMap input0) => new NnediFilterGen(input0);
/// <summary>
/// Apply neural network edge directed interpolation intra-only deinterlacer.
/// </summary>
public static NnediFilterGen NnediFilterGen(this ImageMap input0,NnediFilterGenConfig config)
{
var result = new NnediFilterGen(input0);
if(!string.IsNullOrWhiteSpace(config?.weights)) result.weights(config.weights);
if(config?.deint != null) result.deint(config.deint.Value);
if(config?.field != null) result.field(config.field.Value);
if(config?.planes != null) result.planes(config.planes.Value);
if(config?.nsize != null) result.nsize(config.nsize.Value);
if(config?.nns != null) result.nns(config.nns.Value);
if(config?.qual != null) result.qual(config.qual.Value);
if(config?.etype != null) result.etype(config.etype.Value);
if(config?.pscrn != null) result.pscrn(config.pscrn.Value);
if(!string.IsNullOrWhiteSpace(config?.TimelineSupport)) result.Enable(config.TimelineSupport);
return result;
}
}
public class NnediFilterGenConfig
:ITimelineSupportConfig
{
/// <summary>
///  set weights file (default "nnedi3_weights.bin")
/// </summary>
public string weights { get; set; }
/// <summary>
///  set which frames to deinterlace (from 0 to 1) (default all)
/// </summary>
public NnediFilterGenDeint? deint { get; set; }
/// <summary>
///  set mode of operation (from -2 to 3) (default a)
/// </summary>
public NnediFilterGenField? field { get; set; }
/// <summary>
///  set which planes to process (from 0 to 15) (default 7)
/// </summary>
public int? planes { get; set; }
/// <summary>
///  set size of local neighborhood around each pixel, used by the predictor neural network (from 0 to 6) (default s32x4)
/// </summary>
public NnediFilterGenNsize? nsize { get; set; }
/// <summary>
///  set number of neurons in predictor neural network (from 0 to 4) (default n32)
/// </summary>
public NnediFilterGenNns? nns { get; set; }
/// <summary>
///  set quality (from 1 to 2) (default fast)
/// </summary>
public NnediFilterGenQual? qual { get; set; }
/// <summary>
///  set which set of weights to use in the predictor (from 0 to 1) (default a)
/// </summary>
public NnediFilterGenEtype? etype { get; set; }
/// <summary>
///  set prescreening (from 0 to 4) (default new)
/// </summary>
public NnediFilterGenPscrn? pscrn { get; set; }
public string TimelineSupport { get; set; }
}
public enum NnediFilterGenDeint
{
[Name("all")] all,
[Name("interlaced")] interlaced,
}

public enum NnediFilterGenField
{
[Name("af")] af,
[Name("a")] a,
[Name("t")] t,
[Name("b")] b,
[Name("tf")] tf,
[Name("bf")] bf,
}

public enum NnediFilterGenNsize
{
[Name("s8x6")] s8x6,
[Name("s16x6")] s16x6,
[Name("s32x6")] s32x6,
[Name("s48x6")] s48x6,
[Name("s8x4")] s8x4,
[Name("s16x4")] s16x4,
[Name("s32x4")] s32x4,
}

public enum NnediFilterGenNns
{
[Name("n16")] n16,
[Name("n32")] n32,
[Name("n64")] n64,
[Name("n128")] n128,
[Name("n256")] n256,
}

public enum NnediFilterGenQual
{
[Name("fast")] fast,
[Name("slow")] slow,
}

public enum NnediFilterGenEtype
{
[Name("a")] a,
[Name("abs")] abs,
[Name("s")] s,
[Name("mse")] mse,
}

public enum NnediFilterGenPscrn
{
[Name("none")] none,
[Name("original")] original,
[Name("new")] _new,
[Name("new2")] new2,
[Name("new3")] new3,
}

}
