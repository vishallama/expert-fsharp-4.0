open System.Collections.Generic

let isWord (words : string list) =
    let wordTable = Set.ofList words
    fun w -> wordTable.Contains(w)

// The efficient use of the above function depends on the fact that useful
// intermediate results are computed after only one argument is applied
// and a function value is returned.

let capitals = [ "London"; "Paris"; "New Delhi"; "Tokyo" ]

// internal table wordTable is computed as soon as isCapital is applied
// to one argument
let isCapital = isWord capitals

printfn "%b" (isCapital "Paris")        // true
printfn "%b" (isCapital "Manchester")   // false

// Below is a slower version of the isCapital function, because isWord is
// applied to both its first argument and its second argument every time
// the isCapitalSlow function is used. The internal table is rebuilt every
// time the function isCapitalSlow is applied.
let isCapitalSlow word = isWord capitals word

// The implementation below uses the wrong data structure (list, which takes
// O(n) time for lookup.
let isWordSlow2 (words : string list) (word : string) =
    List.exists (fun word' -> word = word') words

let isCapitalSlow2 word = isWordSlow2 capitals word

// The implementation below uses a good intermediate data structure (set,
// which has O(log n) lookup time), but it builds it on every invocation.
let isWordSlow3 (words : string list) (word : string) =
    let wordTable = Set<string>(words)
    wordTable.Contains(word)

let isCapitalSlow3 word = isWordSlow3 capitals word

// Below is a safe use of a mutable data structure, because we don't mutate
// the data structure after creating it, and we don't reveal it to the
// outside world.
let isWord' (words : string list) =
    let wordTable = HashSet<string>(words)
    fun word -> wordTable.Contains word
