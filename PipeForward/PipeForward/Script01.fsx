
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

/////////////////////////////////////////////////////////////////
// Defining functions

// This function accepts integer only.

let f x = x + 5

let result1 = f 10
printfn "The result is: %i" result1

let result2 = f 20
printfn "The result is: %i" result2

// Un-comment to see the error
// ERROR: The function "f" cannot accept decimal input.
// let errorResult = f (3.0) 

////////////////////////////////

// Similarly, this function accepts decimals only.

let DiscountBy20Percent originalPrice = originalPrice * 0.8

let discountedPrice = DiscountBy20Percent 399.99
printfn "The new price is: %.2f" discountedPrice
// The "%.2f" is for 2 decimal points, just formatting purposes when printing result.

let anotherDiscount = DiscountBy20Percent discountedPrice
printfn "The new price is: %.2f" anotherDiscount
////////////////////////////

// Un-comment to see the error
// ERROR: The function "DiscountBy20Percent" cannot accept integer input.
// let errorResult = DiscountBy20Percent 100

// In order to use the function on 100, you need to convert it using "double" or "float"
let convertedPrice = double 100
let decimalResult = DiscountBy20Percent convertedPrice
printfn "The new price is: %.2f" decimalResult

/////////////////////////////

// Define a function for string.
let AddGreeting name =
    "Hello " + name

let greeting1 = AddGreeting "John"
printfn "The modified sentence is: %s" greeting1

let greeting2 = AddGreeting "Mary"
printfn "The modified sentence is: %s" greeting2

// uncomment to see error.
// ERROR: AddGreeting function does not accept integer/double/etc.
// let greetingError = AddGreeting 123

///////////////////////////
// Exercise: Write a function that calculates the area of a circle of radius r
let CircleArea r =

     // ... IMPLEMENT HERE ...
     failwith "ERROR. Function not yet implemented."
     // Delete the line above and replace with the correct implementation
     // Hint: Use    "System.Math.PI"

// // Test your function here.
let circleResult1 = CircleArea 1.0
printfn "The first circle has area of: %f" circleResult1

let circleResult2 = CircleArea 2.0
printfn "The first circle has area of: %f" circleResult2

//////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////
// Function with 2 variables.
let g x y = 3 * x + y

let result3 = g 3 1
printfn "The result is: %i" result3
let result4 = g 10 2
printfn "The result is: %i" result4

// Un-comment to see the error
// ERROR: The function "g" cannot accept decimal input.
// let errorResult = g (3.0) 10
// let errorResult = g 10 (2.0)

//////////////////////////////////////////////////////////////

let CalculateNewBalance interestRate principal  = 
    principal * (1.0 + interestRate)

let balance1 = CalculateNewBalance 0.05 100000.00 
printfn "The new balance is: %f" balance1

let balance2 = CalculateNewBalance 0.03 5000.00 
printfn "The new balance is: %f" balance2

// uncomment to see error.
// ERROR: CalculateNewBalance does not accept integer values.
// let balanceError = CalculateNewBalance 0.04 100000

///////////////////////////////////////////////////////////
// Function with 3 variables.
let h x y z = 3 * x + 4 * y + 5 * z

// 3*3 + 4*4 + 5*5 = 50
let result5 = h 3 4 5
printfn "The result is: %i" result5

// 3*1 + 4*1 + 5*1 = 12
let result6 = h 1 1 1
printfn "The result is: %i" result6

///////////////////////////////////////////////////////////
// Warning: F# may sometimes automatically assume the inputs are integer (if insufficient information)
let AddThree x y z = x + y + z

let addThreeResult = AddThree 5 6 7
printfn "Adding 5 and 6 and 7 gives you: %i" addThreeResult

// Un-comment to see the error
// ERROR: The F# compiler assumes the Add3 function accepts integer inputs.
// Add3 1.0 2.0 3.0

// Custom function to work for double
let AddThreeCustom (x:double) y z = x + y + z

let add3CustomResult = AddThreeCustom 2.1 3.0 4.2
printfn "Adding the decimals give you: %f" add3CustomResult
