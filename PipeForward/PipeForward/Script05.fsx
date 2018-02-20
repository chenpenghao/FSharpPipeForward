
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

