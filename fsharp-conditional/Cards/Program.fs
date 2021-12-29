let cardNo = 12

let cardDescription =
    if cardNo = 1 || cardNo = 14 then
        "Ace"
    else if cardNo = 11 then
        "Jack"
    else if cardNo = 12 then
        "Queen"
    else if cardNo = 13 then
        "King"
    else
        string cardNo

printfn "The card is %s" cardDescription
