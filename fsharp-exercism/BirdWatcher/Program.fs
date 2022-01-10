module BirdWatcher

let lastWeek = [| 0; 2; 5; 3; 7; 8; 4 |]

let yesterday: int [] -> int = Array.rev >> Array.skip 1 >> Array.head
let total: int [] -> int = Array.sum
let dayWithoutVisits: int [] -> bool = Array.contains 0

let incrementTodaysCount (counts: int []) : int [] =
    let copy = Array.copy counts
    copy[copy.Length - 1] <- copy[copy.Length - 1] + 1
    copy


printfn $"Yesterday: ${yesterday lastWeek}"
printfn $"Total: ${total lastWeek}"
printfn $"No visits: ${dayWithoutVisits lastWeek}"
printfn "Incrementing: %A" ((incrementTodaysCount lastWeek) |> Seq.toList)
