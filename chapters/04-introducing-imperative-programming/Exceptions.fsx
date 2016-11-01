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
