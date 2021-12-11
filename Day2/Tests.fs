module Tests

open System
open Xunit
open Utils

[<Fact>]
let ``Example 1`` () =
    let result = Data.testData1 |> parseData |> navigateSimpleMany
    Assert.StrictEqual({ X = 15; Y = 10 }, result)

[<Fact>]
let ``Example 2`` () =
    let result = Data.testData1 |> parseData |> navigateMany
    Assert.StrictEqual({ X = 15; Y = 60; Aim = 10 }, result)