module Utils

open System

type Instruction =
    | Horizontal of value: int
    | Vertical of value: int

exception UnknownInstruction of string

let invert value = value * -1

let parseValue offset (value: string) =
    value.Substring(offset) 
    |> Int32.Parse

let parseData (data: string) =
    data.Split "\n"
    |> Array.map (fun line ->
        match line.Trim() with
        | line when line.StartsWith "forward" -> line |> parseValue 7 |> Instruction.Horizontal
        | line when line.StartsWith "backward" -> line |> parseValue 8 |> invert |> Instruction.Horizontal
        | line when line.StartsWith "up" -> line |> parseValue 2 |> invert |> Instruction.Vertical
        | line when line.StartsWith "down" -> line |> parseValue 4 |> Instruction.Vertical
        | _ -> raise (UnknownInstruction line)
    )

type Point = { X: int; Y: int }
type Location = { X: int; Y: int; Aim: int }

let navigateSimple (point: Point) instruction =
    match instruction with
    | Horizontal value -> { point with X = point.X + value }
    | Vertical value -> { point with Y = point.Y + value }

let navigateSimpleMany (instructions: Instruction[]) =
    instructions
    |> Seq.fold
        navigateSimple
        { X = 0; Y = 0 }

let navigate (location: Location) instruction =
    match instruction with
    | Horizontal value -> 
        { location with 
            X = location.X + value
            Y = location.Y + location.Aim * value
        }
    | Vertical value -> 
        { location with 
            Aim = location.Aim + value
        }
        
let navigateMany (instructions: Instruction[]) =
    instructions
    |> Seq.fold
        navigate
        { X = 0; Y = 0; Aim = 0 }