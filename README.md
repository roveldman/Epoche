# Epoche

## What is Epoche?

I've always liked [alternative ways to perceive time](https://wiki.xxiivv.com/site/time.html), particularly ones that remind you of large scales of time. Clocks, and even calendars confine us to a couple hours or months. I created Epoche as a way to have a sense of large spans of time in a grid of your entire life (including its future).

## Usage

To use "ranges.json", use
```dotnet run```
otherwise
```dotnet run other-json.json```
.

Other JSON files must be copied to the output directory. This can be [configured](https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-items?view=vs-2019#compile) in the .csproj file.

## JSON Structure

I'd recommend taking a look at "ranges.json" first. It is simply a JSON list with items of the following format (all fields are required).

```
{
	"Start": "2002-08-01",
	"End": "2008-08-01",
	"Color": "Green",
	"Character": "*"
}
```

You may use colors within the [ConsoleColor](https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor?view=netcore-3.1#fields) enum.

Other details go in "Personal.json".

{
  "BirthDate": "1995-01-01",
  "LifeExpectancy": "73"
}