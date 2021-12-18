module Utils

let parseValue =
    Seq.map 
        (fun c -> System.Int32.Parse(c.ToString()))

let countBits (values: string seq) =
    values 
    |> Seq.tail
    |> Seq.fold
        (fun counts value -> 
            Seq.map2 
                (fun x y -> x + y) 
                counts
                (parseValue value)
        )
        (values |> Seq.head |> parseValue)

let getRates (values: string[]) =
    let half = values.Length / 2
    let gamma = 
        countBits values
        |> Seq.map
            (fun count -> if count >= half then "1" else "0")
        |> String.concat ""
    let epsilon = 
        gamma
        |> String.map 
            (fun c -> if c = '1' then '0' else '1')
    {|
        Gamma = System.Convert.ToInt32(gamma, 2)
        Epsilon = System.Convert.ToInt32(epsilon, 2)
    |}