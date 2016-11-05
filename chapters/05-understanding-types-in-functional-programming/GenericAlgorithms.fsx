// An example of an algorithm that is not generic
let rec hcf a b =
    if a = 0 then b
    elif a < b then hcf a (b - a)
    else hcf (a - b) b

printfn "%d" (hcf 18 12)        // 6
printfn "%d" (hcf 33 24)        // 3
