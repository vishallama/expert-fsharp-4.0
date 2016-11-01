exception BlockedURL of string

let blockedURL = "http://www.kaos.org"
let http2 url =
    if url = blockedURL
    then raise (BlockedURL(url))
    else "process url"

try
    raise (BlockedURL (blockedURL))
with
    BlockedURL url -> printfn "blocked! url = %s" url
