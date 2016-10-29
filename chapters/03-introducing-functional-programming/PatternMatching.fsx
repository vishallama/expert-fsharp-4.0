let printFirst xs =
    match xs with
    | h :: _ -> printfn "The first item in the list is %A" h
    | [] -> printfn "No items in the list"

let sign' x =
    match x with
    | _ when x < 0 -> -1
    | _ when x > 0 -> 1
    | _ -> 0

let getValue a =
    match a with
    | (("lo" | "low"), v) -> v
    | ("hi", v) | ("high", v) -> v
    | _ -> failwith "expected a both a high and low value"
 