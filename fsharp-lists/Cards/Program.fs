let drawCard (tuple: int list * int list) =
    let deck = fst tuple
    let draw = snd tuple
    let firstCard = deck.Head
    printfn "%i" firstCard

    let hand =
        draw
        |> List.append [firstCard]

    (deck.Tail, hand)

let cards = [ 0 .. 5]
let hand = []

let d, h = (cards, hand) |> drawCard |> drawCard

printfn "Deck: %A Hand: %A" d h
