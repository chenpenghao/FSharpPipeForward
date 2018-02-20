
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

/////////////////////////////////////////////////////////////////////////////


// https://projecteuler.net/problem=5




open System.Numerics

let rec GCD x y =
    let zero = BigInteger(0)
    if x < zero || y < zero then failwith "CANNOT ACCEPT NEGATIVE NUMBERS"
    if x > y then GCD y x
    else if x = zero then y
    else GCD (y % x) x

let LCM x y = 
    x * y / (GCD x y)

[1 .. 20]
|> List.map (BigInteger)
|> List.reduce LCM

////////////////////////////////////////////////////////////////////////////

// https://projecteuler.net/problem=8

let bigIntegerString =
    "73167176531330624919225119674426574742355349194934"+
    "96983520312774506326239578318016984801869478851843"+
    "85861560789112949495459501737958331952853208805511"+
    "12540698747158523863050715693290963295227443043557"+
    "66896648950445244523161731856403098711121722383113"+
    "62229893423380308135336276614282806444486645238749"+
    "30358907296290491560440772390713810515859307960866"+
    "70172427121883998797908792274921901699720888093776"+
    "65727333001053367881220235421809751254540594752243"+
    "52584907711670556013604839586446706324415722155397"+
    "53697817977846174064955149290862569321978468622482"+
    "83972241375657056057490261407972968652414535100474"+
    "82166370484403199890008895243450658541227588666881"+
    "16427171479924442928230863465674813919123162824586"+
    "17866458359124566529476545682848912883142607690042"+
    "24219022671055626321111109370544217506941658960408"+
    "07198403850962455444362981230987879927244284909188"+
    "84580156166097919133875499200524063689912560717606"+
    "05886116467109405077541002256983155200055935729725"+
    "71636269561882670428252483600823257530420752963450"

bigIntegerString
|> Seq.map (string)
|> Seq.map (int)
|> Seq.map (BigInteger)
|> Seq.windowed 13
|> Seq.map (Seq.reduce (*))
|> Seq.max



