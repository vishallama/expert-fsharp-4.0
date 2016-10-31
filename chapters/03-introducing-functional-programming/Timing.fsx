open System

let time f =
    let start = DateTime.Now
    let result = f()
    let finish = DateTime.Now
    let elapsed = finish - start
    elapsed

printfn "Time taken to obtain result = %s"
    ((time (fun() -> List.map (fun x -> x + 1) [1..1000])).ToString())
    
 
