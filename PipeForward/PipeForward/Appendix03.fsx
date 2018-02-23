
open System.Numerics

let rec GCD x y =
    let zero = BigInteger(0)
    if x < zero || y < zero then failwith "CANNOT ACCEPT NEGATIVE NUMBERS"
    if x > y then GCD y x
    else if x = zero then y
    else GCD (y % x) x

let LCM x y = 
    x * y / (GCD x y)

let result =
    [1 .. 20]
    |> List.map (BigInteger)
    |> List.reduce LCM
