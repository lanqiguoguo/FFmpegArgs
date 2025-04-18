namespace FFmpegArgs.Filters.Generated
{
/// <summary>
/// ... channelsplit      A-&gt;N       Split audio into per-channel streams.
/// </summary>
public class ChannelsplitFilterGen : AudioToAudioFilter
{
internal ChannelsplitFilterGen(int outputCount, AudioMap input) : base("channelsplit",input) { AddMultiMapOut(outputCount); }
/// <summary>
///  Input channel layout. (default &quot;stereo&quot;)
/// </summary>
public ChannelsplitFilterGen channel_layout(ChannelLayout channel_layout) => this.SetOption("channel_layout",channel_layout.GetEnumAttribute<NameAttribute>().Name);
/// <summary>
///  Channels to extract. (default &quot;all&quot;)
/// </summary>
public ChannelsplitFilterGen channels(string channels) => this.SetOption("channels",channels);
}
/// <summary>
/// </summary>
public static partial class FilterGeneratedExtensions
{
/// <summary>
/// Split audio into per-channel streams.
/// </summary>
public static ChannelsplitFilterGen ChannelsplitFilterGen(this AudioMap input0, int outputCount) => new ChannelsplitFilterGen(outputCount, input0);
}
}
