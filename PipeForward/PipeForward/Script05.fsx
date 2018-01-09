// Key-concept: 
// 1. Code in F# are very easy to understand.
// 1a. The pipe-forward operator and the F# language design helps.

// 2. Anonymous function/lambda function also helps.
// 2a. You are defining a function at the exact location where it is most useful.
// 2b. And so it boosts productivity.
// 2c. "fun" is a keyword in F#! 




////////////////////////////////////
// Example:

// Take a look at this function:

let SumOfMultiplesOfThree (xList: List<int>) =
    xList
    |> List.filter (fun x -> x % 3 = 0)
    |> List.sum

// What this function do is the following:
// 1. It starts with a List of integer (xList)

// 2. and apply this input (using the first |> symbol) to the first function.

// 2 a. This first function filters (List.filter) the input list
// 2 b. So that only multiples of 3 are accepted/retained (x % 3 = 0)
// 2 c. The filtering process requires a function (fun x -> ......)

// 3. After the previous process is done, we have an intermediateResult.
// 3 a. Then we apply this intermediateResult (using the second |> symbol) to the second function.
// 3 b. This second function just sums up (List.sum) the remaining elements after the filtering process.

// So, F# is able to express all of these calculations with just 3 lines of code.
// Which is quite elegant, compared to other more traditional languages (Java/C++)

let result1 = SumOfMultiplesOfThree [1 .. 1000]
printfn "The sum of multiples of 3, starting from 1 to 1000 is: %i" result1

let result2 = SumOfMultiplesOfThree [1 .. 20000]
printfn "The sum of multiples of 3, starting from 1 to 20000 is: %i" result2



///////////////////////////////////////////////////
// In the previous code, the "List.filter" needs an additional function to determine 
// which elements to keep (and which one to remove).

// Previous version:
//let SumOfMultiplesOfThree (xList: List<int>) =
//    xList
//    |> List.filter (fun x -> x % 3 = 0)
//    |> List.sum

// Here we have a slightly wordy/unnecessarily longer version.
let SumOfMultiplesOfThree_Version2 (xList: List<int>) =
    let IsDivisibleByThree x = (x % 3 = 0)
    xList
    |> List.filter IsDivisibleByThree
    |> List.sum

// Here, we painfully define a new function "IsDivisibleByThree" to determine whether the input "x"
// is divisible by 3 or not. 

// And so, the "List.filter" function happily accepts the "IsDivisibleByThree" function,
// even though the previous version "fun x -> x % 3 = 0" is also acceptable.

// But using the previous notation "fun x -> x % 3 = 0" is better, because:
// 1. You don't need to waste time to think of a name for your function. 
// 2. Once you get used to the syntax/writing style, you see that "IsDivisibleByThree" is 
//    no more helpful than "(fun x -> x % 3 = 0)"
// 2a. In fact, if lets say you used "IsDivisibleByThree" after 10,000 lines of code,
//     then in order to know what is going on in the "IsDivisibleByThree" function,
//     you need to go through tons of code in order to find the implementation.




//////////////////////////////////////////////////////////////////////////////////////
// Another example:

// Let's say you want to find out how many students in your class got at least 80 points in an exam.

let CountGreaterThan80 (scoreList: List<int>) =
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

let result3 = CountGreaterThan80 [60; 65; 70; 75; 80; 85; 90; 95]
printfn "This class has %i students scoring more than 80." result1


////////////////////////////////////////
// Again, we could have defined a new function, "IsAtLeast80" to replace the anonymous function.

// Original Version.
//let CountGreaterThan80 (scoreList: List<int>) =
//    scoreList
//    |> List.filter (fun x -> x >= 80)
//    |> List.length

let CountGreaterThan80_Version2 (scoreList: List<int>) =
    let IsAtLeast80 x = (x >= 80)

    scoreList
    |> List.filter IsAtLeast80
    |> List.length

// But it makes it harder to understand, which is not helpful.

/////////////////////////////////////////////////////////////////////////////////////
// Exercise: 
// Implement a function that sums up all multiples of 3 or 5 in a list.
let SumMultiplesOf3Or5 (xList: List<int>) =

    failwith "NOT IMPLEMENTED!" 

// Within 1 to 10, the multiples of 3 or 5 are 3, 5, 6, 9, 10
// 3 + 5 + 6 + 9 + 10 = 33
let result4 = SumMultiplesOf3Or5 [1 .. 10]
printfn "The result is: %i" result4

// You can create an account, and submit your answers here for personal achievement/accomplishment.
// https://projecteuler.net/problem=1
let result5 = SumMultiplesOf3Or5 [1 .. 999]
printfn "The sum of all multiples of 3 or 5, from 1 to 999 is: %i" result5
  

  
/////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////

// Continue to write tutorial here.......................

// To be completed by HaiBin................



// You can create an account, and submit your answers here for personal achievement/accomplishment.
// https://projecteuler.net/problem=6