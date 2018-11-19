# ctnk-net-core-example
Minimal working projects with CNTK for C# and F# in Windows 10 targeting netcoreapp2.1 and build without Visual Studio.

## The Story So Far: 
Both projects build fine from within VS2017 but crash out with _Unable to load DLL 'Cntk.Core.CSBinding-2.6.dll'_ from the CLI.

To run successfully from CLI or VSCODE it seems neccessary to both use the `--configuration x64` switch as well as make sure that all CNTK DLLs are in the same directory or in the path variable, or do both, the minimum necessary action hopefully to be determined shortly. VS2017 (15.9+) confuses the issue by copying all CNTK dll to the bin directory without any special prompting. Conversely, Using `dotnet build` from the CLI and including `<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>` in the project file results in only **Cntk.Core.Managed-2.6.dll** being copied to the bin directory.