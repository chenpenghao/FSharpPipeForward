
////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////
// 1.1 Set up

let x = 1
let y = x + 5

// Put your mouse on top of "x" and "y" to see the type of "x" and "y"



////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////
// 1.2 Types 

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
// #########################
// This contains ERROR!  //#
let immutableValue = 100 //#
immutableValue <- 300    //#
//##########################

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

/////################################################################
// Cannot combine two different types using the "+" functions     //#
// The following codes contain ERROR!                             //#
                                                                  //#
let addIntegerWithDecimal = 15 + 4.11                             //#
let combineStringWithInteger = "My age is: " + 21                 //#
/////################################################################


//////////////////////////////////////////////////////////////////
// SquareRoot "sqrt" and math exponent (**) only accepts decimals, 

let sqrtRootOfNine = sqrt 9.0
let twoToPowerOfFive = 2.0 ** 5.0 
// 2^5 = 2*2*2*2*2 = 32

//#####################################################################
// ERROR: sqrt and (power ** ) only accepts double/decimals/float   //#
let twoToPowerOfFiveError = 2 ** 5                                  //#
let sqrtRootOfNineError = sqrt 9                                    //#
// ERROR!                                                           //#
//#####################################################################

/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
// 1.3 Defining functions

// This function accepts integer only.

let f x = x + 5

let result1 = f 10
let result2 = f 20

// Un-comment to see the error
// ERROR: The function "f" cannot accept decimal input.
// let errorResult = f (3.0) 

////////////////////////////////

// Similarly, this function accepts decimals only.

let DiscountFunc originalPrice = originalPrice * 0.8

let discountedPrice = DiscountFunc 399.99
printfn "New price: %.2f" discountedPrice
// The "%.2f" is for 2 decimal points, just formatting purposes when printing result.

let anotherDiscount = DiscountFunc discountedPrice
printfn "New price: %.2f" anotherDiscount
////////////////////////////

// ####################################################################
// ERROR: The function "DiscountFunc" cannot accept integer input.  //#
let errorResult = DiscountFunc 100                                  //#
// ####################################################################

// In order to use the function on 100, you need to convert it using "double" or "float"
let convertedPrice = double 100
let decimalResult = DiscountFunc convertedPrice
printfn "New price: %.2f" decimalResult

/////////////////////////////

// Define a function for string.
let AddGreeting name =
    "Hello " + name

let greeting1 = AddGreeting "John"
let greeting2 = AddGreeting "Mary"

// ####################################################################
// ERROR: AddGreeting function does not accept integer/double/etc.  //#
let greetingError = AddGreeting 123                                 //#
// ####################################################################

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
// Function with 2 variables.
let g x y = 3 * x + y

let result3 = g 3 1
let result4 = g 10 2



// ############################################################
// ERROR: The function "g" cannot accept decimal input.     //#
let errorResult = g (3.0) 10                                //#
let errorResult = g 10 (2.0)                                //#
// ERROR!                                                   //#
// ############################################################

//////////////////////////////////////////////////////////////

let CalculateNewBalance interestRate principal  = 
    principal * (1.0 + interestRate)

let balance1 = CalculateNewBalance 0.05 100000.00 
printfn "New Balance: %f" balance1

let balance2 = CalculateNewBalance 0.03 5000.00 
printfn "New Balance: %f" balance2

// ################################################################
// ERROR: CalculateNewBalance does not accept integer values.   //#
let balanceError = CalculateNewBalance 0.04 100000              //#
// ################################################################
///////////////////////////////////////////////////////////
// Function with 3 variables.
let h x y z = 3 * x + 4 * y + 5 * z

// 3*3 + 4*4 + 5*5 = 50
let result5 = h 3 4 5

// 3*1 + 4*1 + 5*1 = 12
let result6 = h 1 1 1

///////////////////////////////////////////////////////////
// Warning: F# may sometimes automatically assume the inputs are integer (if insufficient information)
let AddThree x y z = x + y + z

let addThreeResult = AddThree 5 6 7
printfn "Adding 5 and 6 and 7 gives you: %i" addThreeResult

// ############################################################################
// ERROR: The F# compiler assumes the Add3 function accepts integer inputs. //#
Add3 1.0 2.0 3.0                                                            //#
// ############################################################################

// Custom function to work for double
let AddThreeCustom (x:double) y z = x + y + z

let add3CustomResult = AddThreeCustom 2.1 3.0 4.2
printfn "Adding the decimals give you: %f" add3CustomResult



/////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////
// 1.4 Scoping

let AddFriend person1 =
    let endOfSentence = " and Mary are friends"
    person1 + endOfSentence

let combinedSentence1 = AddFriend "Jack"
    
// ########################################################################
// ERROR: "endOfSentence" is not accessible outside of "AddFriend"      //#
printfn "The content of endOfSentence is: %s" endOfSentence             //#
// ########################################################################

/////////////////////////////////////////////
let DrinkFunction person =
    let endOfSentence = " likes to drink coffee."
    person + endOfSentence

let EatFunction person =
    let endOfSentence = " prefers eating chocolate."
    person + endOfSentence

printfn "%s" (DrinkFunction "Jack")
printfn "%s" (EatFunction "Jill")

/////////////////////////

let a = 5

let f1 b = 
    a + b

let f2 b = 
    a + a + b
    
printfn "%i" (f1 10)
printfn "%i" (f2 10)