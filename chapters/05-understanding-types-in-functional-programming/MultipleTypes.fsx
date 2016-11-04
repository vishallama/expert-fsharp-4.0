// Multiple types can be declared together to give a mutually recursive
// collection of types, including record types, discriminated unions,
// and abbreviations.
type Node = {
    Name : string
    Links : Link list
} and Link =
    | Dangling
    | Link of Node
