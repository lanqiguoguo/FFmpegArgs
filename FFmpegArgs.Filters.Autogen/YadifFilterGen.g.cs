namespace FFmpegArgs.Filters.Autogens
{
public class YadifFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading
{
internal YadifFilterGen(ImageMap input) : base("yadif",input) { AddMapOut(); }
/// <summary>
///  specify the interlacing mode (from 0 to 3) (default send_frame)
/// </summary>
public YadifFilterGen mode(YadifFilterGenMode mode) => this.SetOption("mode", mode.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  specify the assumed picture field parity (from -1 to 1) (default auto)
/// </summary>
public YadifFilterGen parity(YadifFilterGenParity parity) => this.SetOption("parity", parity.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  specify which frames to deinterlace (from 0 to 1) (default all)
/// </summary>
public YadifFilterGen deint(YadifFilterGenDeint deint) => this.SetOption("deint", deint.GetEnumAttribute<NameAttribute>().Name);
}
public static class YadifFilterGenExtensions
{
/// <summary>
/// Deinterlace the input image.
/// </summary>
public static YadifFilterGen YadifFilterGen(this ImageMap input0) => new YadifFilterGen(input0);
/// <summary>
/// Deinterlace the input image.
/// </summary>
public static YadifFilterGen YadifFilterGen(this ImageMap input0,YadifFilterGenConfig config)
{
var result = new YadifFilterGen(input0);
if(config?.mode != null) result.mode(config.mode.Value);
if(config?.parity != null) result.parity(config.parity.Value);
if(config?.deint != null) result.deint(config.deint.Value);
if(!string.IsNullOrWhiteSpace(config?.TimelineSupport)) result.Enable(config.TimelineSupport);
return result;
}
}
public class YadifFilterGenConfig
:ITimelineSupportConfig
{
/// <summary>
///  specify the interlacing mode (from 0 to 3) (default send_frame)
/// </summary>
public YadifFilterGenMode? mode { get; set; }
/// <summary>
///  specify the assumed picture field parity (from -1 to 1) (default auto)
/// </summary>
public YadifFilterGenParity? parity { get; set; }
/// <summary>
///  specify which frames to deinterlace (from 0 to 1) (default all)
/// </summary>
public YadifFilterGenDeint? deint { get; set; }
public string TimelineSupport { get; set; }
}
public enum YadifFilterGenMode
{
[Name("send_frame")] send_frame,
[Name("send_field")] send_field,
[Name("send_frame_nospatial")] send_frame_nospatial,
[Name("send_field_nospatial")] send_field_nospatial,
}

public enum YadifFilterGenParity
{
[Name("tff")] tff,
[Name("bff")] bff,
[Name("auto")] auto,
}

public enum YadifFilterGenDeint
{
[Name("all")] all,
[Name("interlaced")] interlaced,
}

}
