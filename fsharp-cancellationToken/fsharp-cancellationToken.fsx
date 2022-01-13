open System.Threading
open System.Linq

let busyWait () =
    for _ in Enumerable.Repeat(0, 150000000) do
        ()

let task () =
    async {
        let! ct = Async.CancellationToken
        printfn "Starting"
        busyWait ()
        printfn "Waiting"

        if ct.IsCancellationRequested then
            printfn "Cancelled"
        else
            busyWait ()
            printfn "Waiting"

            if ct.IsCancellationRequested then
                printfn "Canceled"
            else
                busyWait ()
                printfn "Waiting"

                if ct.IsCancellationRequested then
                    printfn "Canceled"
                else
                    busyWait ()
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

let example1 () =
    printfn "Example 1"
    let cts = new CancellationTokenSource()
    Async.Start(task (), cts.Token)
    Async.Sleep 1500 |> Async.RunSynchronously
    cts.Cancel()
    System.Console.ReadKey() |> ignore

let example2 () =
    printfn "Example 2"
    let cts2 = new CancellationTokenSource()
    Async.Start(task2 (), cts2.Token)
    cts2.CancelAfter(5000)
    Async.Sleep 15000 |> Async.RunSynchronously
    System.Console.ReadKey() |> ignore

// example1 ()
example2 ()
