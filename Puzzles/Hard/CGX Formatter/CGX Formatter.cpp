#include <iostream>

using namespace std;

int main() {

  int INDENT = 0;
  bool IN_STRING = false;
  bool NEWLINE = true;
  int n;

  cin >> n;
  cin >> noskipws;

  for (char c; cin >> c; ) {
    if (IN_STRING) {
      IN_STRING = (c != '\'');
      cout << c;
    } else switch (c) {
      case '(':
        if (!NEWLINE)
          cout << endl;
        cout << string(INDENT, ' ') << c << endl;
        INDENT+= 4;
        NEWLINE = true;
        break;
      case ')':
        if (!NEWLINE)
          cout << endl;
        INDENT-= 4;
        NEWLINE = false;
        cout << string(INDENT, ' ') << c;
        break;
      case '\'':
        cout << string(NEWLINE * INDENT, ' ') << c;
        IN_STRING = true;
        NEWLINE = false;
        break;
      case ';':
        cout << c << endl;
        NEWLINE = true;
        break;
      case ' ':
      case '\t':
      case '\n':
        break;
      default:
        cout << string(NEWLINE * INDENT, ' ') << c;
        NEWLINE = false;
      }
   }
}