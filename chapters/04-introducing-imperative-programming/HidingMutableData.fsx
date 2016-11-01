// Hide a mutable reference within the inner closure of
// values referenced by a function value
let generateStamp =
    let mutable count = 0
    (fun () -> count <- count + 1; count)

printfn "%d" (generateStamp())     // yields 1
printfn "%d" (generateStamp())     // yields 2

// It's good programming practice in polished code to
// ensure that all related items of mutable state are
// collected under some named data structure or other
// entity, such as a function.
