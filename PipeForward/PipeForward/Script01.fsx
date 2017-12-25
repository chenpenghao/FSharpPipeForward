﻿//////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////
// Section 00: Comments and FSharp Interactive.



// You can use double-slash //, 
// triple-slash ///, 
// or star-brackets (* ....... *) to make comments in F#.

///////////////////////////////////////////
// In Visual-Studio in Windows, you can highlight a certain section of code, and
// run it in FSharp-interactive using "ALT + ENTER".
// Alternatively, highlight the code you want to run, rightclick, and 
// "Execute in interactive"

// Remark: I am not sure how to do it in Mac computers.

// Try it out with the code below.

let x = 1
let y = x + 5
printfn "The result is: %i" y

// printfn is to print the result to the console. 
// %i is for integer, %f for decimal/double, %s for string, %A for general objects.
// No need to remember the "%i", "%s", etc. 
// Refer to a table.







//////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////
// Section 01: Variables and Types.

///////////////////////////////////////////
// As seen above, you can define a variable using "let"

// Also, a variable in F# is by default "immutable", 
// which means that once you defined the variable, it cannot be changed.
// So, if you try to reassign a value to "x", an error will occur.
// You can un-comment the code below and see what happens. 

// Warning: Will create error if uncommented.
// x <- 2


// You can use "mutable" or changable variables in F#,
// but we do NOT recommend using "mutable" variables.
// And we will NOT show how to use "mutable" in this tutorial.

/////////////////////////////////////////////////////////////////

// Also, F# uses "=" and "<>" for equality/ inequality checking. 
// (Unlike "==" in Java/C++, and "===" in JavaScript)
let valueToTest = 20
let isValueEqualToTwenty = (valueToTest = 20)

if isValueEqualToTwenty then
    printfn "Yes, the value is Twenty"
else 
    printfn "No, the value is not Twenty"

// The second line "No, ......" will not be printed.

///////////////////////////////////////////////////////////////////
// You can define integer, double, string, 
// and these types support the "+" operation.

let number1 = 40
let number2 = 55
let addTwoNumbers = number1 + number2

let sqrtTwoApprox = 1.414
let piApprox = 3.1415926
let addTwoDecimals = sqrtTwoApprox + piApprox

let sentenceStart = "My school is "
let schoolName = "National University of Singapore"
let combinedSentence = sentenceStart + schoolName

///////////////////////////////////
// However, you cannot combine two different types using the "+" functions
// The code all below, if un-commented, will create error.

// let addIntegerWithDecimal = 15 + 4.11
// let combineStringWithInteger = "My age is: " + 21

// This is an implicit casting that you may take for granted in other languages (e.g. Java, C++, Javascript)
// But in F#, this strict rule will help us make less mistake when we write our code.

////////////////////////////////////
// Similarly, some functions (such as squareRoot "sqrt") only accepts double/float/decimals, 
// So be careful if you want to calculate it for Integers.

let sqrtRootOfNine = sqrt 9.0
let twoToPowerOfFive = 2.0 ** 5.0 
// 2^5 = 2*2*2*2*2 = 32

// ERROR: sqrt and (power ** ) only accepts double/decimals/float
//let sqrtRootOfNineError = sqrt 9
//let twoToPowerOfFiveError = 2 ** 5 







//////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////
// Section 02: Defining functions.

// You can define functions using "let" followed by the inputs of your function.

let Square x = x * x
printfn "%i" (Square 2)
printfn "%i" (Square 3)



