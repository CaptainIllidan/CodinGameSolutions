#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
    int lightX; // the X position of the light of power
    int lightY; // the Y position of the light of power
    int initialTX; // Thor's starting X position
    int initialTY; // Thor's starting Y position
    cin >> lightX >> lightY >> initialTX >> initialTY; cin.ignore();

    // game loop
    while (1) {
        int remainingTurns;
        cin >> remainingTurns; cin.ignore();
        string answer;

        if (lightY > initialTY) {
            answer += "S";
            initialTY++;
        } else if (lightY < initialTY) {
            answer += "N";
            initialTY--;
        }

        if (lightX < initialTX) {
            answer += "W";
            initialTX--;
        } else if (lightX > initialTX) {
            answer += "E";
            initialTX++;
        }
        // A single line providing the move to be made: N NE E SE S SW W or NW
        cout << answer << endl;
    }
}