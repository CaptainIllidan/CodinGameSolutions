input = new Scanner(System.in);

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
 **/

lightX = input.nextInt() // the X position of the light of power
lightY = input.nextInt() // the Y position of the light of power
initialTx = input.nextInt() // Thor's starting X position
initialTy = input.nextInt() // Thor's starting Y position

// game loop
while (true) {
    remainingTurns = input.nextInt() // The remaining amount of turns Thor can move. Do not remove this line.

    String answer = ""
    if (lightY > initialTy) {
            answer += "S";
            initialTy++;
        } else if (lightY < initialTy) {
            answer += "N";
            initialTy--;
        }

        if (lightX < initialTx) {
            answer += "W";
            initialTx--;
        } else if (lightX > initialTx) {
            answer += "E";
            initialTx++;
        }


    // A single line providing the move to be made: N NE E SE S SW W or NW
    println(answer);
}