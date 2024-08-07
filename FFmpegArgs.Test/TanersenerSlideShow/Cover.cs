﻿


namespace FFmpegArgs.Test.TanersenerSlideShow
{
    [TestClass]
    public class Cover
    {
        [TestMethod]
        public void CoverVerticalTest()
        {
            ScreenMode screenMode = ScreenMode.Blur;
            VerticalDirection verticalDirection = VerticalDirection.BottomToTop;
            string outputFileName = $"{nameof(CoverVerticalTest)}-{screenMode}-{verticalDirection}.mp4";
            string filterFileName = $"{nameof(CoverVerticalTest)}-{screenMode}-{verticalDirection}.txt";
            FFmpegArg ffmpegArg = new FFmpegArg().OverWriteOutput().VSync(VSyncMethod.vfr);
            var images_inputmap = ffmpegArg.GetImagesInput();
            Config config = new Config();
            TimeSpan TOTAL_DURATION = (config.ImageDuration + config.TransitionDuration) * images_inputmap.Count - config.TransitionDuration;
            List<IEnumerable<ImageMap>> prepareInputs = images_inputmap.InputScreenModes(screenMode, config);
            var overlaids = prepareInputs.Select(x => x.First()).Overlaids(config);
            var startEnd = prepareInputs.Select(x => x.Last()).ToList().StartEnd(config);
            string expr = string.Empty;
            double TRANSITION_DURATION = config.TransitionDuration.TotalSeconds;
            switch (verticalDirection)
            {
                case VerticalDirection.TopToBottom:
                    expr = $"if(gte(Y,H*T/{TRANSITION_DURATION}),B,A)";
                    break;
                case VerticalDirection.BottomToTop:
                    expr = $"if(gte(Y,H - H*T/{TRANSITION_DURATION}),A,B)";
                    break;
            }
            var blendeds = startEnd.Blendeds(config, blend =>
            {
                blend.Shortest(true);
                blend.All_Expr(expr);
            });
            var out_map = overlaids.ConcatOverlaidsAndBlendeds(blendeds);
            //Output
            ImageFileOutput imageFileOutput = new ImageFileOutput(outputFileName, out_map);
            imageFileOutput
                .Duration(TOTAL_DURATION)
                .ImageOutputAVStreams.First()
                    .Codec("libx264")
                    //.Fps(config.Fps)
                    .SetOption("-g", "0")
                    .SetOption("-rc-lookahead", "0");
            ffmpegArg.AddOutput(imageFileOutput);
            ffmpegArg.TestRender(filterFileName, outputFileName);
        }
        [TestMethod]
        public void CoverHorizontalTest()
        {
            ScreenMode screenMode = ScreenMode.Blur;
            HorizontalDirection verticalDirection = HorizontalDirection.LeftToRight;
            string outputFileName = $"{nameof(CoverHorizontalTest)}-{screenMode}-{verticalDirection}.mp4";
            string filterFileName = $"{nameof(CoverHorizontalTest)}-{screenMode}-{verticalDirection}.txt";
            FFmpegArg ffmpegArg = new FFmpegArg().OverWriteOutput().VSync(VSyncMethod.vfr);
            var images_inputmap = ffmpegArg.GetImagesInput();
            Config config = new Config();
            TimeSpan TOTAL_DURATION = (config.ImageDuration + config.TransitionDuration) * images_inputmap.Count - config.TransitionDuration;
            List<IEnumerable<ImageMap>> prepareInputs = images_inputmap.InputScreenModes(screenMode, config);
            var overlaids = prepareInputs.Select(x => x.First()).Overlaids(config);
            var startEnd = prepareInputs.Select(x => x.Last()).ToList().StartEnd(config);
            string expr = string.Empty;
            double TRANSITION_DURATION = config.TransitionDuration.TotalSeconds;
            switch (verticalDirection)
            {
                case HorizontalDirection.LeftToRight:
                    expr = $"if(gte(X,W*T/{TRANSITION_DURATION}),B,A)";
                    break;
                case HorizontalDirection.RightToLeft:
                    expr = $"if(gte(X,W-W*T/{TRANSITION_DURATION}),A,B)";
                    break;
            }
            var blendeds = startEnd.Blendeds(config, blend =>
            {
                blend.Shortest(true);
                blend.All_Expr(expr);
            });
            var out_map = overlaids.ConcatOverlaidsAndBlendeds(blendeds);
            //Output
            ImageFileOutput imageFileOutput = new ImageFileOutput(outputFileName, out_map);
            imageFileOutput
                .Duration(TOTAL_DURATION)
                .ImageOutputAVStreams.First()
                    .Codec("libx264")
                    //.Fps(config.Fps)
                    .SetOption("-g", "0")
                    .SetOption("-rc-lookahead", "0");
            ffmpegArg.AddOutput(imageFileOutput);
            ffmpegArg.TestRender(filterFileName, outputFileName);
        }
    }
}
