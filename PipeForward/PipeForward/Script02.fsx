

//////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////
// Section 02: Defining functions.

// You can define functions using "let" followed by the inputs of your function.

let f x = x + 5

let result1 = f 10
printfn "%i" result1
let result2 = f 20
printfn "%i" result2

// Notice the following:
//
// 1. To apply the function "f", you don't need to use the math notation f(x).
//    You can apply the arguments by separating with a space.
//
// 2. If you hover your mouse on top of "f", you will see that
//    "f" is a function that accepts only integer "x" as the argument.
//
//    This is because in the function, "x" will be added to the integer "5".
//    We have seen before that we cannot use the symbol    "+"   
//    to add an integer and a decimal directly.
//    So, the following code will fail if you un-comment it:

// Un-comment to see the error
// ERROR: The function "f" cannot accept decimal input.
// let errorResult = f (3.0)

////////////////////////////////

// Similarly, the following function accepts only decimals/double 
// Because the variable interacts with a decimal "0.8"
let DiscountBy20Percent originalPrice = originalPrice * 0.8

let discountedPrice = DiscountBy20Percent 399.99
printfn "The new price is: %.2f" discountedPrice
// The "%.2f" is for 2 decimal points, just formatting purposes when printing result.

let anotherDiscount = DiscountBy20Percent discountedPrice
printfn "The new price is: %.2f" anotherDiscount

// This time around, the function will not accept integers. 
// The following will produce error.

// Un-comment to see the error
// ERROR: The function "DiscountBy20Percent" cannot accept integer input.
// let errorResult = DiscountBy20Percent 100

// In order to use the function on 100, you need to change it to 100.0
let decimalResult = DiscountBy20Percent 100.0
printfn "The new price is: %.2f" decimalResult

/////////////////////////////

// Define a function for string.
let AddGreeting name =
    "Hello " + name

let greeting1 = AddGreeting "John"
printfn "The modified name is: %s" greeting1

let greeting2 = AddGreeting "Mary"
printfn "The modified name is: %s" greeting2

// uncomment to see error.
// ERROR: AddGreeting function does not accept integer/double/etc.
// let greetingError = AddGreeting 123

 


///////////////////////////
// Exercise: Write a function that calcuates the area of a circle of radius r
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
//////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////
// Function with 2 variables.
let g x y = 3 * x + y

let result3 = g 3 1
printfn "%i" result3
let result4 = g 10 2
printfn "%i" result4

// Notice the following:
//
// 1. To apply the function "g", you don't need to use the math notation g(x,y) with commas
//    This is different from other programming language e.g. Java, C++
//    You can apply the arguments by separating with a space.
//
// 2. If you hover your mouse on top of "g", you will see that
//    the variable "x", "y" need to be integers.
//
//    This is because in the function, "x" will is multiplied with "3", and then later added with "y"
//    We have seen before that we cannot use the symbol "*" and "+"   
//    to combine integer and a decimal directly.
//    So, the following code will fail if you un-comment it:


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
// let balanceError = CalculateNewBalance 100000 0.05


///////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////



////////////////////
// Warning: If you use "+" or "*", with no other information available in your function
// (e.g. an appearance of a decimal, string, etc.)
// then F# will assume the function variables as integers.
let Add3 x y z = x + y + z

let add3Result = Add3 5 6 7
printfn "Adding 5 and 6 and 7 gives you: %i" add3Result

// Without further information, F# compiler assumes the variables using "+" are integers
// 
// Un-comment to see the error
// ERROR: The F# compiler assumes the Add3 function accepts integer inputs.
// Add3 1.0 2.0 3.0

// If you want this function to work for double, 
// you may need to annotate the type of one of the variables.
let Add3Custom (x:double) y z = x + y + z

// By annotating, the function knows that "x" is a double/decimal.
// And since "y" and "z" will interact with "x" by adding,
// So "y" and "z" will also be inferred as double/decimal.

let add3CustomResult = Add3Custom 2.1 3.0 4.2
printfn "Adding the decimals give you: %f" add3CustomResult

//////////////////////////

// On some occasion, if you need to use the same function on different type which supports "*" or "+",
// then you can use the "inline" keyword.
//
// Try not to use "inline" unless you absolutely must write a function that is 
// compatible to different type (double/integer/etc)


let inline Product x y = x * y

let multiply2Int = Product 2 3
printfn "Multiply the two numbers gives: %i" multiply2Int

let multiply2Double = Product 3.0 4.0
printfn "Multiply the two numbers gives: %f" multiply2Double

// Not every data type supports multiplication "*"

// Un-comment to see the error
// ERROR: The string type does not support multiplication "*"
// let multiplyTwoString = Product "HELLO" "BYE"

/////////////////////////

let inline NewAdd3 x y z = x + y + z
let add3IntegerResult = NewAdd3 4 5 6
printfn "Adding the three integers give: %i" add3IntegerResult

let add3StringResult = NewAdd3 "First" "Second" "Third"
printfn "Concatenate the three strings give: %s" add3StringResult

let add3DecimalResult = NewAdd3 10.3 10.2 10.1
printfn "Adding the three decimals give: %f" add3DecimalResult

// Not every data type supports addition "+"

// Un-comment to see the error
// ERROR: The boolean type (true/false) does not support addition "+"
// let add3Bool = NewAdd3 true false false

//////////////////////////////////////////