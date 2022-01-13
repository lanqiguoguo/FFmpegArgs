namespace FFmpegArgs.Filters.Autogens
{
public class W3fdifFilterGen : ImageToImageFilter,ITimelineSupport,ISliceThreading,ICommandSupport
{
internal W3fdifFilterGen(ImageMap input) : base("w3fdif",input) { AddMapOut(); }
/// <summary>
///  specify the filter (from 0 to 1) (default complex)
/// </summary>
public W3fdifFilterGen filter(W3fdifFilterGenFilter filter) => this.SetOption("filter", filter.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  specify the interlacing mode (from 0 to 1) (default field)
/// </summary>
public W3fdifFilterGen mode(W3fdifFilterGenMode mode) => this.SetOption("mode", mode.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  specify the assumed picture field parity (from -1 to 1) (default auto)
/// </summary>
public W3fdifFilterGen parity(W3fdifFilterGenParity parity) => this.SetOption("parity", parity.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  specify which frames to deinterlace (from 0 to 1) (default all)
/// </summary>
public W3fdifFilterGen deint(W3fdifFilterGenDeint deint) => this.SetOption("deint", deint.GetEnumAttribute<NameAttribute>().Name);
}
public static class W3fdifFilterGenExtensions
{
/// <summary>
/// Apply Martin Weston three field deinterlace.
/// </summary>
public static W3fdifFilterGen W3fdifFilterGen(this ImageMap input0) => new W3fdifFilterGen(input0);
/// <summary>
/// Apply Martin Weston three field deinterlace.
/// </summary>
public static W3fdifFilterGen W3fdifFilterGen(this ImageMap input0,W3fdifFilterGenConfig config)
{
var result = new W3fdifFilterGen(input0);
if(config?.filter != null) result.filter(config.filter.Value);
if(config?.mode != null) result.mode(config.mode.Value);
if(config?.parity != null) result.parity(config.parity.Value);
if(config?.deint != null) result.deint(config.deint.Value);
if(!string.IsNullOrWhiteSpace(config?.TimelineSupport)) result.Enable(config.TimelineSupport);
return result;
}
}
public class W3fdifFilterGenConfig
:ITimelineSupportConfig
{
/// <summary>
///  specify the filter (from 0 to 1) (default complex)
/// </summary>
public W3fdifFilterGenFilter? filter { get; set; }
/// <summary>
///  specify the interlacing mode (from 0 to 1) (default field)
/// </summary>
public W3fdifFilterGenMode? mode { get; set; }
/// <summary>
///  specify the assumed picture field parity (from -1 to 1) (default auto)
/// </summary>
public W3fdifFilterGenParity? parity { get; set; }
/// <summary>
///  specify which frames to deinterlace (from 0 to 1) (default all)
/// </summary>
public W3fdifFilterGenDeint? deint { get; set; }
public string TimelineSupport { get; set; }
}
public enum W3fdifFilterGenFilter
{
[Name("simple")] simple,
[Name("complex")] complex,
}

public enum W3fdifFilterGenMode
{
[Name("frame")] frame,
[Name("field")] field,
}

public enum W3fdifFilterGenParity
{
[Name("tff")] tff,
[Name("bff")] bff,
[Name("auto")] auto,
}

public enum W3fdifFilterGenDeint
{
[Name("all")] all,
[Name("interlaced")] interlaced,
}

}
