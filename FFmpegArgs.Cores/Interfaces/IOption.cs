﻿namespace FFmpegArgs.Cores.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOption
    {
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<KeyValuePair<string, string>> Options { get; }
    }
}
