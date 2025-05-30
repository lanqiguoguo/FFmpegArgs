# FFmpegArgs
**FFmpegArgs** is a cli-wrapper library support generate argument for ffmpeg executable.  
The standout feature that many cli-wrapper libraries don't have is the **FFmpeg FilterGraph** system.

Get it on [NuGet Package](https://www.nuget.org/packages?q=FFmpegArgs)  
________________________________________  
- Support file/url/pipe in/output.
- Works on most systems - if ffmpeg can execution.
- 130+ filters, add more in future 
- 380+ filters auto-generate

# Example
``` Csharp
FFmpegArg ffmpegArg = new FFmpegArg()
    .OverWriteOutput();//global extension

var green_video = ffmpegArg.AddVideoInput(
        new VideoFileInput(@"chromakey.mp4")
            .SsPosition(TimeSpan.FromSeconds(0.5))//input extension ( -ss )
            .AndSet(
                x => x.ImageInputAVStream//input video stream
                    .R(24)//input, video, per-stream extension ( -r )
            )
    );
var background_videoMap = ffmpegArg.AddVideoInput(new VideoFileInput(@"background.mp4")
    .SsPosition(TimeSpan.FromSeconds(1))
    .ToPosition(TimeSpan.FromSeconds(10)));

var image_maps = green_video.ImageMaps.First()
    .ColorKeyFilter()//ColorKey Filter
        .Color(Color.FromArgb(101, 220, 8))
        .Similarity(0.25f)
        .Enable("between(t,0,10)").MapOut//Filter had ITimelineSupport
    .ScaleFilter().W("iw/3").H("ih/3").MapOut//Scale Filter
    .SplitFilter(2).MapsOut;//Split Filter

var overlay_map = image_maps.First()
    //overlay color_key on-center background_video
    .OverlayFilterOn(background_videoMap.ImageMaps.First()).X("(W-w)/2").Y("(H-h)/2").MapOut;

ffmpegArg.AddOutput(
    new VideoFileOutput(@"out.mp4", overlay_map, background_videoMap.AudioMaps.First())
    .T(TimeSpan.FromSeconds(5))//output extension ( -t )
    .AndSet(
        x => x.ImageOutputAVStream//output video stream
            .R(24)//output, video, per-stream extension ( -r )
        )
    );
ffmpegArg.AddOutput(
    new VideoFileOutput(@"out2.mp4", image_maps.Last(), background_videoMap.AudioMaps.First())
    .AndSet(x => x.ImageOutputAVStream.R(30)));

var renderResult = ffmpegArg
    .Render(c => c
        .WithFFmpegBinaryPath("path to ffmpeg")//or default ffmpeg from PATH
        .WithWorkingDirectory("path to working folder")//or default Directory.GetCurrentDirectory()
    )
    .Execute();
```
For more example, see `FFmpegArgs.Test`  

----------------------------------------
+ Option/Flag not found?  

We can extend for `FFmpegArg`, `Filter`, `Input`, `Output`, `AVStream` by extension.  

`.SetOption("your option","option value")`  
`.SetOptionRange("your option", val, min, max)`  
`.SetFlag("your flag")`  

+ Filter not found?  

We can write new Filter class, so much example in `FFmpegArgs.Filters`  

Pull request or request missing feature are welcome.

----------------------------------------
Recommend namespace 
```csharp
using FFmpegArgs;
using FFmpegArgs.Cores;
using FFmpegArgs.Cores.Enums;
using FFmpegArgs.Cores.Exceptions;
using FFmpegArgs.Cores.Inputs;
using FFmpegArgs.Cores.Filters;
using FFmpegArgs.Cores.Interfaces;
using FFmpegArgs.Cores.Maps;
using FFmpegArgs.Cores.Streams;

using FFmpegArgs.Filters;
using FFmpegArgs.Filters.Exceptions;
using FFmpegArgs.Filters.Attributes;
using FFmpegArgs.Filters.Expressions;

using FFmpegArgs.Filters.AudioFilters;
using FFmpegArgs.Filters.VideoFilters;
using FFmpegArgs.Filters.Multimedia;
using FFmpegArgs.Filters.VideoSources;
using FFmpegArgs.Filters.AudioSources;
//using FFmpegArgs.Filters.Generated;

using FFmpegArgs.Executes;
using FFmpegArgs.Inputs;
using FFmpegArgs.Outputs;

```
________________________________________

# LICENCE  
MIT
