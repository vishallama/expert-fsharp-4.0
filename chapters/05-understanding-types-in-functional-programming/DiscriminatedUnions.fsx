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
