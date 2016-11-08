open System.Drawing

type LabelInfo(?text : string, ?font : Font) =
    let text = defaultArg text ""
    let font =
        match font with
        | None -> new Font(FontFamily.GenericSansSerif, 12.0f)
        | Some v -> v
    member x.Text = text
    member x.Font = font

    /// Define a static method that creates an instance
    static member Create(?text, ?font) =
        new LabelInfo(?text = text, ?font = font)

// Create LabelInfo values
let labelHelloWorld = LabelInfo (text = "Hello World")
let labelLenin = LabelInfo ("Goodbye Lenin")
let labelMonospace =
    LabelInfo (
        font = new Font(FontFamily.GenericMonospace, 36.0f),
        text = "Imagine")
