namespace FFmpegArgs.Filters.Autogens
{
public class Deinterlace_qsvFilterGen : ImageToImageFilter
{
internal Deinterlace_qsvFilterGen(ImageMap input) : base("deinterlace_qsv",input) { AddMapOut(); }
/// <summary>
///  set deinterlace mode (from 1 to 2) (default advanced)
/// </summary>
public Deinterlace_qsvFilterGen mode(Deinterlace_qsvFilterGenMode mode) => this.SetOption("mode", mode.GetEnumAttribute<NameAttribute>().Name);
}
public static class Deinterlace_qsvFilterGenExtensions
{
/// <summary>
/// QuickSync video deinterlacing
/// </summary>
public static Deinterlace_qsvFilterGen Deinterlace_qsvFilterGen(this ImageMap input0) => new Deinterlace_qsvFilterGen(input0);
/// <summary>
/// QuickSync video deinterlacing
/// </summary>
public static Deinterlace_qsvFilterGen Deinterlace_qsvFilterGen(this ImageMap input0,Deinterlace_qsvFilterGenConfig config)
{
var result = new Deinterlace_qsvFilterGen(input0);
if(config?.mode != null) result.mode(config.mode.Value);
return result;
}
}
public class Deinterlace_qsvFilterGenConfig
{
/// <summary>
///  set deinterlace mode (from 1 to 2) (default advanced)
/// </summary>
public Deinterlace_qsvFilterGenMode? mode { get; set; }
}
public enum Deinterlace_qsvFilterGenMode
{
[Name("bob")] bob,
[Name("advanced")] advanced,
}

}
