open System.Collections.Generic

let divideIntoEquivalenceClasses keyf seq =
    // The dictionary to hold the equivalence classes
    let dict = new Dictionary<'key, ResizeArray<'T>>()
    // Build the classes
    seq |> Seq.iter (fun v ->
        let key = keyf v
        let ok, prev = dict.TryGetValue(key)
        if ok then prev.Add(v)
        else
            let prev = new ResizeArray<'T>()
            dict.[key] <- prev
            prev.Add(v))
    // Return the sequence-of-sequences. Hide the internal collections.
    // Just reveal them as sequences.
    dict |> Seq.map (fun group -> group.Key, Seq.readonly group.Value)

let equivalenceClasses = divideIntoEquivalenceClasses (fun n -> n % 3) [0..10]
printfn "%A" equivalenceClasses
