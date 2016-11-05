open System.IO
open System.Runtime.Serialization.Formatters.Binary

let writeValue outputStream x =
    let formatter = new BinaryFormatter()
    formatter.Serialize(outputStream, box x)

let readValue inputStream =
    let formatter = new BinaryFormatter()
    let res = formatter.Deserialize(inputStream)
    unbox res

let addresses =
    Map.ofList [ "Alice", "Los Angeles"
                 "Bob", "New York City"
                 "Catherine", "London" ]

let fsOut = new FileStream("Data.dat", FileMode.Create)
writeValue fsOut addresses
fsOut.Close()

let fsIn = new FileStream("Data.dat", FileMode.Open)
let res : Map<string, string> = readValue fsIn
fsIn.Close()

printfn "%A" res
