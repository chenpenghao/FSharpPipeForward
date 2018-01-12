
// Optional exercise:
// 1. This exercise spends a bit of time on something not so relevant: BigInteger/integer overflow.
// 1a. You can skip this first, and come back when you are interested.

/////////////////////////////////////////////////////////////////////////////////////

// Remark: This tutorial has already helped you implement the "IsPrime" function
// 
// This is a function that tells you whether a number is prime number or not.
//
// You do not need to understand the code, or to re-implement it.
//
// You just need to use the function "IsPrime".
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

/////////////////////////////////////////////////////////////////////////////////////

// Exercise: Project Euler Problem10
// https://projecteuler.net/problem=10

// Here, try to implement a function, that takes a list of numbers,
// and filter it so that only prime numbers remain.
// Then, find their sum.

let Problem10_Version1 (xList: List<int>) =

    failwith "NOT IMPLEMENTED!"

    
// test:
let result1 = Problem10_Version1 [1 .. 9]
printfn "The sum of prime numbers less than 10 is: %i" result1
// Expect 17.

let result2 = Problem10_Version1 [1 .. 99]
printfn "The sum of prime numbers less than 100 is: %i" result2
// Expect 1060.

////////////////////////////////////////
// However, if you try the following, you get an error:
let result3: int = Problem10_Version1 [2 .. 2000000]

// Why is there an error here?

//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////

// DISCUSSION: BigInteger
// There is an upper limit on the largest integer that you can calculate:

let number1 = 1000000000

// The code below works, but contains error.
let tooLargeError = number1 + number1 + number1
// ??? Why is the result negative ??? 

// This is because the largest integer that can be stored in a 32-bit signed integer is
// 2^32 - 1 = 2,147,483,647
// So, if we add too large numbers, then it will wrap around to the negative numbers.

// One way to solve this problem is to use the F# provided datatype, System.Numerics.BigInteger

open System.Numerics

// The "BigInteger" is a constructor or function that converts integer to "BigInteger"
let number1Converted = 1000000000 |> BigInteger

// No problem here!
let resultNoProblem = number1Converted + number1Converted + number1Converted

/////////////////////////////////////

// Similarly, if you have a list of integers that will cause error when summed together,
// It may be a good idea to convert individual into "BigInteger"

let numbersList = [1000000000;1000000000;1000000000;1000000000]

// Error: Cause overflow
let errorSum = List.sum numbersList

let bigIntegerList = numbersList |> List.map (BigInteger)

// No problem here!
let correctSum = List.sum bigIntegerList

////////////////////////////////////////////////////////////////////////////////////////

// Here, let's try to approach Problem 10 again.

// You can create an account, and submit your answers here for personal achievement/accomplishment.
// https://projecteuler.net/problem=10

open System.Numerics

let SumAllPrimes xList : BigInteger=
    // Hints/steps:
    // 1. Start with xList
    // 2. Filter the list, so that only prime numbers remain in the list. Use the "IsPrime" function.
    // 3. Convert each "integer" to "BigInteger", because "integers" are not designed to handle large sums.
    //    Use the "BigInteger" function/constructor
    // 4. sum up the list. List.sum

    failwith "NOT IMPLEMENTED!"

// Remark: The code below can take 10 seconds, as this is not the most optimal algorithm.
let result15 = SumAllPrimes [2 .. 2000000]
printfn "The sum of all primes from 2 to 2000000 is: %A" result15