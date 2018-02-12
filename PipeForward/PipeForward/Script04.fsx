//////////////////////////////////////////////////////////////////////////
// A 2-D coordinate may look like this:

let point1 = (1.0, 2.0)
let point2 = (3.0, 4.0)

/////////////////////

let DistanceFromOrigin point =
    let (x,y) = point
    sqrt (x ** 2.0 + y ** 2.0)

let distance1 = DistanceFromOrigin point1
printfn "The first point is distance %f away from origin" distance1

let distance2 = DistanceFromOrigin point2
printfn "The second point is distance %f away from origin" distance2

////////////////////
// Extraction process at the function definition.

let DistanceFromOrigin2 (x,y) =
    sqrt (x ** 2.0 + y ** 2.0)

/////////////////////////////////////////////////
// Mix tuples of different types:
let mixedTuple1 = (1.0, "HELLO")
let mixedTuple2 = (1, "Hello", true)

// Extract contents:
let (extractedDecimal, extractedString) = mixedTuple1
printfn "The extracted decimal is: %f" extractedDecimal
printfn "The extracted string is: %s" extractedString

let (extractedInteger, extractedString2, extractedBool) = mixedTuple2
printfn "The extracted integer is: %i" extractedInteger
printfn "The extracted string is: %s" extractedString2
printfn "The extracted boolean is: %b" extractedBool

///////////////////////////////////////////////////////////
// Use "_" to ignore part of the tuple.
let personalInfo = ("John", 21, 170.0)

let (extractedName,_,_) = personalInfo

printfn "The extracted name is: %s" extractedName

/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
// Example: studentList is a List<string * int>. 

let studentList =
    [("A",50); ("B", 40); ("C", 45); ("D", 48)]
let studentList2 = 
    [("A", 40); ("B", 30); ("C", 20); ("D", 25); ("E", 29); ("F", 50)]
    
let TotalStudent (studentList: List<string * int>) =
    studentList
    |> List.map (fun classInfo ->
        let (_,numStudent) = classInfo
        numStudent
    )
    |> List.sum

let totalStudent1 = TotalStudent studentList

////////////////////////////
// Extraction process in the lambda/anonymous function:
let TotalStudentVersion2 (studentList: List<string * int>) =
    studentList
    |> List.map (fun (_,numStudent) -> numStudent)
    |> List.sum

let totalStudent2 = TotalStudentVersion2 studentList2

///////////////////////////////////////////////////////////////////////////
// Exercise: 
let classScores1 =    
    [("Ali", 85.0); ("Baba", 95.0); ("Charlie", 87.0); ("Dan", 92.0); ("Emily", 96.0); ("Fiona", 92.0)]

let ClassAverage (scores: List<string * double>) =
    

    failwith "NOT YET IMPLEMENTED!"
    // Hint: List.map and List.average

let result1 = ClassAverage classScores1

//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////
// Example:
let productList1 =
    [("Bread", 2.40, "COMMON");
     ("Beer", 10.20, "ALCOHOL");
     ("Swiss Chocolate", 8.20, "IMPORTS");
     ("Rice", 20.50, "COMMON");
     ("Red Wine", 30.00, "ALCOHOL");
     ("Australian Beef", 18.50, "IMPORTS")]

let TotalAfterTax (productList: List<string * double * string> ) =
    productList
    |> List.map (fun tuple ->
        let (_,priceBeforeTax,productType) = tuple // Data extraction!
        if productType = "COMMON" then
            1.05 * priceBeforeTax
        else if productType = "ALCOHOL" then
            1.20 * priceBeforeTax
        else 
            1.10 * priceBeforeTax
    )
    |> List.sum

let totalPrice = TotalAfterTax productList1
printfn "The final price after tax is: %.2f" totalPrice

////////////////////////////////////////////////////////////////////////
// Again, we can move the extraction process into the function definition:

let TotalAfterTaxVersion2 (productList: List<string * double * string> ) =
    productList
    |> List.map (fun (_,priceBeforeTax,productType) ->
        if productType = "COMMON" then
            1.05 * priceBeforeTax
        else if productType = "ALCOHOL" then
            1.20 * priceBeforeTax
        else 
            1.10 * priceBeforeTax
    )
    |> List.sum

let totalPrice2 = TotalAfterTaxVersion2 productList1
printfn "The final price after tax is: %.2f" totalPrice2

//////////////////////////////////////////////////////////////////
// Exercise:
// 50% discount for CLEARANCE, 30% for SHIRT, and 20% for JEANS

let listOfClothes =
    [ ("CLEARANCE", 70.0); ("SHIRT", 20.0); ("SHIRT", 40.0); ("JEANS", 55.0); ("JEANS", 79.9)]

let TotalAfterDiscount (priceList: List<string * double>) =





    failwith "NOT YET IMPLEMENTED!"

    
let finalPrice = TotalAfterDiscount listOfClothes

///////////////////////////////////////////////////////////////////////////////
// 4.2 List.allPairs

let allPairs1 = List.allPairs [1;2;3] ["A";"B"]

/////////////////////////////////////////////
// Example:

let SumOfAllPairProducts list1 list2 =
    List.allPairs list1 list2
    |> List.map (fun (x,y) -> x * y)
    |> List.sum

let list1 = [1;2;3]
let list2 = [5;6]

let result2 = SumOfAllPairProducts list1 list2 

//////////////////////////////////////////////////////////////////////////////////////
// Exercise:

// https://projecteuler.net/problem=9
let FindPythagoreanTriple =
    List.allPairs [1 .. 1000] [1 .. 1000]
    // |> List.filter (fun (a,b) -> ..............)
    // |> ..............

    failwith "NOT YET IMPLEMENTED!"

//////////////////////////////////////////////////////////////////////////////////////
// Exercise

// https://projecteuler.net/problem=4

// You are given the following two functions. You do not need to re-implement them.
let ReverseString (xString: string) =
    new string (xString.ToCharArray() |> Array.rev)

let IsPalindrome xString =
    (ReverseString xString) = xString

let palindromeResult1 = IsPalindrome "ASDF"   
let palindromeResult2 = IsPalindrome "ABCCBA"   
    

let findProductPalindrome =
    List.allPairs [100 .. 999] [100 .. 999]
    // |> List.map (fun (a,b) -> ..............)
    // |> ..............

    failwith "NOT YET IMPLEMENTED!"





