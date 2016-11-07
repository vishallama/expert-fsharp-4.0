/// Vectors whose length is checked to be close to length one.
type UnitVector2D(dx, dy) =
    let tolerance = 0.000001

    let length = sqrt (dx * dx + dy * dy)
    do if abs (length - 1.0) >= tolerance then failwith "not a unit vector";

    member v.DX = dx

    member v.DY = dy

    // Explicit constructor, which ultimately constructs an instance of the
    // object via the primary (implicity) constructor).
    new() = UnitVector2D(1.0, 0.0)

    // The inferred signature for this type contains two constructors. This
    // is a form of method overloading.
