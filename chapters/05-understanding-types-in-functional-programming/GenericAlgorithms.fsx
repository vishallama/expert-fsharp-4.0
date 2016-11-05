// An example of an algorithm that is not generic
let rec hcf a b =
    if a = 0 then b
    elif a < b then hcf a (b - a)
    else hcf (a - b) b

printfn "%d" (hcf 18 12)        // 6
printfn "%d" (hcf 33 24)        // 3

// The above algorithm works only over integers.
let hcfGeneric (zero, sub, lessThan) =
    let rec hcf a b =
        if a = zero then b
        elif lessThan a b then hcf a (sub b a)
        else hcf (sub a b) b
    hcf

let hcfInt = hcfGeneric (0, (-), (<))
let hcfInt64 = hcfGeneric (0L, (-), (<))
let hcfBigInt = hcfGeneric (0I, (-), (<))

printfn "%d" (hcfInt 18 12)        // 6
printfn "%d" (hcfInt 33 24)        // 3
printfn "%A" (hcfBigInt 1810287116162232383039576I 1239028178293092830480239032I)        // 33224
