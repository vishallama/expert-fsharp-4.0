open System

// record type
type Person =
    { Name : string;
      DateofBirth : DateTime }

let bill = { Name = "Bill"; DateofBirth = DateTime(1962, 09, 02) }
printfn "%A" bill
