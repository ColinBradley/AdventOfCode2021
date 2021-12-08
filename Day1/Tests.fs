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
    Assert.Equal(7, (Utils.getDeltaCounts testValues).IncrementCount)

[<Fact>]
let ``Provided example 2`` () =
    Assert.Equal(5, (Utils.getSlidingWindowSums testValues |> Utils.getDeltaCounts).IncrementCount)