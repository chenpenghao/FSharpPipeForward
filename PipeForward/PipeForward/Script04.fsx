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

printfn "The first school has %i students" totalStudent1

3.5 |> System.Math.Round

///////////////////////////////////////////////////////////////////////////
// Extraaction process in the lambda/anonymous function:
let TotalStudentVersion2 (studentList: List<string * int>) =
    studentList
    |> List.map (fun (_,numStudent) -> numStudent)
    |> List.sum

let totalStudent2 = TotalStudentVersion2 studentList
printfn "The second school has %i students" totalStudent2


//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////
// 
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
        let (_,priceBeforeTax,productType) = tuple
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
// 