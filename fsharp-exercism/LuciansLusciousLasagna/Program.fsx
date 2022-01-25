let expectedMinutesInOven: int = 40

let remainingMinutesInOven (actualMinutes: int) : int = expectedMinutesInOven - actualMinutes
let preparationTimeInMinutes (layers: int) : int = layers * 2

let elapsedTimeInMinues (layers: int, minutesInOven: int) : int =
    preparationTimeInMinutes (layers)
    + remainingMinutesInOven (minutesInOven)


printfn $"Remaining minutes in oven: ${remainingMinutesInOven (30)}"
printfn $"Layers: ${preparationTimeInMinutes (2)}"
printfn $"Elapsed time: ${elapsedTimeInMinues (3, 20)}"
