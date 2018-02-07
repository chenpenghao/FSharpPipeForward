
// Key-concept: 
// 1. Coding in F# is similar to building LEGO. (**)
// 1a. You chain together functions such that the output of one function is the 
//     input of the next function.

// (**) https://fsharpforfunandprofit.com/posts/defining-functions/

/////////////////////////////////////////////////////////////////////////////////
// Section04: Pipe-forward.

// The definition of the pipe-forward is:
let inline (|>) x f = f x

// The definition above may look strange, but let us look at an example
let Add5Func x = x + 5

let result1 = Add5Func 30
printfn "Result is: %i" result1
// Notice that the variable comes after the function

// However, with this new symbol |>, you can specify the variable first, 
// then the function you want to apply it to.
let result2 = 30 |> Add5Func
printfn "Result is: %i" result2

// How it is read is the following:
// "Starting from the input 30",
// "I use this as the variable for the function Add5Func"
// "And I assign the output of this process to the result2 variable"

///////////////////////////////////////////////////////////
// The reason why the symbol |> is useful is because it helps us to compose function.
// Let's look at an example:

// Let's say that you are given these two functions:
let GetGrade (score:int) =
    if score >= 90 then "A"
    else if score >= 70 then "B"
    else if score >= 50 then "C"
    else "D"

let GetCAP (grade:string) =
    if grade = "A" then 5.0
    else if grade = "B" then 4.0
    else if grade = "C" then 3.0
    else 2.0

// Here, the "GetGrade" function has signature of int -> string
// the "GetCAP" has signature of string -> double

// So, if you have the result of the first function, 
// you can use the result immediately in the second function
let GetCAPfromScore1 (score:int) =
    let intermediateResult = GetGrade score
    let finalResult = GetCAP intermediateResult
    // return
    finalResult

let cap1 = GetCAPfromScore1 95
printfn "Your CAP is: %f" cap1

let cap2 = GetCAPfromScore1 85
printfn "Your CAP is: %f" cap2

// Notice that the function above uses an "intermediateResult" and "finalResult" variable name
// to store some intermediate steps, even though it makes the code longer.

///////////////////////

// However, if you use the pipe-forward operator "|>", you can simplify the function as:

let GetCAPfromScore2 (score:int) =
    score               
    |> GetGrade         
    |> GetCAP           

// This is interpreted as:
//
// First, you start off with a "score" integer.
// Then, you apply this variable (the first "|>" symbol) to the function "GetGrade"
// Finally, whatever intermediate result you get after the "GetGrade" function, 
// You apply the intermediate result (the second "|>" symbol) to the function "GetCAP"
// And since "GetCAP" is the final line of the "CombinedFunction2",
// Whatever result that comes after "GetCAP" will be the output of the CombinedFunction2.

let cap3 = GetCAPfromScore2 95
printfn "Your CAP is: %f" cap3

let cap4 = GetCAPfromScore2 85
printfn "Your CAP is: %f" cap4

// Notice that the order of the function operation matters, 
// And so if you apply the function in the wrong order, it may not compile.

// uncomment to see errors.
// ERROR: Functions applied in the wrong order.
//let CombinedFunction3Error (score:int) =
//    score       // int
//    |> GetCAP   // function: string -> double   // ERROR: GetCAP accepts string, not integer!
//    |> GetGrade // function: int -> string      // ERROR: GetGrade accepts int, not double (the result of GetCAP).





///////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////
// Let's try another (hypothetical) example:

// Let's imagine a scenario where you want to buy or sell a company's stock
// Based on the company's performance relative to the financial analyst's estimate.

// First, F# has a built-in function, "List.average"
// that find the average of a list of numbers:
let average1 = List.average [1.0; 2.0; 3.0; 4.0; 5.0]
let average2 = List.average [80.0; 85.0; 90.0; 95.0; 100.0]



// In addition, let's say that the following 2 functions are available to you:

// Assume that the actual profit of the company is $ 6.0 billion for that year.
// If the actual profit exceed the analystEstimate by 5%, then we say it is "OUTPERFORM"
// If the actual profit misses the analystEstimate by 5%, then we say it is "UNDERPERFORM"
// else, "NEUTRAL"
let GetPerformance (analystAverageEstimate: double) =
    let actualProfit = 6.0
    if actualProfit > analystAverageEstimate * 1.05
        then "OUTPERFORM"
    else if actualProfit < analystAverageEstimate * 0.95 
        then "UNDERPERFORM"
    else 
        "NEUTRAL"

let GetNumSharesToBuy (performance: string) =
    if performance = "OUTPERFORM" then
        100     // buy 100 shares
    else if performance = "UNDERPERFORM" then
        -100    // sell 100 shares
    else 
        0       // hold.

// So we have three functions available to us:
// List.average:        List<double> -> double
// GetPerformance:      double -> string
// GetNumSharesToBuy:   string -> int

// In this carefully crafted example, notice that the result of the one function 
// can act as the input to the other function.
// So, we can combine them into a big function:

// Assume the profit is already known to be $6.0 billion, and written in "GetPerformance"
let GetNumSharesFromEstimate1 (individualEstimates: List<double>) =
    let intermediateResult1 = List.average individualEstimates
    let intermediateResult2 = GetPerformance intermediateResult1
    let finalResult = GetNumSharesToBuy intermediateResult2
    // output
    finalResult

// Notice that the code above uses a lot of temporary variables "intermediateResult1", etc.
// which makes the code longer. Nonetheless, we can still use it.

// In this example, the actual profit (6.0 billion) exceeds all the financial analyst's prediction.
// Which means this is good news.
let numShares1 = GetNumSharesFromEstimate1 [4.0; 5.0; 3.0; 2.0; 2.5]
printfn "Number of shares to buy(positive) or sell(negative): %i" numShares1

// In this example, the actual profit (6.0 billion) misses all the financial analyst's prediction.
// Which means this is bad news.
let numShares2 = GetNumSharesFromEstimate1 [8.0; 7.0; 10.0; 12.0; 10.5]
printfn "Number of shares to buy(positive) or sell(negative): %i" numShares2

/////////////////////////

//let GetNumSharesFromEstimate1 (individualEstimates: List<double>) =
//    let intermediateResult1 = List.average individualEstimates
//    let intermediateResult2 = GetPerformance intermediateResult1
//    let finalResult = GetNumSharesToBuy intermediateResult2
//    // output
//    finalResult

// The original version looks like the above, which we can simplify:

let GetNumSharesFromEstimate2 (individualEstimates: List<double>) =
    individualEstimates                 
    |> List.average                     
    |> GetPerformance                  
    |> GetNumSharesToBuy                

// So, we start off with "individualEstimates" a List of doubles/decimals.
//     Now, we apply (using the  first |> symbol) this starting variable
//              to the first function "List.average" 

// and then we apply (using the second |> symbol) this intermediateResult
//              to the  next function "GetPerformance"

// and then we apply (using the  third |> symbol) the intermediateResult before
//              to the  last function "GetNumSharesToBuy"

// and since "GetNumSharesToBuy" is the last line, 
// whatever results after that is our output of the combined function.



// And lets try our new function here.
    
// In this example, the actual profit (6.0 billion) exceeds all the financial analyst's prediction.
// Which means this is good news.
let numShares3 = GetNumSharesFromEstimate2 [4.0; 5.0; 3.0; 2.0; 2.5]
printfn "Number of shares to buy(positive) or sell(negative): %i" numShares3

// In this example, the actual profit (6.0 billion) misses all the financial analyst's prediction.
// Which means this is bad news.
let numShares4 = GetNumSharesFromEstimate2 [8.0; 7.0; 10.0; 12.0; 10.5]
printfn "Number of shares to buy(positive) or sell(negative): %i" numShares4

// The benefit of writing like such is that we don't need additional clutter/ unnecessary words on 
// our computer screen (to represent the intermediate result), and we can focus more on the 
// internal logic/calculations and not worry about the tiny details.

// And so, you will be able to make less mistake (and be more productive writing code)
// And the code will be easy to read for other programmers used to the syntax.

// Once you get used to this syntax, you may find other traditional programming language 
// e.g. Java/ C++ to be a bit verbose/too long.

///////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////
// If you are not comfortable with completely getting rid of intermediateSteps, you can try the following:

let PartiallyCompletedFunction1 (individualEstimates: List<double>) =
    individualEstimates                 
    |> List.average                     
    // |> GetPerformance          
    // |> GetNumSharesToBuy

let PartiallyCompletedFunction2 (individualEstimates: List<double>) =
    individualEstimates                 
    |> List.average                     
    |> GetPerformance                    
    // |> GetNumSharesToBuy

let CompletedFunction (individualEstimates: List<double>) =
    individualEstimates                 
    |> List.average                     
    |> GetPerformance                  
    |> GetNumSharesToBuy

// You can put your mouse on top of the "PartiallyCompletedFunction1", "PartiallyCompletedFunction2", etc.
// and see that the functions are
// PartiallyCompletedFunction1: List<double> -> double
// PartiallyCompletedFunction2: List<double>            -> string
// CompletedFunction:           List<double>                       -> int

// In practice, you will slowly write line by line, 
// and keep track of what is the output until that point (by hovering your mouse on top of the functions)

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

// In addition, you are given the following 2 functions:

// If the employee brings in $10.0 million this year, he is one of the best trader in the company. 
// If the employee loses $3.0 million this year, he is causing huge losses to the company.
// Otherwise, he is a regular trader.
let GetStatus (profit: double) =
    if profit > 10.0 then
        "TOP TRADER"
    else if profit < -3.0 then
        "CAUSE HUGE LOSSES TO COMPANY"
    else
        "NORMAL TRADER"

let GetBonus (status: string) =
    if status = "TOP TRADER" then   
        24      // 24-month, i.e. 2 year bonus.
    else if status = "NORMAL TRADER" then
        6       // 6-month, i.e. half year bonus.
    else 
        0       // No bonus.

// The functions are:
// List.sum : List<double> -> double
// GetStatus: double -> string
// GetBonus:  string -> int

// An implementation combining the function would look like:
let GetBonusFromTrades1 (listOfTrades: List<double>) =
    let intermediateResult1 = List.sum listOfTrades
    let intermediateResult2 = GetStatus intermediateResult1
    let finalResult = GetBonus intermediateResult2
    // output
    finalResult

// Try implementing it with the pipe forward operator "|>"
let GetBonusFromTrades2 (listOfTrades: List<double>) =
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
// In all the above examples, we have chosen functions that have different input and output types.
// so that it is obvious which function comes after which one.

// Sometimes, you may face with functions that have the same input and output type.
// For example:
let Square x = x * x
let Cube x = x * x * x
let Add5 x = x + 5

// All of these functions are "int -> int", and so you may compose them in different orders.
// Or you may apply the same function multiple times.
// Which may cause the function to completely change.

// f1(x) = (x^2 + 5)^3
let f1 x = 
    x
    |> Square
    |> Add5
    |> Cube
    
// (1^2 + 5) ^ 3 = 216
let demo1 = f1 1
printfn "The result is: %i" demo1  

// (2^2 + 5) ^ 3 = 729
let demo2 = f1 2
printfn "The result is: %i" demo2 

///////////////////////

// f2(x) = (x^2)^3 + 5
let f2 x =
    x
    |> Square
    |> Cube
    |> Add5

// (1^2)^3 + 5 = 6
let demo3 = f2 1
printfn "The result is: %i" demo3

// (2^2)^3 + 5 = 71
let demo4 = f2 2
printfn "The result is: %i" demo4

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
printfn "Result for demo5 is: %i" demo5

// [   (2+5)^2   + 5   ]^3 = 157464
let demo6 = f3 2
printfn "Result for demo6 is: %i" demo6
