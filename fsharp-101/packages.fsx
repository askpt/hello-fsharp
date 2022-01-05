#r "nuget:FSharp.Data,4.1.1"

open FSharp.Data

let html =
    Http.RequestString("https://www.fsharp.org/")

printf "%s" html
