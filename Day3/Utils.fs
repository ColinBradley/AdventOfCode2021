module Utils

let toInt32Array (value: string) =
    Seq.map
        (fun c -> System.Int32.Parse(c.ToString()))
        value
    |> Seq.toArray

let countBits values =
    Array.fold
        (fun counts value -> 
            Array.map2
                (+)
                counts
                (toInt32Array value)
        )
        (values |> Array.head |> toInt32Array)
        (values |> Array.tail)

let getMostCommonBits (values: string[]) =
    let half = float values.Length / 2.0
    countBits values
        |> Seq.map
            (fun count -> if float count >= half then "1" else "0")
        |> String.concat ""

let invertBits bits =
    String.map 
        (fun c -> if c = '1' then '0' else '1')
        bits

let parseBinary value =
    System.Convert.ToInt32(value, 2)

let getPowerRates values =
    let gamma = getMostCommonBits values
    {|
        Gamma = gamma |> parseBinary
        Epsilon = invertBits gamma |> parseBinary
    |}

let rec filterToBitMask values invert bitIndex =
    let mask = 
        if invert then
            getMostCommonBits values |> invertBits
        else
            getMostCommonBits values

    let filteredValues = 
        values |> Array.filter (fun value -> value[bitIndex] = mask[bitIndex])

    if filteredValues.Length = 1 then
        filteredValues[0]
    else
        filterToBitMask filteredValues invert (bitIndex + 1)

let getLifeSupportRates values =
    {|
        Oxygen = filterToBitMask values false 0 |> parseBinary
        CO2 = filterToBitMask values true 0 |> parseBinary
    |}