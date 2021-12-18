module Tests

open System
open Xunit

[<Fact>]
let ``Example 1`` () =
    Assert.StrictEqual(
        {| 
            Gamma = 22
            Epsilon = 9
        |},
        Utils.getRates Data.example1
    )