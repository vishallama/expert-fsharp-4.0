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

printfn "Fibonacci(%d) = %d" 1 (fibFast(1))
printfn "Fibonacci(%d) = %d" 2 (fibFast(2))
printfn "Fibonacci(%d) = %d" 3 (fibFast(3))
printfn "Fibonacci(%d) = %d" 4 (fibFast(4))
printfn "Fibonacci(%d) = %d" 10 (fibFast(10))
printfn "Fibonacci(%d) = %d" 20 (fibFast(20))
