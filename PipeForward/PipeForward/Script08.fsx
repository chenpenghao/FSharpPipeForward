// Key Concept:

// 1. Tuple is a good data-structure for many things:
// 1a. To represents terms that goes together, e.g. 2-D coordinates, Year-Month, etc.
// 1b. For pattern matching, especially for pairwise operation.
// 1c. Tuples are also good for testing out ideas.
// 1d. (but you may want to formally define terms if you have more elements)

// 2. Pattern matching is a good way to extract out items from tuples, list, etc.
// 2a. "if-else" statements in usual programming language is "evil"
// 2b. You may miss out potential cases.

//////////////////////////////////////////////////////////////////////////
// A 2-D coordinate may look like this:

let point1 = (1.0, 2.0)
let point2 = (3.0, 4.0)

// Hover your mouse on top of these two objects.
// Notice that the signature is "float * float" or "double * double"
// So, these points have two coordinates, each of them are "float" or "double".

let DistanceFromOrigin point =
    let (x,y) = point
    sqrt (x ** 2.0 + y ** 2.0)

let distance1 = DistanceFromOrigin point1
printfn "The first point is distance %f away from origin" distance1

let distance2 = DistanceFromOrigin point2
printfn "The second point is distance %f away from origin" distance2

// Notice that I did not specify what is the type of point


/////////////////////////////////////////////////

// If you hover your mouse on top of these, you will see that:
// 1. The first tuple has signature "float * string"
//    

