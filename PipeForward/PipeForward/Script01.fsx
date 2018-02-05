
let x = 1
let y = x + 5

// Put your mouse on top of "x" and "y" to see the type of "x" and "y"

////////////////////////////////////////////////////////////////////
// Types 

let name = "John"
let age = 21
let height = 170.5

/////////////////////////////////////////////////////////////////////
// Printing and output

printfn "My name is: %s" name
printfn "Name: %s. Age: %i. Height: %f." name age height
printfn "His height is: %.2f" height

/////////////////////////////////////////////////////////////////////
// Equality testing.
let valueToTest = 20
let isValueEqualToTwenty = (valueToTest = 20)

if isValueEqualToTwenty then
    printfn "Yes, the value is Twenty"
else 
    printfn "No, the value is not Twenty"

//////////////////////////////

let inputUserName = "Jack"

if inputUserName = "John" then
    printfn "Welcome back, John"
else 
    printfn "Access denied."
    
/////////////////////////////////////////////////////////////////////
// Immutability

// Warning: Do not use mutable value if possible! 
// 
// Using mutable value is a bad idea!
let mutable changableValue = 100
printfn "Original value is: %i" changableValue

changableValue <- 200
printfn "Updated value is: %i" changableValue

////////////////////////////

// Uncomment the code below to see an error:

//let immutableValue = 100
//immutableValue <- 300

///////////////////////////////////////////////////////////////////
// Basic operator (+)

let number1 = 40
let number2 = 55
let addTwoNumbers = number1 + number2

// Remark: "float" and "double" mean the same thing in F#.
let sqrtTwoApprox = 1.414
let piApprox = 3.1415926
let addTwoDecimals = sqrtTwoApprox + piApprox

let sentenceStart = "My school is "
let schoolName = "National University of Singapore"
let combinedSentence = sentenceStart + schoolName

///////////////////////////////////
// Cannot combine two different types using the "+" functions
// The code all below, if un-commented, will create error.

//let addIntegerWithDecimal = 15 + 4.11
//let combineStringWithInteger = "My age is: " + 21

////////////////////////////////////
// SquareRoot "sqrt" and math exponent (**) only accepts decimals, 

let sqrtRootOfNine = sqrt 9.0
let twoToPowerOfFive = 2.0 ** 5.0 
// 2^5 = 2*2*2*2*2 = 32

// ERROR: sqrt and (power ** ) only accepts double/decimals/float
//let twoToPowerOfFiveError = 2 ** 5 
//let sqrtRootOfNineError = sqrt 9
