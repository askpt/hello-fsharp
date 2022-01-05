open System

let exceptionNull (value) : string =
    ArgumentNullException.ThrowIfNull value
    string value

// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

try
    let value = exceptionNull null
    printfn "%s" value
with
| Failure e -> printfn "%s" e
