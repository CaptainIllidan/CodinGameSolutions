import Glibc
import Foundation

public struct StderrOutputStream: TextOutputStream {
    public mutating func write(_ string: String) { fputs(string, stderr) }
}
public var errStream = StderrOutputStream()

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
 **/

let inputs = (readLine()!).split(separator: " ").map(String.init)
let lightX = Int(inputs[0])! // the X position of the light of power
let lightY = Int(inputs[1])! // the Y position of the light of power
var initialTx = Int(inputs[2])! // Thor's starting X position
var initialTy = Int(inputs[3])! // Thor's starting Y position

// game loop
while true {
    let remainingTurns = Int(readLine()!)! // The remaining amount of turns Thor can move. Do not remove this line.

        var answer: String = ""

        if lightY > initialTy{
            answer += "S"
            initialTy+=1
        } else if lightY < initialTy{
            answer += "N"
            initialTy-=1
        }

        if lightX < initialTx{
            answer += "W"
            initialTx-=1
        } else if lightX > initialTx{
            answer += "E"
            initialTx+=1
        }
    print(answer);
}
