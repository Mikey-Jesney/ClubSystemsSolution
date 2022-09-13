If whenrunning the code, you run into an issue which looks something like this: "Could not find a part of the path ... bin\roslyn\csc.exe"

Then try running this command in package manager console: Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
