// Some recursive functions
let rec factorial n =
    if n <= 1 then 1 else n * factorial (n-1)

printfn "Factorial 5 = %d" (factorial 5)

let rec length l =
    match l with
    | [] -> 0
    | _ :: tail -> 1 + length tail

// Mutually recursive functions
let rec even n = (n = 0u) || odd (n - 1u)
and odd n = (n <> 0u) && even (n - 1u)
