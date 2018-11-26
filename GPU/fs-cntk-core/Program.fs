// Learn more about F# at http://fsharp.org

open System
open CNTK

let SetPath =
   let pathVar = Environment.GetEnvironmentVariable("PATH")
   let binPath = 
       System.IO.Path.GetDirectoryName(
           System.Reflection.Assembly
               .GetExecutingAssembly()
               .GetName()
               .CodeBase)
           .Replace("file:\\","")
           .Replace("netcoreapp2.1","Debug/netcoreapp2.1")
    
   Environment.SetEnvironmentVariable("PATH", sprintf "%s;%s;" pathVar binPath, EnvironmentVariableTarget.Process)
  
   Environment.GetEnvironmentVariable("PATH").Split(';') |> Array.iter Console.WriteLine
    
[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    let cpu = DeviceDescriptor.UseDefaultDevice()
    printfn "You are using CNTK for: %A" (cpu.Type)
    Console.ReadLine() |> ignore
    0 // return an integer exit code
