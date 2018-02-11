// 2.1: Introduction

// You do not need to implement the pipe-forward operator.
// It is already defined in F#.
//
// let inline (|>) x f = f x

/////////////////////////////////////////////////////////////////////////
// 2.2: Simple demonstration

let Add5Func x = x + 5

let result1 = Add5Func 30

// With pipe-forward:
let result2 = 30 |> Add5Func

///////////////////////////////////////////////////////////
// 2.3: Usefulness

// Let's say that you are given these two functions:
let GetGrade score =
    if score >= 90 then "A"
    else if score >= 70 then "B"
    else if score >= 50 then "C"
    else "D"
    
// For Singaporean University. (Maximum CAP 5.0)
let GetCAP grade =
    if grade = "A" then 5.0
    else if grade = "B" then 4.0
    else if grade = "C" then 3.0
    else 2.0
    
// GetGrade: int  -> string
// GetCAP:           string ->  float

////////////////////////////////

// verbose/long version
let GetCAPfromScore1 score =
    let intermediateResult = GetGrade score
    let finalResult = GetCAP intermediateResult
    // return
    finalResult

let cap1 = GetCAPfromScore1 95
let cap2 = GetCAPfromScore1 85

///////////////////////

// GetGrade: int  -> string
// GetCAP:           string ->  float

// Shorter version
let GetCAPfromScore2 score =
    score               
    |> GetGrade         
    |> GetCAP           

// See the pdf for a step-by-step explanation of the code above.

let cap3 = GetCAPfromScore2 95
let cap4 = GetCAPfromScore2 85

///////////////////////////////
// function will not compile if it is in the wrong order.

// uncomment to see errors.
// ERROR: Functions applied in the wrong order.
//let CombinedFunction3Error (score:int) =
//    score       // int
//    |> GetCAP   // function: string -> double   // ERROR
//    |> GetGrade // function: int -> string      // ERROR

///////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////
// 2.4 More examples

// First, F# has a built-in function, "List.average"
let average1 = List.average [1.0; 2.0; 3.0; 4.0; 5.0]
let average2 = List.average [80.0; 85.0; 90.0; 95.0; 100.0]

/////////////////////////////

let GetPerformance analystAverageEstimate =
    let actualProfit = 6.0
    if actualProfit > analystAverageEstimate * 1.05
        then "OUTPERFORM"
    else if actualProfit < analystAverageEstimate * 0.95 
        then "UNDERPERFORM"
    else 
        "NEUTRAL"

let GetNumSharesToBuy performance =
    if performance = "OUTPERFORM" then
        1000     // buy 1000 shares
    else if performance = "UNDERPERFORM" then
        -1000    // sell 1000 shares
    else 
        0       // hold.
        
// List.average:        List<double> -> double
// GetPerformance:                      double -> string
// GetNumSharesToBuy:                             string -> int

//////////////////////////////////////////////////////////////////////////////
// Long version

// Assume the profit is already known to be $6.0 billion, and written in "GetPerformance"
let GetNumSharesFromEstimate1 individualEstimates =
    let intermediateResult1 = List.average individualEstimates
    let intermediateResult2 = GetPerformance intermediateResult1
    let finalResult = GetNumSharesToBuy intermediateResult2
    // output
    finalResult
    
// In this example, the actual profit (6.0 billion) exceeds all the financial analyst's prediction.
// Which means this is good news.
let numShares1 = GetNumSharesFromEstimate1 [4.0; 5.0; 3.0; 2.0; 2.5]
printfn "Number of shares to buy(+) or sell(-): %i" numShares1

// In this example, the actual profit (6.0 billion) misses all the financial analyst's prediction.
// Which means this is bad news.
let numShares2 = GetNumSharesFromEstimate1 [8.0; 7.0; 10.0; 12.0; 10.5]
printfn "Number of shares to buy(+) or sell(-): %i" numShares2

/////////////////////////
// Original:
//let GetNumSharesFromEstimate1 (individualEstimates: List<double>) =
//    let intermediateResult1 = List.average individualEstimates
//    let intermediateResult2 = GetPerformance intermediateResult1
//    let finalResult = GetNumSharesToBuy intermediateResult2
//    // output
//    finalResult

// Simplified:
let GetNumSharesFromEstimate2 individualEstimates =
    individualEstimates                 
    |> List.average                     
    |> GetPerformance                  
    |> GetNumSharesToBuy                
    


// And lets try our new function here.
    
// In this example, the actual profit (6.0 billion) exceeds all the financial analyst's prediction.
// Which means this is good news.
let numShares3 = GetNumSharesFromEstimate2 [4.0; 5.0; 3.0; 2.0; 2.5]
printfn "Number of shares to buy(+) or sell(-): %i" numShares3

// In this example, the actual profit (6.0 billion) misses all the financial analyst's prediction.
// Which means this is bad news.
let numShares4 = GetNumSharesFromEstimate2 [8.0; 7.0; 10.0; 12.0; 10.5]
printfn "Number of shares to buy(+) or sell(-): %i" numShares4

///////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////
// 2.6 Intellisense
// If you are not comfortable with completely getting rid of intermediateSteps, you can try the following:

let myFunction1 (individualEstimates: List<float>) =
    individualEstimates                 
    |> List.average          

let myFunction2 individualEstimates =
    individualEstimates                 
    |> List.average                     
    |> GetPerformance        

let myFunction3 individualEstimates =
    individualEstimates                 
    |> List.average                     
    |> GetPerformance                  
    |> GetNumSharesToBuy

// Hover your mouse on top of the "myFunction1", "myFunction2", "myFunction3" 
// and see that the functions are
// myFunction1: List<double> -> double
// myFunction2: List<double>            -> string
// myFunction3: List<double>                       -> int

////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
// Example for you to try out:
// 
// Assume that you are in a trading firm, and you want to manage your employees
// based on their performance.

// F# has a built-in function, "List.sum" that finds the sum of a list of doubles/decimals.
let sum1 = List.sum [1.0; 2.0; 3.0; 4.0; 5.0]   // sum from 1 to 5
let sum2 = List.sum [1.0 .. 100.0]              // sum from 1 to 100

let GetStatus profit =
    if profit > 10.0 then
        "TOP TRADER"
    else if profit < -3.0 then
        "HUGE LOSSES"
    else
        "NORMAL TRADER"

let GetBonus status =
    if status = "TOP TRADER" then   
        24      // 24-month, i.e. 2 year bonus.
    else if status = "NORMAL TRADER" then
        6       // 6-month, i.e. half year bonus.
    else 
        0       // No bonus.

// The functions are:
// List.sum : List<double> -> double
// GetStatus:                 double -> string
// GetBonus:                            string -> int

/////////////////////////////////////
// Long version
let GetBonusFromTrades1 listOfTrades =
    let intermediateResult1 = List.sum listOfTrades
    let intermediateResult2 = GetStatus intermediateResult1
    let finalResult = GetBonus intermediateResult2
    // output
    finalResult

// Exercise:

// Try implementing it with the pipe forward operator "|>"
let GetBonusFromTrades2 listOfTrades =
    // delete the line below, and fill in your answer 

    failwith "FUNCTION NOT YET IMPLEMENTED!"

    // implement the function above.

// This trader helped the company earned some money.
let bonus1 = GetBonusFromTrades2 [1.0; -2.0; 0.5; 0.3; 0.4; 0.2]
printfn "He received a bonus of %i months" bonus1

// This trader made one huge profitable deal, with other small losses.
let bonus2 = GetBonusFromTrades2 [-2.0; -1.0; -0.5; 30.0; -1.0]
printfn "She received a bonus of %i months" bonus2



///////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////
// 2.8 Endomorphism
let Square x = x * x
let Cube x = x * x * x
let Add5 x = x + 5

// f1(x) = (x^2 + 5)^3
let f1 x = 
    x
    |> Square
    |> Add5
    |> Cube
    
// (1^2 + 5) ^ 3 = 216
let demo1 = f1 1

// (2^2 + 5) ^ 3 = 729
let demo2 = f1 2

///////////////////////
// f2(x) = (x^2)^3 + 5
let f2 x =
    x
    |> Square
    |> Cube
    |> Add5

// (1^2)^3 + 5 = 6
let demo3 = f2 1

// (2^2)^3 + 5 = 71
let demo4 = f2 2

/////////////////////////
// Example: Try to implement the following function using Pipe-forward.
//let Square x = x * x
//let Cube x = x * x * x
//let Add5 x = x + 5

// Goal: f3(x) = [   (x+5)^2   + 5   ]^3
let f3 x =

    failwith "NOT IMPLEMENTED!"

// Testing:

// [   (1+5)^2   + 5   ]^3 = 68921
let demo5 = f3 1

// [   (2+5)^2   + 5   ]^3 = 157464
let demo6 = f3 2
