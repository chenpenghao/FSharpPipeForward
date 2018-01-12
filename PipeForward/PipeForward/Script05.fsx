// Key-concept: 
// 1. First look at List function
// 1a. List.filter
// 1b. List.map

// 2. Code in F# are very easy to understand.
// 2a. The pipe-forward operator and the F# language design helps.

// 3. Anonymous function/lambda function also helps.
// 3a. You are defining a function at the exact location where it is most useful.
// 3b. And so it boosts productivity.
// 3c. "fun" is a keyword in F#! 



// We can create a list of integers/double/string using the following notation:
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

// Here is a simple function that returns true/false.
let IsItEven x = (x % 2 = 0)

// x % 2 mean the remainder after we divide x by 2
// (x % 2 = 0) means "is the remainder (after the division by 2) equal to zero?"
// i.e. is x divisible by 2?

let trueOrFalse1 = IsItEven 10
let trueOrFalse2 = IsItEven 3


/////////////////////////////////////////
// List.filter

let result1 = List.filter IsItEven [1 .. 100]

// The List.filter function filters a list, and only select the elements which satisfy some requirement.
// The requirement is specified through a function "IsItEven".


// Alternatively, because the definition of IsItEven is quite easy, we can even implement it immediately after
// List.filter, at the point where we need it the most.

let result2 = List.filter (fun x -> x % 2 = 0) [1 .. 100]

// Here, we replaced "IsItEven" in the code above with:
// 1. "fun":   A function......            "fun" is a keyword in F# !
// 2.   x  : ...that takes an input x...
// 3.  ->  : ...and returns...
// 4.  x%2=0: ... whether x is divisible by 2

// Again, we don't want to waste time figuring out a name for our function "IsItEven", 
// If we define too many such custom function, it will be hard to keep track,
// And we will lose productivity.

// We define this function using the "fun" keyword at the exact location where we need it.


////////////////////////////////////
// Let's say we apply this function with the pipe-forward operator "|>"

// Take a look at this function:

let SumOfMultiplesOfThree xList =
    xList
    |> List.filter (fun x -> x % 3 = 0)
    |> List.sum

// What this function do is the following:
// 1. It starts with a List of integer (xList)

// 2. and apply this input (using the first |> symbol) to the first function.

// 2 a. This first function filters (List.filter) the input list
// 2 b. So that only multiples of 3 are accepted/retained (fun x -> x % 3 = 0)

// 3. After the previous process is done, we have an intermediateResult.
// 3 a. Then we apply this intermediateResult (using the second |> symbol) to the second function.
// 3 b. This second function just sums up (List.sum) the remaining elements after the filtering process.

// So, F# is able to express all of these calculations with just 3 lines of code.
// Which is quite elegant, maybe similar to Python code (in style)
// compared to other more traditional languages (Java/C++) which we need to write longer.

let result3 = SumOfMultiplesOfThree [1 .. 1000]
printfn "The sum of multiples of 3, starting from 1 to 1000 is: %i" result3

let result4 = SumOfMultiplesOfThree [1 .. 20000]
printfn "The sum of multiples of 3, starting from 1 to 20000 is: %i" result4



///////////////////////////////////////////////////
// In the previous code, the "List.filter" needs an additional function to determine 
// which elements to keep (and which one to remove).

// Previous version:
//let SumOfMultiplesOfThree xList =
//    xList
//    |> List.filter (fun x -> x % 3 = 0)
//    |> List.sum

// Here we have a slightly wordy/unnecessarily longer version.
let SumOfMultiplesOfThree_Version2 xList =
    let IsDivisibleByThree x = (x % 3 = 0)
    xList
    |> List.filter IsDivisibleByThree
    |> List.sum

// Here, we have to waste time, to painfully define a new function "IsDivisibleByThree" 
// to determine whether the input "x" is divisible by 3 or not. 
// Which means it is something extra that we need to keep track of, which is bad.
// Just like Python, we hope to aim for minimally understandable code that is easy to maintain.


//////////////////////////////////////////////////////////////////////////////////////
// Another example:

// Let's say you want to find out how many students in your class got at least 80 points in an exam.

let CountGreaterThan80 scoreList =
    scoreList
    |> List.filter (fun x -> x >= 80)
    |> List.length
    
// What this function do is the following:
// 1. It starts with a List of scores (scoreList)

// 2. and apply this input (using the first |> symbol) to the first function.

// 2 a. This first function filters (List.filter) the input list
// 2 b. So that only numbers at least 80 are accepted/retained (x >= 80)
// 2 c. The filtering process requires a function (fun x -> ......)

// 3. After the previous process is done, we have an intermediateResult, a List of remaining scores.
// 3 a. Then we apply this intermediateResult (using the second |> symbol) to the second function.
// 3 b. This second function just counts how many remaining students are there.
// 3 c. By finding the length (List.length) of the remaining List

let result5 = CountGreaterThan80 [60; 65; 70; 75; 80; 85; 90; 95]
printfn "This class has %i students scoring more than 80." result5

////////////////////////////////////////
// Again, we could have defined a new function, "IsAtLeast80" to replace the anonymous function.

// Original Version.
//let CountGreaterThan80 (scoreList: List<int>) =
//    scoreList
//    |> List.filter (fun x -> x >= 80)
//    |> List.length

let CountGreaterThan80_Version2 scoreList =
    let IsAtLeast80 x = (x >= 80)

    scoreList
    |> List.filter IsAtLeast80
    |> List.length

// But it makes it harder to understand, which is not helpful.

/////////////////////////////////////////////////////////////////////////////////////
// Example:
let SumMultiplesOf3ButNot5 xList =
    xList
    |> List.filter (fun x -> x % 3 = 0 && x % 5 <> 0)
    |> List.sum

// The function used to filter is saying the following:
// (x % 3 = 0): is x divisible by 3?
// (x % 5 <> 0): is x NOT a multiple of 5?

// So we include multiples of 3, e.g. 3, 6, 9, 12,......
// but we ignore multiples of 5, e.g. 15, 30, 45,.......
let result6 = SumMultiplesOf3ButNot5 [1 .. 100]
printfn "The sum is: %i" result6

/////////////////////////////////////////////////////////////////////////////////////
// Exercise: 
// Implement a function that sums up all multiples of 3 or 5 in a list.
let SumMultiplesOf3Or5 xList =
    // Hint:  || means OR, && means AND
    failwith "NOT IMPLEMENTED!" 

// Within 1 to 10, the multiples of 3 or 5 are 3, 5, 6, 9, 10
// 3 + 5 + 6 + 9 + 10 = 33
let result7 = SumMultiplesOf3Or5 [1 .. 10]
printfn "The result is: %i" result7

// You can create an account, and submit your answers here for personal achievement/accomplishment.
// https://projecteuler.net/problem=1
let result8 = SumMultiplesOf3Or5 [1 .. 999]
printfn "The sum of all multiples of 3 or 5, from 1 to 999 is: %i" result8
  

  
/////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////
// List.map

let Square x = x * x
let result9 = List.map Square [1 .. 10]


// The List.map function transform the individual element of a list using some transformation
// The transformation is specified through a function "Square".


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


///////////////////////////////////////////////////////////////////////
// Optional Problem:
// If you want, you can look at "Script50" as another application of List.filter and List.map
// But it discusses something extra (BigInteger and integer overflow)
// Which is not necessary to this workshop.