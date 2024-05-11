﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFmpegArgs.Filters.BaseFilters
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageToAudioFilter : BaseFilter<ImageMap, AudioMap>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterName"></param>
        /// <param name="mapsIn"></param>
        protected ImageToAudioFilter(string filterName, params ImageMap[] mapsIn) : base(filterName, mapsIn)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        protected override void AddMapOut()
            => _mapsOut.Add(new AudioMap(FilterGraph, $"f_{FilterIndex}"));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        protected override void AddMapOut(int index)
            => _mapsOut.Add(new AudioMap(FilterGraph, $"f_{FilterIndex}_{index}"));
    }
}
