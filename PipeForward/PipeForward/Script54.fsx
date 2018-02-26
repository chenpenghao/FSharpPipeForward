


let inline Product x y = x * y

let multiply2Int = Product 2 3
printfn "Multiply the two numbers gives: %i" multiply2Int

let multiply2Double = Product 3.0 4.0
printfn "Multiply the two numbers gives: %f" multiply2Double

// Not every data type supports multiplication "*"

// Un-comment to see the error
// ERROR: The string type does not support multiplication "*"
// let multiplyTwoString = Product "HELLO" "BYE"

/////////////////////////

let inline CustomAdd x y z = x + y + z
let add3IntegerResult = CustomAdd 4 5 6
printfn "Adding the three integers give: %i" add3IntegerResult

let add3StringResult = CustomAdd "John " "F." " Kennedy"
printfn "Concatenate the three strings give: %s" add3StringResult

let add3DecimalResult = CustomAdd 10.3 10.2 10.1
printfn "Adding the three decimals give: %f" add3DecimalResult

// Not every data type supports addition "+"

// Un-comment to see the error
// ERROR: The boolean type (true/false) does not support addition "+"
// let add3Bool = NewAdd3 true false false

let A1 = [1;2;3]
let B1 = [1;2;3]

A1 = B1

let C1 = seq {1 .. 3}
let D1 = seq {1 .. 3}

C1 = D1

let E1 = 
    [(1,"A"); (2,"B"); (3,"C")]
    |> dict
let F1 = 
    [(1,"A"); (2,"B"); (3,"C")]
    |> dict

E1 = F1

let G1 = 
    [(1,"A"); (2,"B"); (3,"C")]
    |> Map
let H1 = 
    [(1,"A"); (3,"C"); (2,"B")]
    |> Map

G1 = H1

let set1 = [1;2;3;4;5;5] |> Set 
let set2 = [1;5;4;2;3] |> Set

set1 = set2

open System.Numerics

let IsPrime x =
    let squareRoot = x |> double |> sqrt |> int
    if x = 1 then false
    else if x = 2 then true
    else if x % 2 = 0 then false
    else
        [3 .. 2 .. squareRoot]
        |> List.forall (fun i -> x % i <> 0)

let SumAllPrimes xList =
    xList
    |> List.filter (IsPrime)
    |> List.map (BigInteger)
    |> List.sum

let FindPythagoreanTriple range =
    List.allPairs [1 .. range] [1 .. range]
    |> List.filter (fun (a, b) -> 
        a * a + b * b = (range - a - b) * (range - a - b) && 
        a < b
    )

open System.Numerics

module ProjectEuler =
     let two = BigInteger(2)
     let zero = BigInteger(0)

     let isPrime n =
            let sqN = BigInteger (sqrt (float n))
            if n = BigInteger(1) then false
            else if n = two then true
            else if n % two = zero then false
            else 
                [BigInteger(3) .. two.. sqN]
                |> Seq.forall (fun x -> n % x <> zero)
    
    let Q1 =
        [1..999]
        |> List.filter (fun x -> x % 3 = 0 || x % 5 = 0)
        |> List.sum

    let Q2 =
        let phi = (sqrt 5.0 + 1.0) / 2.0
        let Phi = phi - 1.0
        let factor = 1.0 / sqrt 5.0
        let fib n = int (round (factor * (phi ** float n - Phi ** float n)))
        let limit = 35
        [1 .. limit]
        |> List.map fib
        |> List.filter (fun x -> x < 4000000)
        |> List.filter (fun x -> x % 2 = 0)
        |> List.sum

    let Q2alt =
        [0 .. 35]
        |> List.scan (fun (x,y,z) _ -> (y, z, x + y + z)) (1, 1, 1)
        |> List.map (fun (_,_,z) -> z)
        |> List.append [1; 1]

    let Q8 =
        let initString = "73167176531330624919225119674426574742355349194934" +
                            "96983520312774506326239578318016984801869478851843" +
                            "85861560789112949495459501737958331952853208805511" +
                            "12540698747158523863050715693290963295227443043557" +
                            "66896648950445244523161731856403098711121722383113" +
                            "62229893423380308135336276614282806444486645238749" +
                            "30358907296290491560440772390713810515859307960866" +
                            "70172427121883998797908792274921901699720888093776" (*+*)
                            //"65727333001053367881220235421809751254540594752243" +
                            //"52584907711670556013604839586446706324415722155397" +
                            //"53697817977846174064955149290862569321978468622482" +
                            //"83972241375657056057490261407972968652414535100474" +
                            //"82166370484403199890008895243450658541227588666881" +
                            //"16427171479924442928230863465674813919123162824586" +
                            //"17866458359124566529476545682848912883142607690042" +
                            //"24219022671055626321111109370544217506941658960408" +
                            //"07198403850962455444362981230987879927244284909188" +
                            //"84580156166097919133875499200524063689912560717606" +
                            //"05886116467109405077541002256983155200055935729725" +
                            //"71636269561882670428252483600823257530420752963450"
        initString
        |> Seq.toList
        |> List.map (string >> BigInteger.Parse)
        |> List.windowed 13
        |> List.map (List.reduce (*))
        |> List.max
    
    let Q4 =
        let revStr (str: string) =
            str
            |> Seq.toList
            |> List.map (string)
            |> List.rev
            |> List.reduce (+)
        Seq.allPairs [100 .. 999] [100 .. 999]
        |> Seq.map (fun (x,y) -> (x, y, x * y))
        |> Seq.filter(
            fun (_, _, prod) ->
                revStr (string prod) = string prod
        )
        |> Seq.maxBy (fun (_, _, prod) -> prod)
    
    let Q7 =        
        [2 .. 150000]
        |> List.map BigInteger
        |> List.filter ProjectEuler.isPrime
        |> fun x -> x.[10000]

    let Q6 =
        [1..100]
        |> List.sum
        |> fun x -> x*x
        |> fun x -> x - (
            [1..100]
            |> List.map (fun x -> x * x)
            |> List.sum
        )

    let Q5 =
        let rec gcd x y = if y = BigInteger 0 then abs x else gcd y (x % y)
        let lcm x y = x * y / (gcd x y)
        [1 .. 20]
        |> List.map BigInteger
        |> List.reduce (fun x y -> lcm x y)

    let Q3 =
        let n = BigInteger.Parse "600851475143"
        let sqN = BigInteger ((float n) ** 0.5)
        [BigInteger(3).. BigInteger(2) .. sqN]
        |> Seq.filter (fun x -> ProjectEuler.isPrime x)
        |> Seq.filter (fun x -> n % x = BigInteger(0))
        |> Seq.max

    let Q3alt =
        let Z = BigInteger.Parse "600851475143"

        let approxSqrt =
            Z |> double |> sqrt |> BigInteger
        let listHead =
            [ProjectEuler.two .. approxSqrt]
            |> List.filter (fun x -> Z % x = ProjectEuler.zero)
        let listTail =
            listHead
            |> List.map (fun x -> Z / x)
        let listFact = List.append listHead listTail
        listFact
        |> List.filter ProjectEuler.isPrime
        |> List.max

    let Q9 =
        Seq.allPairs [1..1000] [1..1000]
        |> Seq.filter (fun (x,y) -> x < y && x * x + y * y = (1000 - x - y) * (1000 - x - y))
        |> Seq.head
        |> fun (x,y) -> x * y * (1000 - x - y)

    let Q10 =
        let isPrime n =
            let sqN = int (sqrt (float n))
            if n = 2 then true
            else if n % 2 = 0 then false
            else 
                [3 .. 2 .. sqN]
                |> Seq.forall (fun x -> n % x <> 0)
        
        [2 .. 2000000]
        |> Seq.filter isPrime
        |> Seq.map BigInteger
        |> Seq.sum

    let Q11 =
        let numbers =
            "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08 " +
            "49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00 " +
            "81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65 " +
            "52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91 " +
            "22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80 " +
            "24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50 " +
            "32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70 " +
            "67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21 " +
            "24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72 " +
            "21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95 " +
            "78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92 " +
            "16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57 " +
            "86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58 " +
            "19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40 " +
            "04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66 " +
            "88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69 " +
            "04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36 " +
            "20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16 " +
            "20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54 " +
            "01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48"
        
        numbers
        |> fun str -> str.Split [|' '|]
        |> Array.toList
        |> List.map int

    let Q12 =
        let zero = BigInteger 0
        let sqN n = n |> double |> sqrt |> BigInteger
        let limit = BigInteger 13000
        let triangle n = n * (n + BigInteger(1))/BigInteger(2)

        [zero..limit]
        |> List.map triangle
        |> List.filter (fun j -> j > (triangle (BigInteger(12000)) ))
        |> List.map (fun x -> (x, [BigInteger(1) .. sqN x]))
        |> List.map (fun (x, lst) ->
            let head = 
                lst
                |> List.filter (fun i -> x % i = zero)
            let tail =
                head
                |> List.map (fun i -> x / i)
            let factors = List.append head tail
            factors
            |> Set
            |> Set.toSeq
            |> Seq.length
            |> fun i -> (x, i)
        )
        |> List.filter (fun (x, i) -> i > 500)

    let Q14 =
        let one = BigInteger 1
        let zero = BigInteger 0
        let two = BigInteger 2
        let three = BigInteger 3

        let mutable dict = [(one, zero)]
        let rec cd (n: BigInteger):BigInteger =
            let haveN =
                dict |> List.filter (fun (x, _) -> x = n)
            if (List.isEmpty haveN) = false then
                haveN |> List.head |> (fun (_, v) -> v)
            else if n = one then zero
            else if n % two = zero then 
                let res = cd(n / two) + one
                dict <- List.append dict [(n, res)]
                res
            else 
                let res = cd(three * n + one) + one
                dict <- List.append dict [(n, res)]
                res
            
        [871 .. 10000]
        |> List.map BigInteger
        |> List.map (fun i -> (i, cd i))
        |> List.maxBy (fun (_, v) -> v)

        
