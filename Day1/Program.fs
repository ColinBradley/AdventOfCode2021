printfn "Number of increments: %i" (County.getDeltaCounts Data.values).IncrementCount

let slidingWindowSums = County.getSlidingWindowSums Data.values

printfn "Number of sliding window of increments: %i" (County.getDeltaCounts slidingWindowSums).IncrementCount

exit 0