open Utils

let simpleResult = Data.userData |> parseData |> navigateSimpleMany

printfn "Simple result (Part One):\n%A\nValue = %i" simpleResult (simpleResult.X * simpleResult.Y)

let result = Data.userData |> parseData |> navigateMany

printfn "\nResult (Part Two):\n%A\nValue = %i" result (result.X * result.Y)
