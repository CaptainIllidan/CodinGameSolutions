-- Auto-generated code below aims at helping you parse
-- the standard input according to the problem statement.
-- ---
-- Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.

-- lightX: the X position of the light of power
-- lightY: the Y position of the light of power
-- initialTX: Thor's starting X position
-- initialTY: Thor's starting Y position
next_token = string.gmatch(io.read(), "[^%s]+")
lightX = tonumber(next_token())
lightY = tonumber(next_token())
initialTx = tonumber(next_token())
initialTy = tonumber(next_token())

-- game loop
while true do
    remainingTurns = tonumber(io.read()) -- The remaining amount of turns Thor can move. Do not remove this line.
    
    answer = "";
        if (lightY > initialTy) then
                answer = answer .. "S";
                initialTy = initialTy + 1;
            
            elseif (lightY < initialTy) then
                answer = answer .. "N";
                initialTy = initialTy -1;
            end;

            if (lightX < initialTx) then
                answer = answer .. "W";
                initialTx=initialTx-1;
            
            elseif (lightX > initialTx) then
                answer = answer .. "E";
                initialTx=initialTx+1;
            end;
            
    

    -- A single line providing the move to be made: N NE E SE S SW W or NW
    print(answer)
end