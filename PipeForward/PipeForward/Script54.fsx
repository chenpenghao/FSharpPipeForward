


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

let inline CustomAdd x y z = x + y + z
let add3IntegerResult = CustomAdd 4 5 6
printfn "Adding the three integers give: %i" add3IntegerResult

let add3StringResult = CustomAdd "John " "F." " Kennedy"
printfn "Concatenate the three strings give: %s" add3StringResult

let add3DecimalResult = CustomAdd 10.3 10.2 10.1
printfn "Adding the three decimals give: %f" add3DecimalResult

// Not every data type supports addition "+"

// Un-comment to see the error
// ERROR: The boolean type (true/false) does not support addition "+"
// let add3Bool = NewAdd3 true false false