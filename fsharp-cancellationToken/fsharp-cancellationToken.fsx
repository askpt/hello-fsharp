open System.Threading
open System.Linq

let busyWait () =
    for _ in Enumerable.Repeat(0, 150000000) do
        ()

let task () =
    async {
        let! ct = Async.CancellationToken
        printfn "Starting"
        do! Async.Sleep(1000)
        printfn "Waiting"

        if ct.IsCancellationRequested then
            printfn "Cancelled"
        else
            do! Async.Sleep(1000)
            printfn "Waiting"

            if ct.IsCancellationRequested then
                printfn "Canceled"
            else
                do! Async.Sleep(1000)
                printfn "Waiting"

                if ct.IsCancellationRequested then
                    printfn "Canceled"
                else
                    do! Async.Sleep(1000)
                    printfn "Completed"
    }

let task2 () =
    async {
        let! ct = Async.CancellationToken
        printfn "Starting"

        while (ct.IsCancellationRequested = false) do
            printfn "Waiting"

            if ct.IsCancellationRequested then
                printfn "Cancelled"

            do! Async.Sleep(1000)

            if ct.IsCancellationRequested then
                printfn "Cancelled"

        if ct.IsCancellationRequested then
            printfn "Cancelled"
    }

let task3 () =
    async {
        printfn "Starting"
        // Async.OnCancel(fun -> printfn "Cancelled")

        while (true) do
            printfn "Waiting"

            do! Async.Sleep(1000)
    }

let example1 () =
    printfn "Example 1"
    let cts = new CancellationTokenSource(150)
    // We don't care about child work being cancelled
    Async.Start(task (), cts.Token)
    // Async.Sleep 1500 |> Async.RunSynchronously
    // cts.Cancel()
    printf "Waiting for user input"
    System.Console.ReadKey() |> ignore

let example2 () =
    printfn "Example 2"
    let cts2 = new CancellationTokenSource(5000)
    Async.Start(task2 (), cts2.Token)

    // cts2.CancelAfter(5000)
    printfn "Waiting for user input"
    System.Console.ReadKey() |> ignore

let example3 () =
    printfn "Example 3"
    let cts3 = new CancellationTokenSource(5000)
    Async.Start(task3 (), cts3.Token)

    printfn "Waiting for user input"
    System.Console.ReadKey() |> ignore

// example ()
// example2 ()
example3 ()
