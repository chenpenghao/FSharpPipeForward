
type Commands =
    | TIMES2
    | ADD1

let listOfCommands1 =
    [TIMES2; ADD1; TIMES2; TIMES2]

//////////////////
    
let ChangingFunction prevResult command =
    match command with
    | TIMES2 -> prevResult * 2
    | ADD1 -> prevResult + 1

let startValue = 3

//////////////////

let result1 =
    List.fold ChangingFunction startValue listOfCommands1

let result1_version2 =
    let intermediateResult1 = ChangingFunction startValue listOfCommands1.[0]
    let intermediateResult2 = ChangingFunction intermediateResult1 listOfCommands1.[1]
    let intermediateResult3 = ChangingFunction intermediateResult2 listOfCommands1.[2]
    let finalResult = ChangingFunction intermediateResult3 listOfCommands1.[3]
    finalResult

let result1_version3 =
    let mutable valueSoFar = startValue
    for command in listOfCommands1 do
        let updatedValue =
            ChangingFunction valueSoFar command
        valueSoFar <- updatedValue
    // return
    valueSoFar

//////////////////////////////

// The process depends on the starting value:

let startValue2 = 4
let result2 =
    List.fold ChangingFunction startValue2 listOfCommands1

///////////////////////////////

// The process also depends on the intermediate steps (i.e. the list that you "fold" with)

let listOfCommands2 = 
    [TIMES2; ADD1; ADD1; TIMES2]

// startValue = 3

let result3 =
    List.fold ChangingFunction startValue listOfCommands2

/////////////////////////////////////////////////////////////////////////////
// Example: Sum a List

// We can use List.sum

let result4 = List.sum [1 .. 100]

// Alternatively, we can slowly accumulate through the list, with a starting value of 0

let result5 = 
    [1 .. 100]
    |> List.fold (fun acc y -> acc + y) 0

/////////////////////////////////////
// Exercise: Product of a list

let ListProduct xList =
    xList 
    // |> List.fold (fun acc y -> ......) ......

    failwith "NOT YET IMPLEMENTED!"



let result6 = ListProduct [1 .. 5]

let result7 = ListProduct [2; 3; 5; 7; 11; 13]

////////////////////////////////////////////////////////////////////////////

// https://projecteuler.net/problem=8

// Problem 8 modified.

let digitList = 
    [7;3;1;6;7;1;7;6;5;3;1;3;3;0;6;2;4;9;1;9;2;2;5;1;1;9;6;7;4;4;2;6;5;7;4;7;4;2;3;5;5;3;4;9;1;9;4;9;3;4]
    
let result8 =
    digitList
    |> List.windowed 4
    |> List.map (fun x -> x, ListProduct x)
    |> List.maxBy (fun (_,product) -> product)


/////////////////////////////////////////////////////////////////////////////
// GCD of a list of numbers.

// The following recursive "rec" function helps to calculate the gcd of two integers.
// You do not need to re-implement this.
let rec gcd x y =
    if x < 0 || y < 0 then failwith "cannot accept negative numbers"
    if x > y then gcd y x
    else if x = 0 then y
    else gcd (y % x) x

// https://projecteuler.net/problem=5

let gcdOfList xList =
    let first = xList |> List.head
    let remaining = xList |> List.tail
    remaining
    |> List.fold gcd first

let result9 = 
    gcdOfList [12;14;16;18;20]
// Answer: 2

let result10 =
    gcdOfList [388800; 7290000; 75937500; 25312500]
// Answer: 8100

// Remark: 
// 388800   = 2^6 * 3^5 * 5^2
// 7290000  = 2^4 * 3^6 * 5^4
// 75937500 = 2^2 * 3^5 * 5^7
// 25312500 = 2^3 * 3^4 * 5^8

//////////////////////////////////////////////////////////////////////////////////////////////////
// LCM of a list of numbers

// The lcm function depends on the gcd function above.
// Again, you do not need to re-implement this function.
let lcm a b = 
    a * b / (gcd a b)

// Warning: This function is likely to encounter integer overflow/errors.
let lcmOfList xList =
    xList
    // |> List.fold lcm ........
    
    failwith "NOT YET IMPLEMENTED!"

let result11 = lcmOfList [1 .. 10]
// Result: 2520

let result12 = lcmOfList [2;3;4;6;8;12]
// Result: 24

///////////////////////////////////////////////////////////////////////////////
// Example: Iterate n-times


let resul13 =
    [1 .. 40]
    |> List.fold (fun acc _ -> acc - 1) 100

    
let mutable resultMutable = 100
for i in [1 .. 40] do
    resultMutable <- resultMutable - 1
let finalResult = resultMutable

////////////////////////////////////////////
// List.fold vs List.scan

let result14 = 
    [1 .. 100]
    |> List.fold (fun acc y -> acc + y) 0
// val result5 : int = 5050

let result15 = 
    [1 .. 100]
    |> List.scan (fun acc y -> acc + y) 0

/////////////////////////////////////////////////////////
// Sample Fibonacci list.
let resul16 =
    [1 .. 20]
    |> List.scan (fun (x,y) _ -> (y,x+y)) (1,2)

// https://projecteuler.net/problem=2
let fibonacciTupleList =
    [1 .. 40]
    |> List.scan (fun (x,y) _ ->
        (y,x+y)
    ) (1,1)

let fibonacciList =
    fibonacciTupleList
    |> List.map (fun (x,y) -> x)

let result2 =
    fibonacciList
    // |> List.filter ...............
