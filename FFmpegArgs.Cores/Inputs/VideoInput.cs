﻿namespace FFmpegArgs.Cores.Inputs
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class VideoInput : BaseInput, IImage, IAudio
    {
        readonly List<AudioInputAVStream> _audioInputAVStreams = new List<AudioInputAVStream>();
        readonly List<ImageInputAVStream> _imageInputAVStreams = new List<ImageInputAVStream>();

        /// <summary>
        /// 
        /// </summary>
        protected VideoInput(int imageStreamCount, int audioStreamCount)
        {
            if (imageStreamCount < 0) throw new ArgumentOutOfRangeException(nameof(imageStreamCount));
            if (audioStreamCount < 0) throw new ArgumentOutOfRangeException(nameof(audioStreamCount));


            for (int i = 0; i < imageStreamCount; i++)
            {
                _imageInputAVStreams.Add(new ImageInputAVStream(this, i));
            }
            for (int i = 0; i < audioStreamCount; i++)
            {
                _audioInputAVStreams.Add(new AudioInputAVStream(this, i));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<InputAVStream> InputAVStreams
            => _imageInputAVStreams.Cast<InputAVStream>().Concat(_audioInputAVStreams);


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ImageInputAVStream> ImageInputAVStreams { get { return _imageInputAVStreams; } }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<AudioInputAVStream> AudioInputAVStreams { get { return _audioInputAVStreams; } }
    }
}
