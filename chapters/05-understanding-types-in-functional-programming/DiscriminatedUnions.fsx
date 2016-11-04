type Route = int
type Make = string
type Model = string
// Discriminated union
type Transport =
    | Car of Make * Model
    | Bicycle
    | Bus of Route

// Each alternative of a discriminated union is called a discriminator.
let alice = Car("Honda", "Civic")
let bob = [ Bicycle; Bus 8 ]
let carmen = [ Car("Toyota", "Corolla"); Bicycle ]

// Discriminators in pattern matching
let averageSpeed (tr : Transport) =
    match tr with
    | Car _ -> 35
    | Bicycle -> 16
    | Bus _ -> 24

// Discriminated Unions can include recursive references
type Proposition =
    | True
    | And of Proposition * Proposition
    | Or of Proposition * Proposition
    | Not of Proposition

// Recursive functions can be used to tranverse such a type
let rec eval (p : Proposition) =
    match p with
    | True -> true
    | And(p1, p2) -> eval p1 && eval p2
    | Or(p1, p2) -> eval p1 || eval p2
    | Not(p1) -> not (eval p1)

let p1 = And(True, Not(True))
printfn "%b" (eval p1)              // false
printfn "%b" (eval (Not(p1)))       // true
