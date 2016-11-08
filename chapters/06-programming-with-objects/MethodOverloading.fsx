// Method overloading is used relatively rarely in F#-authored classes, partly
// because optional arguments and mutable property setters tend to make it
// less necessary. However, method overloading is permitted in F#.

/// Interval(lo, hi) represents the range of numbers from lo to hi, but not
/// including either lo or hi.
type Interval(lo, hi) =
    member r.Lo = lo
    member r.Hi = hi
    member r.IsEmpty = hi <= lo
    member r.Contains v = lo < v && v < hi

    static member Empty = Interval(0.0, 0.0)

    /// Return the smallest interval that covers both the intervals
    static member Span(r1 : Interval, r2 : Interval) =
        if r1.IsEmpty then r2 else
        if r2.IsEmpty then r1 else
        Interval(min r1.Lo r2.Lo, max r1.Hi r2.Hi)

    /// Return the smallest interval that covers all the intervals
    static member Span(ranges : seq<Interval>) =
        Seq.fold (fun r1 r2 -> Interval.Span(r1, r2)) Interval.Empty ranges

/// Concrete type with method overloading on the types of arguments.
type Vector =
    { DX : float; DY : float }
    member v.Length = sqrt (v.DX * v.DX + v.DY * v.DY)

type Point =
    { X : float; Y : float }

    static member (-) (p1 : Point, p2 : Point) =
        { DX = p1.X - p2.X; DY = p1.Y - p2.Y }

    static member (-) (p : Point, v : Vector) =
        { X = p.X - v.DX; Y = p.Y - v.DY }
