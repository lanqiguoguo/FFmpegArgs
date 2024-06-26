﻿using Autogens.Format;
using Autogens.Filter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autogens.Codec;
namespace Autogens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filters = GetDoc("-filters").Skip(8).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.TrimStart()).ToList();
            var fulls = DocLine.GetDocLine(GetDoc("-h full").ToList());
            FiltersGen.Gen(filters, fulls);

            var formats = GetDoc("-formats").ToList();
            FormatsGen.Gen(formats);

            var codecs = GetDoc("-codecs").ToList();
            CodecGen.Gen(codecs);
        }

        static IEnumerable<string> GetDoc(string arg)
        {
            ProcessStartInfo processStart = new ProcessStartInfo();
            processStart.FileName = "ffmpeg.exe";
            processStart.Arguments = arg;
            processStart.UseShellExecute = false;
            processStart.RedirectStandardOutput = true;
            processStart.CreateNoWindow = true;
            using Process process = Process.Start(processStart);
            do
            {
                yield return process.StandardOutput.ReadLine();
            }
            while (!process.StandardOutput.EndOfStream);
        }
    }
}
