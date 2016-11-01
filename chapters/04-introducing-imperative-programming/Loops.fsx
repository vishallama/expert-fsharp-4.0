open System.Text.RegularExpressions

for m in Regex.Matches("All the Pretty Horses", "\w+") do
    printfn "match = %s" m.Value
