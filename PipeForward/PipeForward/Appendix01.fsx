// Project Euler Question 3 Original

open System.Numerics

let IsPrimeBigInteger x =
    let squareRoot = x |> double |> sqrt |> BigInteger 
    if x = BigInteger(1) then false
    else if x = BigInteger(2) then true
    else if x % BigInteger(2) = BigInteger(0) then false
    else 
        [BigInteger(3) .. BigInteger(2) .. squareRoot]
        |> List.forall (fun i -> x%i <> BigInteger(0))

        
let FindLargestPrimeFactor (Z: BigInteger) =
    let approxSqrt = Z |> double |> sqrt |> BigInteger

    // Find factors of Z between [2 .. sqrt(Z)]
    // Not necessarily prime factors.
    let list1 =
        [BigInteger(2) .. approxSqrt]
        |> List.filter (fun x -> Z % x = BigInteger(0))

    // Produce another list such that:
    // For each element "a" in list1, it gives "Z / a"
    let list2 =
        list1
        |> List.map (fun a -> Z / a)

    // List.append combines the two lists.
    let combinedList =
        List.append list1 list2

    // Choose only prime numbers from the combinedList, and find the maximum using List.max
    combinedList
    |> List.filter (IsPrimeBigInteger)
    |> List.max
    


let number1 = BigInteger(21)
let result18 = FindLargestPrimeFactor number1  
// Expect result: 7

let number2 = BigInteger(66)
let result19 = FindLargestPrimeFactor number2
// Expect result: 11

let number3 = BigInteger.Parse("600851475143")
let result20 = FindLargestPrimeFactor number3