import std;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
 **/

void main()
{
    auto inputs = readln.split;
    int lightX = inputs[0].to!int; // the X position of the light of power
    int lightY = inputs[1].to!int; // the Y position of the light of power
    int initialTx = inputs[2].to!int; // Thor's starting X position
    int initialTy = inputs[3].to!int; // Thor's starting Y position

    // game loop
    while (1) {
        int remainingTurns = readln.chomp.to!int; // The remaining amount of turns Thor can move. Do not remove this line.
            
          if (lightY > initialTy) {
                write("S");
                initialTy++;
            } else if (lightY < initialTy) {
                write("N");
                initialTy--;
            }

            if (lightX < initialTx) {
                write("W");
                initialTx--;
            } else if (lightX > initialTx) {
                write("E");
                initialTx++;
            }


        // A single line providing the move to be made: N NE E SE S SW W or NW
        writeln();
    }
}