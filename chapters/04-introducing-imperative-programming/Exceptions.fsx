open System.IO

// Catching exceptions
let http(url : string) =
    try
        let request = System.Net.WebRequest.Create(url)
        let response = request.GetResponse()
        let stream = response.GetResponseStream()
        let reader = new StreamReader(stream)
        let html = reader.ReadToEnd()
        html
    with
        | :? System.UriFormatException -> "invalid URI"
        | :? System.Net.WebException -> "web request can't be processed"

printfn "%s" (http("invalid URL"))

// Process exceptions using try...finally... construct. This guarantees to
// run the finally clause both when an exception is thrown and when the
// expression evaluates normally. This allows one to ensure that resources
// are disposed off after the completion of an operation.
let httpViaTryFinally(url : string) =
    let request = System.Net.WebRequest.Create(url)
    let response = request.GetResponse()
    try
        let stream = response.GetResponseStream()
        let reader = new StreamReader(stream)
        let html = reader.ReadToEnd()
        html
    finally
        response.Close()
