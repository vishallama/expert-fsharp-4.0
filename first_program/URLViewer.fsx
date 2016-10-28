open System.IO
open System.Net

/// Get the contents of the URL via a web request
let http(url: string) =
    let req = WebRequest.Create(url)
    let resp = req.GetResponse()
    let stream = resp.GetResponseStream()
    let reader = new StreamReader(stream)
    let html = reader.ReadToEnd()
    resp.Close()
    html

http "http://fsharp.org"