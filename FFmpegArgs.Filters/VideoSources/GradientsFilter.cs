﻿using FFmpegArgs.Filters.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFmpegArgs.Filters.VideoSources
{
  /// <summary>
  /// .S. gradients         |->V       Draw a gradients.<br></br>
  /// https://ffmpeg.org/ffmpeg-filters.html#gradients
  /// </summary>
  public class GradientsFilter : SourceImageFilter , ISliceThreading
  {
    internal GradientsFilter(FilterGraph filterGraph) : base("gradients", filterGraph) 
    {
      AddMapOut();
    }

    /// <summary>
    /// Set frame size. <br></br>
    /// Default value is "640x480".
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public GradientsFilter Size(VideoSizeUtils s)
      => this.SetOption("s",s.GetAttribute<NameAttribute>().Name);

    /// <summary>
    /// Set frame size. <br></br>
    /// Default value is "640x480".
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public GradientsFilter Size(Size s)
      => this.SetOption("s",$"{s.Width}x{s.Height}");

    /// <summary>
    /// Set frame rate, expressed as number of frames per second. Default value is "25".
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public GradientsFilter Rate(int r)
      => this.SetOptionRange("r", r, 0, int.MaxValue);

    /// <summary>
    /// Set 8 colors. Default values for colors is to pick random one.
    /// </summary>
    /// <param name="colorIndex"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public GradientsFilter Color(GradientsColorIndex colorIndex, Color color)
      => this.SetOption(colorIndex.ToString(), color.ToHexStringRGBA());

    /// <summary>
    /// Set gradient line source and destination points. If negative or out of range, random ones are picked.
    /// </summary>
    /// <param name="gradientsPoint"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public GradientsFilter Points(GradientsPoint gradientsPoint,int val)
      => this.SetOptionRange(gradientsPoint.ToString(), val,0,int.MaxValue);

    /// <summary>
    /// Set number of colors to use at once. Allowed range is from 2 to 8. Default value is 2.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public GradientsFilter NbColors(int n)
      => this.SetOptionRange("n", n, 2, 8);

    /// <summary>
    /// Set seed for picking gradient line points.
    /// </summary>
    /// <param name="seed"></param>
    /// <returns></returns>
    public GradientsFilter Seed(uint seed)
      => this.SetOptionRange("seed", seed, 0, long.MaxValue);

    /// <summary>
    /// Set the duration of the sourced video<br></br>
    /// If not specified, or the expressed duration is negative, the video is supposed to be generated forever.
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public GradientsFilter Duration(TimeSpan d)
      => this.SetOptionRange("d", d, TimeSpan.Zero, TimeSpan.MaxValue);

    /// <summary>
    /// Set speed of gradients rotation.
    /// </summary>
    /// <param name="speed"></param>
    /// <returns></returns>
    public GradientsFilter Speed(float speed)
      => this.SetOptionRange("speed",speed,float.MinValue,float.MaxValue);
  }

  public static class GradientsFilterExtensions
  {
    /// <summary>
    /// Generate several gradients.
    /// </summary>
    /// <param name="filterGraph"></param>
    /// <returns></returns>
    public static GradientsFilter GradientsFilter(this FilterGraph filterGraph)
      => new GradientsFilter(filterGraph);
  }

  public enum GradientsColorIndex
  {
    c0,
    c1,
    c2,
    c3,
    c4,
    c5,
    c6,
    c7,
  }

  public enum GradientsPoint
  {
    x0,
    y0,
    x1,
    y1,
  }
}
