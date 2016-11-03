let eight = lazy (4 * 2)    // value 8 is not created

printfn "%d" (eight.Force())

// The lazy value is computed only once, and thus its effects
// are executed only once.
let eightWithSideEffect = lazy (printfn "Hello, world!"; 4 * 2)
printfn "%d" (eightWithSideEffect.Force())
printfn "%d" (eightWithSideEffect.Force())

// Lazy values are immplemented by a simple data structure containing
// a mutable reference cell.
