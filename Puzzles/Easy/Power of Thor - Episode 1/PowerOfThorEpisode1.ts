/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
 **/

var inputs: string[] = readline().split(' ');
var lightX: number = parseInt(inputs[0]); // the X position of the light of power
var lightY: number = parseInt(inputs[1]); // the Y position of the light of power
var initialTx: number = parseInt(inputs[2]); // Thor's starting X position
var initialTy: number = parseInt(inputs[3]); // Thor's starting Y position
var answer: string;

// game loop
while (true) {
    const remainingTurns: number = parseInt(readline()); // The remaining amount of turns Thor can move. Do not remove this line.

        answer = ""

        if (lightY > initialTy) {
            answer += "S";
            initialTy+=1;
        } else if (lightY < initialTy) {
            answer += "N";
            initialTy-=1;
        }

        if (lightX < initialTx) {
            answer += "W";
            initialTx-=1;
        } else if (lightX > initialTx) {
            answer += "E";
            initialTx+=1;
        }


    // A single line providing the move to be made: N NE E SE S SW W or NW
    console.log(answer);
}
