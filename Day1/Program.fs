let deltaCounts =
    Data.values
    |> Utils.getDeltaCounts

printfn "Number of increments: %i" deltaCounts

let slidingWindowDeltaCounts =
    Data.values 
    |> Utils.getSlidingWindowSums 
    |> Utils.getDeltaCounts

printfn "Number of sliding window of increments: %i" slidingWindowDeltaCounts