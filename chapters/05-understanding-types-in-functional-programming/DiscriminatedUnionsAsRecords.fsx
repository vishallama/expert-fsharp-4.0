// Discriminated union types with only one data tag are an effective way to
// implement record-like types.
type Point3D = Vector3D of float * float * float

let origin = Vector3D(0., 0., 0.)
let unitX = Vector3D(1., 0., 0.)
let unitY = Vector3D(0., 1., 0.)
let unitZ = Vector3D(0., 0., 1.)

// Then decompose them using succinct patterns
let length (Vector3D(dx, dy, dz)) = sqrt(dx * dx + dy * dy + dz * dz)
printfn "%f" (length (Vector3D(2., 2., 1.)))        // 3.000000
