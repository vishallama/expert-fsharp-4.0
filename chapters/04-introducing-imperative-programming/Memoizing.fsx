open System.Collections.Generic

// Unmemoized version of the Fibonacci function
let rec fib n =
    if n <= 2
    then 1
    else fib (n-1) + fib (n-2)

// Version keeping a lookup table is much faster
let fibFast =
    let t = new Dictionary<int, int>()
    let rec fibCached n =
        if t.ContainsKey n then t.[n]
        elif n <= 2 then 1
        else let result = fibCached (n-1) + fibCached (n-2)
             t.Add (n, result)
             result
    fun n -> fibCached n

// Compute time required to compute fibFast for a specific value
let time f =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let result = f()
    let finish = stopWatch.Stop()
    (result, stopWatch.Elapsed.TotalMilliseconds |> sprintf "%f ms")

printfn "%A" (time(fun () -> fibFast 10).ToString())
printfn "%A" (time(fun () -> fibFast 20).ToString())
printfn "%A" (time(fun () -> fibFast 30).ToString())
