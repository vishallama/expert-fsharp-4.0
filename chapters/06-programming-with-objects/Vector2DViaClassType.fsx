/// A Vector2D type with length precomputation via a class type
type Vector2D(dx : float, dy : float) =

    let len = sqrt (dx * dx + dy * dy)

    /// Get the X component of the vector
    member v.DX = dx

    /// Get the Y component of the vector
    member v.DY = dy

    /// Get the length of the vector
    member v.Length = len

    /// Return a vector scaled by the given factor
    member v.Scale(k) = Vector2D(k * dx, k * dy)

    /// Return a vector shifted by the given delta in the X coordinate
    member v.ShiftX(x) = Vector2D(dx = dx + x, dy = dy)

    /// Return a vector shifted by the given delta in the Y coordinate
    member v.ShiftY(y) = Vector2D(dx = dx, dy = dy + y)

    // Return a vector that is shifted by the given deltas in each coordinate
    member v.ShiftXY(x, y) = Vector2D(dx = dx + x, dy = dy + y)

    // Get the zero vector
    static member Zero = Vector2D(dx = 0.0, dy = 0.0)

    // Get a constant vector along the X axis of length one
    static member OneX = Vector2D(dx = 1.0, dy = 0.0)

    // Get a constant vector along the Y axis of length one
    static member OneY = Vector2D(dx = 0.0, dy = 1.0)

// Test vectors
let v = Vector2D(3.0, 4.0)
printfn "%f" (v.Length)                 // 5.0
printfn "%f" (v.Scale(2.0).Length)      // 10.0
