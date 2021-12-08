module County

type DeltaCountState = { IncrementCount: int; DecrementCount: int; PreviousValue: int}

let getDeltaCounts items =
    Seq.fold
        (fun acc item ->
            match acc.PreviousValue with
            | p when p < item -> { acc with IncrementCount = acc.IncrementCount + 1; PreviousValue = item }
            | p when p > item -> { acc with DecrementCount = acc.IncrementCount + 1; PreviousValue = item }
            | _ -> { acc with PreviousValue = item })
        { IncrementCount = 0; DecrementCount = 0; PreviousValue = Seq.head items }
        (Seq.tail items)

let getSlidingWindowSums (items : int array) =
     let windowSize = 3
     seq {
         for index in 0..items.Length - windowSize do
             let window = Seq.skip index items |> Seq.take windowSize
             Seq.sum window
         }
