
let x = 1
let y = x + 5

// Put your mouse on top of "x" and "y" to see the type of "x" and "y"

////////////////////////////////////////////////////////////////////
// Types and Output

let name = "John"
let age = 21
let height = 170.5

printfn "My name is: %s" name

printfn "Name: %s. Age: %i. Height: %f." name age height

printfn "His height is: %.2f" height

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
// HOWEVER, we highly discourage you from actually using it.
let mutable changableValue = 100
printfn "Original value is: %i" changableValue

// Again, we do not recommend that you use "mutable". This is for demonstration.
changableValue <- 200
printfn "Updated value: %i" changableValue

// The reason why we do not recommend changing a variable value is because:
// It makes your code harder to reason. i.e. 
// 
// If your variable is changable, and you have a program that is 10,000 of lines long, 
// then you need to find all the locations where your value might change,
// in order for you to make sure that your variable is doing what you expect it to do.

// If your variable is NOT changable, then if you use the same variable after 10,000 lines later,
// You can expect that the value stays the same, and you don't need to worry that
// the value is modified some point in between.

/////////////////////////////////////////////////////////////////

// Also, F# uses "=" and "<>" for equality/ inequality checking. 
// (Unlike Java/C++ uses "==, !=" for comparison, and "===, !==" in JavaScript)
//
// Also, as mentioned above, F# uses "<-" for reassigning mutable values.
// (Unlike Java/C++/JavaScript use "=" for reassigning values )
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

// Remark: "float" and "double" mean the same thing in F#.
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

// This is an implicit casting that you may take for granted in other languages 
// (e.g. Java, C++, Javascript)
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
