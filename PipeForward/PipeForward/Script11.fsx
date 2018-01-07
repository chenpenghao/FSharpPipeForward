// Section11: Partial application

// Analogy: 
// Imagine that you want to build a cannon/ assemble a racecar. And you need 10 components.
// 1a. The original process requires 10 components.
// 1b. If you have 1 component, then you still need 9 components.
// 1c. If you have 2 components, then you still need 8 components, etc.
// 1d. If you have 9 components available, then your cannon/racecar is almost assembled, 
//     which makes your cannon ready to fire/ racecar ready to drive 
//     if you can provide the last component.
//
// Key concept: 
// 2a. Imagine that a function requires 10 variables.
// 2b. If you provide 1 variable to that function,
//     then the result is a new function that needs 9 variables.
// 2c. If you provide 2 variables to that function,
//     then the result is a new function that needs 8 variables.
// 2d. If you provide 9 variables to that function,
//     then the result is a new function that is missing the last variable,
//     which makes it ready to be used in a "pipe-forward"

/////////////////////////////////////////////////////
// As mentioned above, imagine you have the following function:
let CompareNumbers a b = 
    if a < b then 
        "First number is smaller"
    else if a > b then
        "First number is larger"
    else
        "Two numbers are equal"

// By hovering your mouse on top of the "Add2Numbers" text (in VisualStudio for Windows)
// (not sure how for Mac)
// You can see that the signature of the function is " int -> int -> string"
// This means that the function require two integers to produce a string result.

// For example:
let sentence1 = CompareNumbers 4 5
let sentence2 = CompareNumbers 10 3

printfn "Sentence1 produced: %s" sentence1
printfn "Sentence2 produced: %s" sentence2



////////////////////////////////////
// Even though the function "CompareNumbers" needs two integers, 
// you can provide it with only one.
// But what you get back is not an integer, but something else.

let unknownObject = CompareNumbers 4

// If you put your mouse on top of the unknownObject in VisualStudio (for Windows)
// (Not sure how for Mac)
// You can see that unknownObject has type "int -> string"

// i.e. unknownObject is actually a function that takes in 1 integer, and returns a string.

// You can imagine that inside "unknownObject", 
// there is a "CompareNumbers" machine that already has one component ready,
// and is eagerly waiting for the next input/component in order to start operating,
// and return the string result that it is designed to do.

// let's try it out:
let sentence3 = unknownObject 10
let sentence4 = unknownObject 0

printfn "Sentence3 produced: %s" sentence3
printfn "Sentence4 produced: %s" sentence4

/////////////////////////////////////////////////////////
// Another example:
let ThreeComponentFunction x y z = 
    if (x + y + z > 10) 
        then "Sum of x, y, z exceeds 10"
    else "The total sum is lower than or equal to 10"

// Again, put your mouse over the "ThreeComponentFunction" if you are using Visual Studio.
// the signature is " int -> int -> int -> string"
// So it needs 3 integers in order to produce a string result.

// However, we can put in only 1 variable, or only 2 variable, and it will produce different object.

let firstObject = ThreeComponentFunction 2
let secondObject = ThreeComponentFunction 2 5

// Again, put your mouse on top of "unknownObject2", "unknownObject3"
// firstObject: int -> int -> string
// secondObject:        int -> string

// i.e. Inside firstObject, the "ThreeComponentFunction" has already 
// accepted one input, and still needs two more in order to produce a result.

// Inside secondObject, the "ThreeComponentFunction" has already 
// accepted two inputs, and still needs 1 more in order to produce a result.

let sentence5 = firstObject 7 6
printfn "Sentence5 produced: %s" sentence5

let sentence6 = secondObject 0
printfn "Sentence6 produced: %s" sentence6



//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////

// Application of this concept:

// How is this useful?
// Let us see an example:

let SumAllMultiplesOf3 (xList: List<int>) =
    xList
    |> List.filter (fun x -> x % 3 = 0)
    |> List.sum

// Hover your mouse on top of "List.filter" if using Visual Studio.
// The "List.filter" function has signature:
// ('T -> bool) -> 'T list -> 'T list

// in particular, since we used it on integer list, we can rewrite as:
// (int -> bool) -> int list -> int list

// which means this function takes two items:
// item1: A filtering function (int -> bool) that helps us determine which elements to keep.
// item2: An integer list (int list) that we want to perform filtering operation on.
//
// and the result is a filtered list of the elements that we want to keep (the last "int list")

// So, if we provide the filtering function (fun x -> x % 3 = 0)
// Then "List.filter (fun x -> x % 3 = 0)" is a partially assembled function, 
// that still lacks one last component (the list we want to do filtering on)

// And so, it is "ready to fire", i.e. you can pipe-forward "|>" the last component,
// then original list of numbers "xList",
// into that partially assembled function.




printfn "Sum of all multiples of 3 within 1 to 10 is %i" (SumAllMultiplesOf3 [1 .. 10])



/////////////////////////////////////////////////
// Let's look at another example:

let GetCAP (score:int) =
    if score >= 90 then 5.0
    else if score >= 70 then 4.0
    else if score >= 50 then 3.0
    else 2.0

// Here, GetCAP: int -> double

let AverageCAP (scoreList: List<int>) =
    scoreList
    |> List.map (GetCAP)
    |> List.average 

// Put your mouse on top of "List.map"
// Here, the signature of List.map is:
// ('T -> 'U) -> 'T list -> 'U list

// Since the function that we use is "int -> double", we can rewrite as:
// (int -> double) -> int list -> double list

// So, in our usage of List.map, we need two components:
// Item1: A mapping function (int -> double) that tells us how to convert integer score to decimal CAP.
// Item2: The list of integer scores (int list) that we want to do individual conversion for.

// And the result of the List.map operation is a list of decimal CAP scores (double list)

// So, if we provide the mapping function "GetCAP" to List.map,
// then "List.map (GetCAP)" is a partially applied function,
// that still lacks one last component (the list we want to do individual element conversion)

// And so, it is "ready to fire", i.e. you can pipe-forward "|>" the last component,
// the original list of numbers (scoreList)
// into that partially assembled function.

let classScores = [95; 92; 80; 75; 65; 42]
let classAverageCAP = AverageCAP classScores
printfn "The average CAP of the class is: %f" classAverageCAP





/////////////////////////////////////////////////
// Let's look at one last example:

let ModifyValueByCommand (originalValue: int) (command: string) =
    if command = "ADD1" 
        then originalValue + 1
    else if command = "DOUBLE" 
        then originalValue * 2
    else
        originalValue

// ModifyValueByCommand: int -> string -> int

let SumAllIntermediateValue (commandList: List<string>) =
    commandList
    |> List.scan (ModifyValueByCommand) 0
    |> List.sum
    
// Put your mouse on top of "List.scan"
// Here, the signature of List.scan is:
// ('State -> 'T -> 'State) -> 'State ->     'T list   -> 'State list

// Since the function that we use is "int -> string -> int", we can rewrite as:
// (int -> string   -> int) ->     int -> string list   ->    int list

// So, in our usage of List.scan, we need three components:
// Item1: A conversion function (int -> string -> int) 
//        that tells us how to convert the original integer to the final integer
//        based on the command given in the string.
// Item2: The starting value "int" that we want to start the process in.
// Item3: The list of commands (string list) that we want to use. 

// And the result of the List.scan operation is a list of all the intermediateStep (int list)

// So, if we provide the folding/scanning function "ModifyValueByCommand" to List.scan,
// and a starting value of 0,
// then "List.scan (ModifyValueByCommand) 0" is a partially applied function,
// that still lacks one last component (the list of commands that helps us run the process)

// And so, it is "ready to fire", i.e. you can pipe-forward "|>" the last component,
// the list of commands (commandList),
// into that partially assembled function.



let listOfCommands = ["ADD1"; "DOUBLE"; "DOUBLE"; "ADD1"; "DOUBLE"; "UNKNOWN COMMAND"]
let sumOfIntermediate = SumAllIntermediateValue listOfCommands
printfn "The sum of all intermediateValue, with starting value 0, is %i" sumOfIntermediate