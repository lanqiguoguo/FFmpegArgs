﻿using FFmpegArgs.Filters;
using FFmpegArgs.Filters.Enums;
using FFmpegArgs.Filters.VideoFilters;
using FFmpegArgs.Filters.VideoSources;
using FFmpegArgs.Inputs;
using FFmpegArgs.Outputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Linq;
using System;
namespace FFmpegArgs.Test
{
    [TestClass]
    public class FilterGraphTest
    {
        [TestMethod]
        public void Test1()
        {
            FilterGraph filterGraph = new FilterGraph().OverWriteOutput();

            var green_video = filterGraph.AddVideoInput(new VideoFileInput(@"chromakey.mp4")
                .SsPosition(TimeSpan.FromSeconds(0.5)));
            var background_video = filterGraph.AddVideoInput(new VideoFileInput(@"background.mp4")
                .SsPosition(TimeSpan.FromSeconds(1))
                .ToPosition(TimeSpan.FromSeconds(10)));

            var color_keys = green_video.ImageMaps.First()
                .ColorKeyFilter(Color.FromArgb(101, 220, 8)).Similarity(0.25f)//ColorKey
                    .Enable("between(t,0,10)").MapOut//ITimelineSupport
                .ScaleFilter("iw/3", "ih/3").MapOut
                .SplitFilter(2).MapsOut;//Scale

            var overlay = color_keys.First()
                //overlay color_key on-center background_video
                .OverlayFilterOn(background_video.ImageMaps.First(), "(W-w)/2", "(H-h)/2").MapOut;

            filterGraph.AddOutput(new VideoFileOutput(@"out.mp4", overlay, background_video.AudioMaps.First()).Fps(24));
            filterGraph.AddOutput(new VideoFileOutput(@"out2.mp4", color_keys.Last(), background_video.AudioMaps.First()).Fps(30));

            var args = filterGraph.GetFullCommandline();
        }

        [TestMethod]
        public void Test2()
        {
            //var files = Directory.GetFiles(@"D:\temp\ffmpeg_encode_test\ImgsTest\*.jpg");
            int out_w = 1366;
            int out_h = 768;
            //total time per image = 3 sec
            double imageDuration = 2;
            double animationDuration = 1;
            double rotateSpeed = 2;//2 * 2PI radian/sec

            FilterGraph filterGraph = new FilterGraph();
            filterGraph.OverWriteOutput();

            var background = filterGraph.Color()
              .Color(Color.FromArgb(00, 100, 00))
              .Size(new Size(out_w, out_h));

            var images = ImageFilesConcatInput.FromFilesSearch(@"D:\temp\ffmpeg_encode_test\ImgsTest\img%d.jpg");
            images.SetOption("-r", 1 / (imageDuration + animationDuration));
            var images_map = filterGraph.AddImageInput(images);
            var pad = images_map.PadFilter("ceil(iw/2)*2", "ceil(ih/2)*2");//fix image size not % 2 = 0
            var format = pad.MapOut.FormatFilter(PixFmt.rgba);
            var scale = format.MapOut.ScaleFilter($"if(gte(iw/ih,{out_w}/{out_h}),min(iw,{out_w}),-1)", $"if(gte(iw/ih,{out_w}/{out_h}),-1,min(ih,{out_h}))");

            //rotate {animationDuration} sec and stop rotate {imageDuration} sec
            string _whenRotate = $"between(t,n*({imageDuration} + {animationDuration}),n *({imageDuration} + {animationDuration})+{animationDuration})";
            string _rotate = $"2*PI*t*{rotateSpeed}";
            string _nonRotate = $"2*PI*{rotateSpeed}*(n+{animationDuration})";
            var rotate = scale.MapOut.RotateFilter($"if({_whenRotate},{_rotate},{_nonRotate})");


            string _whenMove = $"between(t,n*({imageDuration} + {animationDuration}),n *({imageDuration} + {animationDuration})+{animationDuration})";
            string _move = $"-main_w/2 + main_w * (t - n*({imageDuration} + {animationDuration}))/({imageDuration} + {animationDuration})";
            string _stopMove = $"main_w/2";
            var overlay = rotate.MapOut.OverlayFilterOn(background.MapOut, $"if({_whenMove},{_move},{_stopMove})", $"main_h/2");
            overlay.EofAction(EofAction.EndAll);
            var videout = new ImageFileOutput(@"D:\temp\ffmpeg_encode_test\ImgsTest\test.mp4", overlay.MapOut);
            videout.Fps(24);
            filterGraph.AddOutput(videout);

            var args = filterGraph.GetFullCommandline();


        }

    }
}
