using System;
using System.Linq;
using CNTK;
using System.Reflection;
using System.IO;


namespace cs_cntk_core
{
    public static class Extensions
    {
        public static TOut Pipe<TIn, TOut>(this TIn obj, Func<TIn, TOut> f) => f(obj);
        public static void Pipe<TIn>(this TIn obj, Action<TIn> f) => f(obj);
    }

    public class Program
    {
        static void ResolveDepPaths()
        {

            var cntkPath = Assembly.GetAssembly(typeof(CNTK.CNTKLib)).CodeBase.Replace("file:///", "");
            var supportPath = Path.GetFullPath(Path.Combine(cntkPath, "../../../Support/x64/Release"));

            Console.WriteLine(supportPath, cntkPath);
            var baseIndex = cntkPath.Split('/').ToList().FindIndex(dir => dir.ToLower().Contains("cntk."));

            Console.WriteLine(baseIndex.ToString());

            var cudaPaths = cntkPath
                .Split("/")
                .Take(baseIndex)
                .Aggregate((state, current) => $"{state}/{current}")
                .Pipe(path => Directory
                        .GetDirectories(path, "cntk.deps.cu*")
                        .SelectMany(dir => Directory.GetDirectories(Path.Combine(dir, "2.6.0/support/x64"))
                        .Select(Path.GetFullPath)));

            Console.WriteLine(supportPath);

            var paths = Environment.GetEnvironmentVariable("PATH").Split(';').ToList();
            paths.Add(Path.GetDirectoryName(cntkPath));
            paths.Add(supportPath);
            paths.AddRange(cudaPaths);

            Environment.SetEnvironmentVariable("PATH", string.Join(';', paths));

            Console.WriteLine("Paths");
            Environment.GetEnvironmentVariable("PATH").Split(";").ToList().ForEach(Console.WriteLine);
        }

        static void Main(string[] args)
        {
            //var pathVariable = Environment.GetEnvironmentVariable("PATH");
            //var binPath = 
            //    System.IO.Path.GetDirectoryName(
            //        System.Reflection.Assembly
            //            .GetExecutingAssembly()
            //            .GetName()
            //            .CodeBase)
            //        .Replace("file:\\","");
            //Environment.SetEnvironmentVariable("PATH", $"{pathVariable};{binPath}", EnvironmentVariableTarget.Process);

            //Environment.GetEnvironmentVariable("PATH").Split(';').ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Hello World!");

            var cpu = DeviceDescriptor.UseDefaultDevice();
            Console.WriteLine($"You are using CNTK for: {cpu.Type}");

            Console.ReadLine();
        }
    }
}
