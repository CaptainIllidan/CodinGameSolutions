package main

import "fmt"

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
 **/

func main() {
    // lightX: the X position of the light of power
    // lightY: the Y position of the light of power
    // initialTx: Thor's starting X position
    // initialTy: Thor's starting Y position
    var lightX, lightY, initialTx, initialTy int
    fmt.Scan(&lightX, &lightY, &initialTx, &initialTy)
    
    for {
        // remainingTurns: The remaining amount of turns Thor can move. Do not remove this line.
        var remainingTurns int
        fmt.Scan(&remainingTurns)
        
        var answer string
        answer = ""
        if lightY > initialTy {
            answer += "S";
            initialTy++;
        } else if lightY < initialTy {
            answer += "N";
            initialTy--;
        }

        if lightX < initialTx {
            answer += "W";
            initialTx--;
        } else if (lightX > initialTx) {
            answer += "E";
            initialTx++;
        }
        
        // A single line providing the move to be made: N NE E SE S SW W or NW
        fmt.Println(answer)
    }
}