let canFastAttack (knightIsAwake: bool) : bool = not knightIsAwake

let canSpy (knightIsAwake: bool, archerIsAwake: bool, prisionerIsAwake: bool) : bool =
    knightIsAwake || archerIsAwake || prisionerIsAwake

let canSignalPrisioner (archerIsAwake: bool, prisionerIsAwake: bool) : bool = not archerIsAwake && prisionerIsAwake

let canFreePrisoner (knightIsAwake: bool, archerIsAwake: bool, prisionerIsAwake: bool, petDogIsPresent: bool) : bool =
    match petDogIsPresent with
    | true -> not archerIsAwake
    | false ->
        prisionerIsAwake
        && not knightIsAwake
        && not archerIsAwake

printfn $"Can fast attack: {canFastAttack (true)}"
printfn $"Can spy: {canSpy (false, true, false)}"
printfn $"Can signal prisioner: {canSignalPrisioner (false, true)}"
printfn $"Can free prisioner: {canFreePrisoner (false, true, false, false)}"
