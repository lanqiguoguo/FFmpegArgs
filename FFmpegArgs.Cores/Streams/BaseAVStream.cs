﻿namespace FFmpegArgs.Cores.Streams
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseAVStream : BaseOptionFlag
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="streamIndex"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal BaseAVStream(int streamIndex)
        {
            if (streamIndex < 0) throw new ArgumentOutOfRangeException(nameof(streamIndex));
            this.StreamIndex = streamIndex;
        }

        /// <summary>
        /// Index of image/audio stream of input/output
        /// </summary>
        public int StreamIndex { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract override string ToString();
    }
}
