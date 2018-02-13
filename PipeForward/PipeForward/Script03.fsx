////////////////////////////////////////////////////////////////////////////////////
// 3.1 List creation

let list1 = [1 .. 100]          
let list2 = [50 .. 80]
let list3 = [1 .. 2 .. 100]      

let list4 = [1.0 .. 100.0]      
let list5 = [0.0 .. 0.05 .. 1.0]

let list6 = [1; 20; 50; 100; 55; 5; 10]
let list7 = [1.0; 6.0; 5.0; 10.0; 3.0; 2.0]

let list8 = ["ABC";"DEF";"GHI";"JKL";"MNO"]

// ####################################################
// ERROR: Cannot have a list with different types.  //#
let listError = ["ABC"; 123; 400.0]                 //#
// ####################################################

////////////////////////////////////////////////////////////////////////////////////
// 3.2 List.filter
let IsItEven x = (x % 2 = 0)

let trueOrFalse1 = IsItEven 10
let trueOrFalse2 = IsItEven 3

/////////////////////////////////////////
// List.filter
let result1 = List.filter IsItEven [1 .. 100]

// With anonymous/lambda function:
let result2 = List.filter (fun x -> x % 2 = 0) [1 .. 100]

////////////////////////////////////
// List.filter and |>

let SumMultiplesOfThree xList =
    xList
    |> List.filter (fun x -> x % 3 = 0)
    |> List.sum

// See the pdf file for a detailed explanation of the code.
    
// 3 + 6 + 9 + ... + 99 = 1683
let result3 = SumMultiplesOfThree [1 .. 100]

// 3 + 6 + 9 + ... + 198 = 6633
let result4 = SumMultiplesOfThree [1 .. 200]

//////////////////////////////////////////////////////////////////////////////////////
// Another example:

let CountGreaterThan80 scoreList =
    scoreList
    |> List.filter (fun x -> x >= 80)
    |> List.length
    
let result5 = CountGreaterThan80 [60; 65; 70; 75; 80; 85; 90; 95]
printfn "%i students scored 80 or above." result5

/////////////////////////////////////////////////////////////////////////////////////
// Example:
let SumMultiplesOf3ButNot5 xList =
    xList
    |> List.filter (fun x -> (x % 3 = 0) && (x % 5 <> 0))
    |> List.sum
    
// Include multiples of 3, e.g. 3, 6, 9, 12,......
// but ignore multiples of 5, e.g. 15, 30, 45,.......
let result6 = SumMultiplesOf3ButNot5 [1 .. 100]

/////////////////////////////////////////////////////////////////////////////////////
// Exercise: 
// Implement a function that sums up all multiples of 3 or 5 in a list.
let SumMultiplesOf3Or5 xList =
    // Hint:  || means OR, && means AND
    failwith "NOT IMPLEMENTED!" 

// Within 1 to 10, the multiples of 3 or 5 are 3, 5, 6, 9, 10
// 3 + 5 + 6 + 9 + 10 = 33
let result7 = SumMultiplesOf3Or5 [1 .. 10]

// You can create an account, and submit your answers here for personal achievement/accomplishment.
// https://projecteuler.net/problem=1
let result8 = SumMultiplesOf3Or5 [1 .. 999]
  
  
/////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////
// 3.3 List.map

let Square x = x * x
let result9 = List.map Square [1 .. 10]

// Alternatively, we can use the "fun" keyword to define the "Square" function
let result10 = List.map (fun x -> x * x) [1 .. 100]

////////////////////////////////////////
// List.map and |>

let SumOfSquares xList =
    xList
    |> List.map (fun x -> x * x)
    |> List.sum
    
let result11 = SumOfSquares [1 .. 10]
printfn "Sum of squares from 1 to 10 is: %i" result11

/////////////////////////////////////////////////////////////////////////////
// Exercise: 
let originalPrice1 = 1.35
let originalPrice2 = 3.99

let newPrice1 = originalPrice1 |> System.Math.Floor
let newPrice2 = originalPrice2 |> System.Math.Floor

// Temporary ignore decimal numbers like 1.50, 2.50.
let newPrice3 = originalPrice1 |> System.Math.Round
let newPrice4 = originalPrice2 |> System.Math.Round

// Round down the prices to nearest integer.
let TotalPriceAfterRoundDown priceList =


    failwith "NOT YET IMPLEMENTED!"

    
// Round the prices to closest integer (ignore 1.50, 2.50, etc.)
let TotalPriceAfterRound priceList =


    failwith "NOT YET IMPLEMENTED!"

/////////////////////

let originalBasket = [1.99; 4.39; 5.00; 2.10; 8.05]

let totalPrice1 = TotalPriceAfterRoundDown originalBasket
let totalPrice2 = TotalPriceAfterRound originalBasket

/////////////////////////////////////////////////////////////////////////////
// Simple application:

// https://www.miniwebtool.com/sample-variance-calculator/
// Or you can use the excel function of VAR.s

let SampleVariance xList =
    let N = 
        xList
        |> List.length
        |> double         // The "double" function 

    let average = 
        xList
        |> List.average

    // return this:
    xList
    |> List.map (fun x -> (x - average) ** 2.0)
    |> List.sum
    |> fun final -> final / (N - 1.0)       // cannot divide by (N - 1), because decimal.

/////
    
let result12 = SampleVariance [1.0 .. 7.0]

/////////////////////////////////////////////////////////////////////////////////////
// Exercise:

// Fill in the code below, that will help you solve Problem6 in Project Euler (see the URL)

// You can create an account, and submit your answers here for personal achievement/accomplishment.
// https://projecteuler.net/problem=6

let ProjectEulerProblem6 xList =
    // if xList = [a;b;c], calculate a^2 + b^2 + c^2
    let sumOfSquares = 
        failwith "NOT YET IMPLEMENTED!"

    // if xList = [a;b;c], calculate a + b + c
    let sum =
        failwith "NOT YET IMPLEMENTED!"

    // return
    (sum * sum) - sumOfSquares

    
///////// Test:
let result13 = ProjectEulerProblem6 [1 .. 100]
printfn "Answer for ProjectEuler Problem6 is: %i" result13

///////////////////////////////////////////////////////////////////////////////////////////
// Another exercise:


// Remark: This tutorial has already helped you implement the "IsPrime" function
// 
// You can just use it. No need to re-implement it.
let IsPrime x =
    let squareRoot = x |> double |> sqrt |> int 
    if x = 1 then false
    else if x = 2 then true
    else if x % 2 = 0 then false
    else 
        [3 .. 2 .. squareRoot]
        |> List.forall (fun i -> x%i <> 0)
        
printfn "Is 5 a prime? %b" (IsPrime 5)
printfn "Is 9 a prime? %b" (IsPrime 9)


let numberOfPrimesWithinRange =
    [2 .. 500000]
    // |> ..........
    // |> ..........
    
    failwith "NOT YET IMPLEMENTED!"

    // Implement the logic above.

/////////////////////////////////////////
// We can use List.item to get the Nth item in a list. 
// But be careful of zero-based index!
let word1 = List.item 3 ["A"; "B"; "C"; "D"; "E"]

let word2 = List.item 5 ["A"; "B"; "C"; "D"; "E"; "F"; "G"; "H"; "I"; "J"]

/////////////////////////////////////////
// To find the 10001-th element of a list, use "List.item 10000"

let find10001thPrime =
    [2 .. 500000]
    // |> ..........
    // |> ..........

    failwith "NOT YET IMPLEMENTED"

///////////////////////////////////////////////////////////////////////////////////////////
// Another exercise:

// Remark: This tutorial has already helped you implement the "IsPrime" function
// 
// You can just use it. No need to re-implement it.
let IsPrime x =
    let squareRoot = x |> double |> sqrt |> int 
    if x = 1 then false
    else if x = 2 then true
    else if x % 2 = 0 then false
    else 
        [3 .. 2 .. squareRoot]
        |> List.forall (fun i -> x%i <> 0)
// Remark: No need to understand the code above. Just use it like below.

printfn "Is 5 a prime? %b" (IsPrime 5)
printfn "Is 9 a prime? %b" (IsPrime 9)

//////////////////////////////////////

// Write a function that accepts a list of integer "xList",
// and sums up all prime numbers.
let Problem10_Version1 xList =

    failwith "NOT IMPLEMENTED!"
    
// test:
let result14 = Problem10_Version1 [1 .. 9]
// 2 + 3 + 5 + 7 = 17.

let result15 = Problem10_Version1 [1 .. 99]
// 2 + 3 + 5 + 7 + 11 + ... + 83 + 89 + 97 = 1060.

////////////////////////////////////////
// However, if you try the following, you may get an error:
let result16 = Problem10_Version1 [2 .. 2000000]
// POTENTIAL ERROR!

// This is because there are too many numbers to add up,
// and "int" is not capable of handling large sum.

////////////////////////////////////////

// We use BigInteger instead:

open System.Numerics

let SumAllPrimes xList =
    xList
    |> List.filter (IsPrime)
    |> List.map (BigInteger)
    |> List.sum

// Remark: The code below can take 10 seconds, as this is not the most optimal algorithm.
let result17 = SumAllPrimes [2 .. 2000000]
printfn "The sum of all primes from 2 to 2000000 is: %A" result17

////////////////////////////////////////////////////////////////////////////////
// Optional exercise:

open System.Numerics

// Remark: This tutorial has already helped you implement the "IsPrimeBigInteger" function
// 
// You can just use it. No need to re-implement it.
let IsPrimeBigInteger x =
    let squareRoot = x |> double |> sqrt |> BigInteger 
    if x = BigInteger(1) then false
    else if x = BigInteger(2) then true
    else if x % BigInteger(2) = BigInteger(0) then false
    else 
        [BigInteger(3) .. BigInteger(2) .. squareRoot]
        |> List.forall (fun i -> x%i <> BigInteger(0))

///////////////////////


// Assumption: bigNumber has a square root that is not too large.
//
// Assumption: bigNumber itself is not prime.
let FindLargestPrimeFactor (Z: BigInteger) =
    let approxSqrt = Z |> double |> sqrt |> BigInteger

    // Find factors of Z between [2 .. sqrt(Z)]
    // Not necessarily prime factors.
    let list1 =
        [BigInteger(2) .. approxSqrt]
        // |> ..................


        failwith "NOT IMPLEMENTED YET!"

    // Produce another list such that:
    // For each element "a" in list1, it gives "Z / a"
    let list2 = 

    
        failwith "NOT IMPLEMENTED YET!"
    
    // List.append combines the two lists.
    let combinedList =
        List.append list1 list2
        
    // Choose only prime numbers from the combinedList, and find the maximum using List.max
    combinedList
    // |> ......................

    // Complete the logic above.

/////////////////

let number1 = BigInteger(21)
let result18 = FindLargestPrimeFactor number1  
// Expect result: 7

let number2 = BigInteger(66)
let result19 = FindLargestPrimeFactor number2
// Expect result: 11

let number3 = BigInteger.Parse("600851475143")
let result20 = FindLargestPrimeFactor number3