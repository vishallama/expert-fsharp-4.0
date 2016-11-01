type DiscreteEventCounter =
    { mutable Total : int;
      mutable Positive : int;
      Name : string }

let recordEvent (s : DiscreteEventCounter) isPositive =
    s.Total <- s.Total + 1
    if isPositive then s.Positive <- s.Positive + 1

let reportStatus (s : DiscreteEventCounter) =
    printfn "We have %d %s out of %d" s.Positive s.Name s.Total

let newCounter nm =
    { Total = 0;
      Positive = 0;
      Name = nm }

let bigNumberCounter = newCounter "big number(s)"

let evaluateNumber n =
    recordEvent bigNumberCounter (n > 50)
    n

evaluateNumber 51 |> ignore
evaluateNumber 3 |> ignore
evaluateNumber 100 |> ignore

reportStatus bigNumberCounter
