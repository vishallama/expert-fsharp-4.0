// You can introduce type variables simply by writing them as part of the
// type annotations of a function.
let rec map (f : 'T -> 'U) (l : 'T list) =
    match l with
    | h :: t -> f h :: map f t
    | [] -> []

 // You can also write the type parameters explicitly on a declaration.
let rec map'<'T, 'U> (f : 'T -> 'U) (l : 'T list) =
    match l with
    | h :: t -> f h :: map' f t
    | [] -> []

printfn "%A" (map (fun x -> x + 1) [0..9])
printfn "%A" (map' (fun x -> x + 1) [0..9])
