// Prior to F# 4.0, one mutable record type, mutable reference cells
// ("ref cells"), is commonly seen in F# code. These play the same
// role as pointers in other imperative languages.
let cell = ref 1
printfn "%d" cell.Value     // 1

cell := 2
printfn "%d" cell.Value     // 2
printfn "%d" cell.contents  // 2
printfn "%d" !cell          // 2

// In F# 4.0, the use of ref cells can replaced with "let mutable".
