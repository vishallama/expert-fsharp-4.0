open System
open System.IO
open System.Net

// record type
type Person =
    { Name : string;
      DateofBirth : DateTime }

let bill = { Name = "Bill"; DateofBirth = DateTime(1962, 09, 02) }
printfn "%A" bill

// Record values are often used to return results from functions.
type PageStats =
    { Site : string
      Time : System.TimeSpan
      Length : int
      NumWords : int
      NumHRefs : int }

let delimiters = [| ' '; '\n'; '\t'; '<'; '>'; '=' |]

let getWords (s : string) = s.Split delimiters

// Get the contents of the URL via a web request
let http (url : string) =
    let req = WebRequest.Create(url)
    let resp = req.GetResponse()
    let stream = resp.GetResponseStream()
    let reader = new StreamReader(stream)
    let html = reader.ReadToEnd()
    resp.Close()
    html

let getStats site =
    let url = "http://" + site
    let html = http url
    let hwords = html |> getWords
    let hrefs = html |> getWords |> Array.filter (fun s -> s = "href")
    (site, html.Length, hwords.Length, hrefs.Length)

let time f =
    let start = DateTime.Now
    let res = f()
    let finish = DateTime.Now
    (res, finish - start)

// Using the time, http and getWords functions
let stats site =
    let url = "http://" + site
    let html, t = time (fun () -> http url)
    let words = html |> getWords
    let hrefs = words |> Array.filter (fun s -> s = "href")
    { Site = site
      Time = t
      Length = html.Length
      NumWords = words.Length
      NumHRefs = hrefs.Length }

printfn "%A" (stats "www.google.com")
