open System.Collections.Generic

// Calculate time required to compute a function using a memoization function.
let time f =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let result = f()
    let finish = stopWatch.Stop()
    (result, stopWatch.Elapsed.TotalMilliseconds |> sprintf "%f ms")

let memoize (f : 'T -> 'U) =
    let t = new Dictionary<'T, 'U>(HashIdentity.Structural)
    fun n ->
        if t.ContainsKey n
        then t.[n]
        else
            let result = f n
            t.Add (n, result)
            result

let rec fibFast =
    memoize (fun n -> if n <= 2 then 1 else fibFast (n-1) + fibFast (n-2))

printfn "Computing some Fibocacci numbers"
printfn "%A" (time(fun () -> fibFast 10).ToString())
printfn "%A" (time(fun () -> fibFast 20).ToString())
printfn "%A" (time(fun () -> fibFast 30).ToString())

let rec factFast =
    memoize (fun n -> if n <= 1 then 1 else n * factFast (n-1))

printfn "Computing some factorial numbers"
printfn "%A" (time(fun () -> factFast 5).ToString())
printfn "%A" (time(fun () -> factFast 10).ToString())
printfn "%A" (time(fun () -> factFast 12).ToString())

// This function leads to a fresh memoization table being allocated each
// time the function is called.
let rec fibNotFast n =
    memoize (fun n -> if n <= 2 then 1 else fibNotFast (n-1) + fibNotFast (n-2)) n

printfn "Computing some Fibonacci numbers using a slower method"
printfn "%A" (time(fun () -> fibNotFast 10).ToString())
printfn "%A" (time(fun () -> fibNotFast 20).ToString())
printfn "%A" (time(fun () -> fibNotFast 30).ToString())
