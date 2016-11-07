/// A type of binary tree, generic in the type of values carried at nodes
type Tree<'T> =
    | Node of 'T * Tree<'T> * Tree<'T>
    | Tip

    /// Compute the number of values in the tree
    member t.Size =
        match t with
        | Node (_, left, right) -> 1 + left.Size + right.Size
        | Tip -> 0

// Discriminated unions are a form of concrete types. Above, Tree is a
// discriminated union, which has a member.
