let powerResult = Utils.getPowerRates Data.userData

printfn "Power consumption = %i" (powerResult.Gamma * powerResult.Epsilon)

let lifeSupportResult = Utils.getLifeSupportRates Data.userData

printfn "Life support rating = %i" (lifeSupportResult.Oxygen * lifeSupportResult.CO2)