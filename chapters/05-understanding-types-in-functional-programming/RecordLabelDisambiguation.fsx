type Dot = { X : int; Y : int }
type Point = { X : float; Y : float }
type Person = {
    Name : string
    DateofBirth : System.DateTime
}

let coords1 (p : Point) = (p.X, p.Y)
let coords2 (d : Dot) = (d.X, d.Y)

// use of X and Y implies type "Point", the last definition that fits
let distance p = sqrt (p.X * p.X + p.Y * p.Y)

// record values with explicit type annotation for the whole record
let alice =
    ({ Name = "Alice"
       DateofBirth = new System.DateTime(1970, 09, 22)} : Person)
