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
        Utils.getPowerRates Data.example1
    )

[<Fact>]
let ``Example 2`` () =
    Assert.StrictEqual(
        {| 
            Oxygen = 23
            CO2 = 10
        |},
        Utils.getLifeSupportRates Data.example1
    )