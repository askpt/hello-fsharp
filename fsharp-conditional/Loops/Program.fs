let cardDescription (card: int) : string =
    let cardNo: int = card % 13

    if cardNo = 1 then "Ace"
    else if cardNo = 11 then "Jack"
    else if cardNo = 12 then "Queen"
    else if cardNo = 0 then "King"
    else string cardNo

let suit (no: int) : string =
    let suitNo: int = no / 13

    if suitNo = 0 then "Hearts"
    else if suitNo = 1 then "Spades"
    else if suitNo = 2 then "Diamonds"
    else "Clubs"

let cards = [ 1; 10; 2; 34 ]

for card in cards do
    printfn "%s of %s" (cardDescription (card)) (suit (card))
