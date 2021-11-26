﻿using System;
using System.IO;

namespace FFmpegArgs.Executes
{
    public class FFmpegBuildConfig
    {
        /// <summary>
        /// Default: ffmpeg
        /// </summary>
        public string FFmpegBinaryPath
        {
            get { return _FFmpegBinaryPath; }
            set
            {
                if (File.Exists(value)) _FFmpegBinaryPath = value;
                else throw new FileNotFoundException(value);
            }
        }

        string _FFmpegBinaryPath = "ffmpeg";



        /// <summary>
        /// Default: False
        /// </summary>
        public bool IsForceUseScript { get; set; } = false;



        /// <summary>
        /// Default: FS.txt
        /// </summary>
        public string FilterScriptName
        {
            get { return _FilterScriptName; }
            set
            {
                if (string.IsNullOrWhiteSpace(FilterScriptName)) throw new ArgumentNullException(nameof(value));
                else _FilterScriptName = value;
            }
        }
        string _FilterScriptName = "FS.txt";



        /// <summary>
        /// Default: Directory.GetCurrentDirectory()
        /// </summary>
        public string WorkingDirectory { get; set; }
#if DEBUG
        = "D:\\temp\\ffmpeg_encode_test";
#else
        = Directory.GetCurrentDirectory();
#endif



        /// <summary>
        /// Window default: 32766
        /// </summary>
        public int ArgumentsMaxLength
        {
            get { return _ArgumentsMaxLength; }
            set
            {
                if (value > 10) _ArgumentsMaxLength = value;
                else throw new InvalidDataException($"ArgumentsMaxLength should be > 10");
            }
        }

        int _ArgumentsMaxLength = 32766;





        /// <summary>
        /// Default: ffmpeg
        /// </summary>
        public FFmpegBuildConfig WithFFmpegBinaryPath(string filePath)
        {
            if (File.Exists(filePath)) FFmpegBinaryPath = filePath;
            else throw new FileNotFoundException(filePath);
            return this;
        }

        /// <summary>
        /// Default: FS.txt
        /// </summary>
        public FFmpegBuildConfig WithFilterScriptName(string scriptName, bool forceUseScript = false)
        {
            if (string.IsNullOrWhiteSpace(scriptName)) throw new ArgumentNullException(nameof(scriptName));
            else FilterScriptName = scriptName;
            IsForceUseScript = forceUseScript;
            return this;
        }

        /// <summary>
        /// Default: Directory.GetCurrentDirectory()
        /// </summary>
        public FFmpegBuildConfig WithWorkingDirectory(string workingDir)
        {
            if (string.IsNullOrWhiteSpace(workingDir)) throw new ArgumentNullException(nameof(workingDir));
            else WorkingDirectory = workingDir;
            return this;
        }
    }
}
