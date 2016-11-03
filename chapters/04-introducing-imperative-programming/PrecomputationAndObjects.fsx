open System
open System.Collections.Generic

type NameLookupService =
    abstract Contains : string -> bool

let buildSimpleNameLookup (words : string list) =
    let wordTable = HashSet<_>(words)
    { new NameLookupService with
        member t.Contains w = wordTable.Contains w }

let capitals = [ "London"; "Paris"; "New Delhi"; "Tokyo" ]

// Test the new name lookup service
let capitalLookup = buildSimpleNameLookup capitals

printfn "%b" (capitalLookup.Contains "Paris")       // true
