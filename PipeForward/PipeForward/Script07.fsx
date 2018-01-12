// Key-concept:
// 1. Functions are an object; it is a thing! 
// 2. Anonymous function is an alternate way to define a function.
// 3. It is very useful when used with other constructs, to simplify the syntax.
// 3a. Quickly read through this, and see it in action in the next file.

//////////////////////////////////////

// Analogy:
// Imagine that you have a machine.
// This machine takes apple as an input, and it outputs apple pie as a result.

// In order for this machine to have an output (apple pie), you need to provide with input (apple).
// However, the machine itself is an object. It is a "thing", just like an apple is a "thing".

// If you put this machine in a room, next to an apple, then you can use your hand to touch the machine,
// just like how you can touch the apple. They can be real concrete "things".

// The machine differs from an apple in a way that it has the additional property 
// to turn raw input (apple) into processed output (apple pie).

// But you can consider the machine as a real concrete "thing", just like how an apple is a real concrete "thing".




// How this analogy compares with programming:

// We have seen before that we can define a function like this:
let f1 x = x + 1

printfn "The result is: %i" (f1 100)
printfn "The result is: %i" (f1 200)

// However, we can also define it in the following way:
// Previous code:
// let f1 x = x + 1

// New code:
let f2      = (fun x -> x + 1)

printfn "The result is: %i" (f2 100)
printfn "The result is: %i" (f2 200)

// The insight is that "f2" is an object! 
// It is a thing (just like how integer/double/string are things)

// What is this "f2" object? 
// It is a function.

// OK, if "f2" is a function,S
// 1. What does it do? 
// 2. What is the input? 
// 3. What is the output?

// Answer:
// 1. It takes an integer, and add one to to this number.
// 2. The input is an integer.
// 3. The output is also an integer, slightly larger than the input.


/////////////////////////////////////////////////////////////////////////////////////////////////////////
// Let's look at the code before:
let result1 = List.filter (fun x -> x % 2 = 0) [1 .. 100]

// Hover your mouse on top of "List.filter", and you will see the following signature:

//    input1    ->  input2 ->  output
// ('T -> bool) -> 'T List -> 'T List

// What this means is that List.filter accepts two input:
// input1: A function that accepts one element (in our case, an integer)
//         And tells us whether it satisfy some requirement (through a boolean true/false output)
// input2: A list of item (in out case, List of integers) that we want to filter on

// output: A potentially shorter list, removing all elements that return "false" on the function "input1"

// Notice that input1 is a function! It is a "thing"!



// So, this means that "List.filter" is actually a bigger function/machine!
// You can think of "List.filter" as a bigger machine/factory.

// It needs a detector/scanner/function to determine whether something is good or bad (true/false).
// Then it needs another input, which is a list of objects to apply this scanner/detector on.

// Once the detector/scanner and the List of objects are ready in the big machine/factory,
// It runs the checking process, and throw away things that are bad (false)

// And finally it returns the processed and remaining List.



// In this case, a bigger machine/factory can accept a function/smaller scanner machine as input!
// The scanner/detector is actually a thing! You can give this "thing" to another bigger entity/machine/factory.

