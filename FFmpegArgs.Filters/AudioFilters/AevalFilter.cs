﻿using FFmpegArgs.Cores.Maps;
using FFmpegArgs.Expressions;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
//aeval AVOptions:
//  exprs             <string>     ..F.A...... set the '|' - separated list of channels expressions
//  channel_layout    <string>     ..F.A...... set channel layout
//  c                 <string>     ..F.A...... set channel layout
namespace FFmpegArgs.Filters.AudioFilters
{
    /// <summary>
    ///  T.. aeval             A->A       Filter audio signal according to a specified expression.<br>
    ///  </br>https://ffmpeg.org/ffmpeg-filters.html#aeval (need more info)
    /// </summary>
    public class AevalFilter : AudioToAudioFilter, ITimelineSupport
    {
        static readonly IEnumerable<string> _variables = new List<string>()
        {
            "ch", "n", "s", "t",
            "nb_in_channels", "nb_out_channels",
            "val"
        };
        readonly Expression expression = new Expression(_variables);
        internal AevalFilter(AudioMap audioMap) : base("aeval", audioMap)
        {
            AddMapOut();
        }
        /// <summary>
        /// Set the ’|’-separated expressions list for each separate channel. <br>
        /// </br>If the number of input channels is greater than the number of expressions, the last specified expression is used for the remaining output channels.
        /// </summary>
        /// <param name="exprs"></param>
        /// <returns></returns>
        public AevalFilter Exprs(params Action<Expression>[] exprs)
            => this.SetOption("exprs", string.Join("|", exprs.Select(x => x.Run(expression))));

        /// <summary>
        /// Set the ’|’-separated expressions list for each separate channel. <br>
        /// </br>If the number of input channels is greater than the number of expressions, the last specified expression is used for the remaining output channels.
        /// </summary>
        /// <param name="exprs"></param>
        /// <returns></returns>
        public AevalFilter Exprs(params string[] exprs)
            => Exprs(exprs.Select(x => x.Expression()).ToArray());

        /// <summary>
        /// Set output channel layout.<br>
        /// </br> If not specified, the channel layout is specified by the number of expressions.<br>
        /// </br> If set to ‘same’, it will use by default the same input channel layout.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public AevalFilter ChannelLayout(string c)
            => this.SetOption("c", c);


    }

    public static class AevalFilterExtensions
    {
        /// <summary>
        /// Modify an audio signal according to the specified expressions.<br>
        /// </br>This filter accepts one or more expressions(one for each channel), which are evaluated and used to modify a corresponding audio signal.
        /// </summary>
        /// <param name="audioMap"></param>
        /// <returns></returns>
        public static AevalFilter AevalFilter(this AudioMap audioMap)
            => new AevalFilter(audioMap);

        /// <summary>
        /// Modify an audio signal according to the specified expressions.<br>
        /// </br>This filter accepts one or more expressions(one for each channel), which are evaluated and used to modify a corresponding audio signal.
        /// </summary>
        /// <param name="audioMap"></param>
        /// <returns></returns>
        public static AevalFilter AevalFilter(this AudioMap audioMap, AevalFilterConfig config)
        {
            var result = new AevalFilter(audioMap);
            if (!string.IsNullOrWhiteSpace(config?.ChannelLayout)) result.ChannelLayout(config.ChannelLayout);
            if (config.Exprs != null) result.Exprs(config.Exprs.ToArray());
            return result;
        }
    }

    public class AevalFilterConfig
    {
        public List<string> Exprs { get; set; }
        public string ChannelLayout { get; set; }
    }
}