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

// ERROR: Cannot have a list with different types.
//let listError = ["ABC"; 123; 400.0]

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
// 3.3 List.filter and |>

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
// List.map

let Square x = x * x
let result9 = List.map Square [1 .. 10]

// Alternatively, we can use the "fun" keyword to define the "Square" function
let result10 = List.map (fun x -> x * x) [1 .. 100]

// Here, we replaced "IsItEven" in the code above with:
// 1. "fun":   A function......            "fun" is a keyword in F# !
// 2.   x  : ...that takes an input x...
// 3.  ->  : ...and returns...
// 4.  x*x: ... x multiplied with x

// Again, we define this function using the "fun" keyword at the exact location where we need it.
// It increases productivity.

////////////////////////////////////////
// Let's see it together with the pipe-forward operator:

// Another example:
let SumOfSquares xList =
    xList
    |> List.map (fun x -> x * x)
    |> List.sum

// What this code does is the following:

// 1. It starts with a List of integers (xList)

// 2. and apply this input (using the first |> symbol) to the first function.

// 2 a. This first function transforms/maps each element (List.map) in the input list
// 2 b. Each number is converted/mapped to the square of itself (fun x -> x * x)
// 2 c. The filtering process requires a function (fun x -> ......)

// 3. After the previous process is done, we have an intermediateResult, a List of remaining scores.
// 3 a. Then we apply this intermediateResult (using the second |> symbol) to the second function.
// 3 b. This second function sums up all the elements inside. (List.sum)

// 1^2 + 2^2 + 3^2 + 4^2 + ... + 10^2 = 385
let result11 = SumOfSquares [1 .. 10]
printfn "Sum of squares from 1 to 10 is: %i" result11

/////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////
// Simple application:

// https://www.miniwebtool.com/sample-variance-calculator/
// Or you can use the excel function of VAR.s

let SampleVariance xList =
    let N = 
        xList
        |> List.length
        |> double         // The "double" function takes an integer and convert to double
                          // You can also convert strings to double.
    let average = 
        xList
        |> List.average

    // return this:
    xList
    |> List.map (fun x -> (x - average) ** 2.0)
    |> List.sum
    |> fun final -> final / (N - 1.0)       // cannot divide by (N - 1), because decimal.
    
// Remark: The compiler knows xList is List<double> or List<float>
// because interacted with List.map at some point, and also interacted with "** 2.0"
    
let result12 = SampleVariance [1.0 .. 7.0]
printfn "The Sample Variance of 1 to 7 is: %f" result12

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
printfn "The result for ProjectEuler Problem6 is: %i" result13

