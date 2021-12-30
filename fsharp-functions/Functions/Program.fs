let cardFace (card: int) : string =
    let no = card % 13

    if no = 1 then "Ace"
    else if no = 11 then "Jack"
    else if no = 12 then "Queen"
    else if no = 0 then "King"
    else string no

printfn "%s" (cardFace 11)
