#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <stdbool.h>

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
 **/

int main()
{
    // the X position of the light of power
    int light_x;
    // the Y position of the light of power
    int light_y;
    // Thor's starting X position
    int initial_tx;
    // Thor's starting Y position
    int initial_ty;
    scanf("%d%d%d%d", &light_x, &light_y, &initial_tx, &initial_ty);

    // game loop
    while (1) {
        // The remaining amount of turns Thor can move. Do not remove this line.
        int remaining_turns;
        scanf("%d", &remaining_turns);
        char *answer;

        if (light_y > initial_ty) {
            printf("S");
            initial_ty++;
        } else if (light_y < initial_ty) {
            printf("N");
            initial_ty--;
        }

        if (light_x < initial_tx) {
            printf("W");
            initial_tx--;
        } else if (light_x  > initial_tx) {
            printf("E");
            initial_tx++;
        }


        // A single line providing the move to be made: N NE E SE S SW W or NW
        printf("\n");
    }

    return 0;
}