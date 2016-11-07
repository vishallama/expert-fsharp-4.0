/// A Vector2D record type with object members

type Vector2D =
    { DX : float; DY : float }

    /// Get the length of the vector
    member v.Length = sqrt (v.DX * v.DX + v.DY * v.DY)

    /// Return a vector scaled by the given factor
    member v.Scale k = { DX = k * v.DX; DY = k * v.DY }

    /// Return a vector shifted by the given delta in the X coordinate
    member v.ShiftX x = { v with DX = v.DX + x }

    /// Return a vector shifted by the given delta in the Y coordinate
    member v.ShiftY y = { v with DY = v.DY + y }

    /// Return a vector shifted by the given distance in both coordinates
    member v.ShiftXY (x, y) = { DX = v.DX + x; DY = v.DY + y }

    /// Get the zero vector
    static member Zero = { DX = 0.0; DY = 0.0 }

    /// Return a constant vector along the X axis
    static member ConstX dx = { DX = dx; DY = 0.0 }

    /// Return a constant vector along the Y axis
    static member ConstY dy = { DX = 0.0 ; DY = dy }

// Test vectors
let v =  { DX = 3.0; DY = 4.0 }
printfn "%f" (v.Length)                 // 5.0
printfn "%f" (v.Scale(2.0).Length)      // 10.0
printfn "%A" (Vector2D.ConstX(3.0))
