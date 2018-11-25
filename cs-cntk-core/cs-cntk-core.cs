using NUnit.Framework;
using System.Reflection;
using System;
using System.IO;
using System.Linq;

namespace Tests
{
    public static class PathEnvHelper
    {
        public static bool IsWindows =
            System.Runtime.InteropServices.RuntimeInformation.OSDescription.Contains("Windows");

        public static string CntkCoreManagedPath =
            Assembly
                .GetAssembly(typeof(CNTK.CNTKLib))
                .CodeBase
                .Replace(IsWindows ? "file:///" : "file://", "");

        public static string PackagesPath =
            CntkCoreManagedPath
                .Split(new[] { '/', '\\' })
                .Reverse()
                .SkipWhile(dir => !dir.ToLower().Contains("cntk."))
                .Skip(1)
                .Reverse()
                .Aggregate((state, current) => $"{state}{Path.DirectorySeparatorChar}{current}");

        public static void AddManagedPath(bool isDebug = false)
        {
            var supportPath = Path.GetFullPath(Path.Combine(CntkCoreManagedPath, $"../../../Support/x64/{(isDebug ? "Debug" : "Release")}"));

            Console.WriteLine(supportPath);
            Console.WriteLine(CntkCoreManagedPath);
            Console.WriteLine(PackagesPath);

        }

        public static void AddGPUPath()
        {

        }

        public static void AddCudaPath()
        {

        }

        public static void AddCommonPath()
        {

        }
    }

    public class cs_cntk_core
    {

        // static void ResolveDepPaths()
        // {
        //     Console.WriteLine(System.Runtime.InteropServices.RuntimeInformation.OSDescription);

        //     var cntkPath = Assembly.GetAssembly(typeof(CNTK.CNTKLib)).CodeBase.Replace("file:///", "");
        //     var supportPath = Path.GetFullPath(Path.Combine(cntkPath, "../../../Support/x64/Release"));

        //     Console.WriteLine(supportPath, cntkPath);
        //     var baseIndex = cntkPath.Split('/').ToList().FindIndex(dir => dir.ToLower().Contains("cntk."));

        //     Console.WriteLine(baseIndex.ToString());

        //     var cudaPaths = cntkPath
        //         .Split("/")
        //         .Take(baseIndex)
        //         .Aggregate((state, current) => $"{state}/{current}")
        //         .Pipe(path => Directory
        //                 .GetDirectories(path, "cntk.deps.cu*")
        //                 .SelectMany(dir => Directory.GetDirectories(Path.Combine(dir, "2.6.0/support/x64"))
        //                 .Select(Path.GetFullPath)));

        //     Console.WriteLine(supportPath);

        //     var paths = Environment.GetEnvironmentVariable("PATH").Split(';').ToList();
        //     paths.Add(Path.GetDirectoryName(cntkPath));
        //     paths.Add(supportPath);
        //     paths.AddRange(cudaPaths);

        //     Environment.SetEnvironmentVariable("PATH", string.Join(';', paths));

        //     Console.WriteLine("Paths");
        //     Environment.GetEnvironmentVariable("PATH").Split(";").ToList().ForEach(Console.WriteLine);
        // }

        [SetUp]
        public void Setup()
        {

            PathEnvHelper.AddManagedPath();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}