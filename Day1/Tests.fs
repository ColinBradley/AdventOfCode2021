module Tests

open Xunit

let testValues =
    [| 199
       200
       208
       210
       200
       207
       240
       269
       260
       263 |]

[<Fact>]
let ``Provided example 1`` () =
    Assert.Equal(7, (County.getDeltaCounts testValues).IncrementCount)

[<Fact>]
let ``Provided example 2`` () =
    Assert.Equal(5, (County.getSlidingWindowSums testValues |> County.getDeltaCounts).IncrementCount)