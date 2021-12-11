module Utils

type DeltaCountState = { IncrementCount: int; DecrementCount: int; PreviousValue: int}

let getDeltaCounts items =
    let result =
        items 
        |> Seq.tail 
        |> Seq.fold
            (fun acc item ->
                match acc.PreviousValue with
                | p when p < item -> { acc with IncrementCount = acc.IncrementCount + 1; PreviousValue = item }
                | p when p > item -> { acc with DecrementCount = acc.DecrementCount + 1; PreviousValue = item }
                | _ -> { acc with PreviousValue = item })
            { IncrementCount = 0; DecrementCount = 0; PreviousValue = Seq.head items }
    result.IncrementCount

let getSlidingWindowSums (items : int array) =
     let windowSize = 3
     seq {
         for index in 0..items.Length - windowSize do
             items 
             |> Seq.skip index 
             |> Seq.take windowSize
             |> Seq.sum
         }
