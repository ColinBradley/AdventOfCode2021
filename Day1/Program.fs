printfn "Number of increments: %i" (Utils.getDeltaCounts Data.values).IncrementCount

let slidingWindowSums = Utils.getSlidingWindowSums Data.values

printfn "Number of sliding window of increments: %i" (Utils.getDeltaCounts slidingWindowSums).IncrementCount

exit 0