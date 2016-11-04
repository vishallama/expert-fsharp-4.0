type Point3D = { X : float; Y : float; Z : float }

let p1 = { X = 3.0; Y = 4.0; Z = 5.0 }
let p2 = { p1 with Y = 1.0; Z = 2.0 }
// This expression form doesn't mutate the values of a record,
// even if the fields of the original record are mutable.

printfn "%A" p1
printfn "%A" p2
