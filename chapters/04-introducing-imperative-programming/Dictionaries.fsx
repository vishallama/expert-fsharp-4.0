open System.Collections.Generic
open FSharp.Collections

let capitals = new Dictionary<string, string>(HashIdentity.Structural)

capitals.["USA"] <- "Washington"
capitals.["Bangladesh"] <- "Dhaka"

printfn "%b" (capitals.ContainsKey("USA"))          // true
printfn "%b" (capitals.ContainsKey("Australia"))    // false

printfn "Capitals: %s" (capitals.Keys.ToString())

printfn "Capital of %s is %s" "USA" (capitals.["USA"])

for countryCapital in capitals do
    printfn "%s has capital %s" countryCapital.Key countryCapital.Value

// Search a key in a dictionary
let (a, b) = capitals.TryGetValue("Australia")
printfn "%b %s" a b
let (c, d) = capitals.TryGetValue("USA")
printfn "%b %s" c d

let sparesMap = new Dictionary<(int * int), float>()
sparesMap.[(0, 2)] <- 4.0
sparesMap.[(1021, 1847)] <- 9.0
printfn "%s" (sparesMap.Keys.ToString())
