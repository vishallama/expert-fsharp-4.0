// Indexer Properties: Properties that take arguments.
// The most commonly defined indexer property is called Item, and the
// Item property on a value v is accessed via the special notation v.[i].
// The properties are normally used to implement the lookup operation on
// collection types.

/// Sparse vector in terms of an underlying sorted dictionary.
open System.Collections.Generic

type SparseVector(items : seq<int * float>) =
    let elems = new SortedDictionary<_, _>()
    do items |> Seq.iter (fun (k, v) -> elems.Add(k, v))

    /// This defines an indexer property
    member t.Item
        with get(idx) =
            if elems.ContainsKey(idx) then elems.[idx]
            else 0.0

// Define and use the indexer property
let v = SparseVector [(3, 4.0); (5, 6.0)]
printfn "%f" (v.[4])        // 0.0
printfn "%f" (v.[3])        // 4.0
printfn "%f" (v.[5])        // 6.0
