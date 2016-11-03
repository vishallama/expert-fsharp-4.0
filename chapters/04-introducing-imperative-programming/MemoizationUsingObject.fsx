open System.Collections.Generic

// A generic memoization service

type Table<'T, 'U> =
    abstract Item : 'T -> 'U with get
    abstract Discard : unit -> unit

let memoizeAndPermitDiscard f =
    let lookupTable = new Dictionary<_, _>(HashIdentity.Structural)
    { new Table<'T, 'U> with
        member t.Item
            with get(n) =
                if lookupTable.ContainsKey(n)
                then lookupTable.[n]
                else
                    let res = f n
                    lookupTable.Add(n, res)
                    res

        member t.Discard() =
            lookupTable.Clear() }

#nowarn "40"    // do not warn on recursive computed objects and functions

// The implementation of memoize here is not thread safe, because it doesn't
// lock the internal lookup table during reading and writing. This is fine
// if the computed function is used only from at most one thread at a time,
// but in a multithreaded application, we need to use strategies that utilize
// internal tables protectec by locks, such as .NET ReaderWriterLock.

let rec fibFast =
    memoizeAndPermitDiscard (fun n ->
        printfn "computting fibFast %d" n
        if n <= 2 then 1 else fibFast.[n-1] + fibFast.[n-2])

printfn "%d" fibFast.[3]
printfn "%d" fibFast.[5]

printfn "Discarding lookup table and restarting computation"
fibFast.Discard()
printfn "%d" fibFast.[5]
