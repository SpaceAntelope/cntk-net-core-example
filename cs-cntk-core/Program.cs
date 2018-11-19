using System;
using System.Linq;
using CNTK;

namespace cs_cntk_core
{
    class Program
    {
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
