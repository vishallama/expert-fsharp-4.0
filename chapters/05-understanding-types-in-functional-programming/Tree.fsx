// Represent tree-like data using discriminated unions
type Tree<'T> =
    | Tree of 'T * Tree<'T> * Tree<'T>
    | Tip of 'T

let rec sizeOfTree tree =
    match tree with
    | Tree(_, left, right) -> 1 + sizeOfTree left + sizeOfTree right
    | Tip _ -> 1

let a = Tip "a"
let b = Tip "b"
let c = Tip "c"
let smallTree = Tree("1", Tree("2", a, b), c)

printfn "Size of smallTree = %d" (sizeOfTree smallTree)     // 5
