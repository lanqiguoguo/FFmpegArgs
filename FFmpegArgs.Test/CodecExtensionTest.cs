﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFmpegArgs.Test
{
    [TestClass]
    public class CodecExtensionTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidException))]
        public void TestThrowEncoding()
        {
            ImageFilterGraphInput imageFilterGraphInput = new ImageFilterGraphInput();//decoding image
            imageFilterGraphInput.ImageInputAVStream.Codec(Codecs.ljpeg);//.EVI.S //image
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidException))]
        public void TestThrowDecoing()
        {
            ImageFileOutput imageFileOutput = new ImageFileOutput("abc", new ImageMap(new FilterGraph(), "def"));
            imageFileOutput.ImageOutputAVStream.Codec(Codecs.idf);//D.VI..
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidException))]
        public void TestThrowAudio()
        {
            AudioFilterGraphInput audioFilterGraphInput = new AudioFilterGraphInput();
            audioFilterGraphInput.AudioInputAVStream.Codec(Codecs.idf);//D.VI..
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidException))]
        public void TestThrowImage()
        {
            ImageFileOutput imageFileOutput = new ImageFileOutput("abc", new ImageMap(new FilterGraph(), "def"));
            imageFileOutput.ImageOutputAVStream.Codec(Codecs.aac);//DEAIL.
        }

        [TestMethod]
        public void TestNotThrow()
        {
            ImageFilterGraphInput imageFilterGraphInput = new ImageFilterGraphInput();
            imageFilterGraphInput.ImageInputAVStream.Codec(Codecs.idf);//D.VI..
        }
    }
}
