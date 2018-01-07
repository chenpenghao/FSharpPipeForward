
// Key concept:
// 1. With indent/spacing, you can reuse the same symbol without causing conflict between different function.
// 1a. F# does not use "TAB" for indenting. 
// 1b. Remember to change your text-editor so that the "TAB" key/button does not insert an actual "TAB".

//////////////////////////////////////////////////
// You can use a "let" inside a "let", for example:
let AddFriend (person1: string) =
    let endOfSentence = " and Mary are friends"
    person1 + endOfSentence

// Notice that the two lines under the "AddFriend" function has some spaces in front of each line.
// This means that those codes are accessible only inside "AddFriend" 
// So, you cannot access the "endOfSentence" variable outside of the function.

// uncomment to see error
// ERROR: "endOfSentence" is not accessible outside of "AddFriend"
//printfn "The content of endOfSentence is: %s" endOfSentence




// Simple example.

let combinedSentence1 = AddFriend "Jack"
printfn "The new sentence is: %s" combinedSentence1



/////////////////////////////////////////////
// So, you can repeatedly use the same variable name,
// as long as the spacing/indenting is such that the variables do not cause conflict with each other.
let DrinkFunction (person: string) =
    let endOfSentence = " likes to drink coffee."
    person + endOfSentence

let EatFunction (person: string) =
    let endOfSentence = " prefers eating chocolate."
    person + endOfSentence

// The "endOfSentence" of these two functions will not cause conflict with each other.

printfn "Drink preference: %s" (DrinkFunction "Jack")
printfn "Eating preference: %s" (EatFunction "Jill")

////////////////////////////////////////////////////////////////
// On the other hand, let's take a look at the following example:
let x = 5

let f1 y = 
    x + y

let f2 y = 
    x + x + y

// Notice that there are no spacing/indenting before "let x = 5", 
// and so the value of "x" is accessible for "f1" and "f2".

// Also, you can redefine the value of "x" within another function 
// (which makes the previous value of "x" not accessible)
//
// And so, be extremely careful for any variable that are accessible at the root level.

let f3 y =
    let x = 7       // So, the previous value of "x=5" is not accessible.
    x + y
    
printfn "%i" (f1 10)
printfn "%i" (f2 10)
printfn "%i" (f3 10)