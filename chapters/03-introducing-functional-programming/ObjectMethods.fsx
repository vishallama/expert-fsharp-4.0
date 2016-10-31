open System
open System.IO

let pathExtensions =
    ["file1.txt"; "file2.txt"; "file3.sh"]
    |> List.map Path.GetExtension

// Add extra type information to indicate which overload of
// the method is required.
let f = (Console.WriteLine : string -> unit)
