// Auto-generated code below aims at helping you parse
// the standard input according to the problem statement.
// ---
// Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
program Answer;
{$H+}
uses sysutils, classes, math;

// Helper to read a line and split tokens
procedure ParseIn(Inputs: TStrings) ;
var Line : string;
begin
    readln(Line);
    Inputs.Clear;
    Inputs.Delimiter := ' ';
    Inputs.DelimitedText := Line;
end;

var
    lightX : Int32; // the X position of the light of power
    lightY : Int32; // the Y position of the light of power
    initialTX : Int32; // Thor's starting X position
    initialTY : Int32; // Thor's starting Y position
    remainingTurns : Int32; // The remaining amount of turns Thor can move. Do not remove this line.
    Inputs: TStringList;
    a: string;
begin
    Inputs := TStringList.Create;
    ParseIn(Inputs);
    lightX := StrToInt(Inputs[0]);
    lightY := StrToInt(Inputs[1]);
    initialTX := StrToInt(Inputs[2]);
    initialTY := StrToInt(Inputs[3]);

    // game loop
    while true do
    begin
        ParseIn(Inputs);
        remainingTurns := StrToInt(Inputs[0]);

        a := '';

        if (lightY > initialTy) then begin
            a += 'S';
            initialTy+=1;
        end
        else if (lightY < initialTy) then begin
            a += 'N';
            initialTy-=1;
        end;

        if (lightX < initialTx) then begin
            a += 'W';
            initialTx-=1;
        end else if (lightX > initialTx) then begin
            a += 'E';
            initialTx+=1;
        end;


        // A single line providing the move to be made: N NE E SE S SW W or NW
        writeln(a);
        flush(StdErr); flush(output); // DO NOT REMOVE
    end;
end.