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



