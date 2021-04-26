Module Player
' Auto-generated code below aims at helping you parse
' the standard input according to the problem statement.
' ---
' Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.

    Sub Main ()
        
        Dim inputs as String()
        Dim lightX as Integer ' the X position of the light of power
        Dim lightY as Integer ' the Y position of the light of power
        Dim initialTX as Integer ' Thor's starting X position
        Dim initialTY as Integer ' Thor's starting Y position
        Dim answer as String
        inputs = Console.ReadLine().Split(" ")
        lightX = inputs(0)
        lightY = inputs(1)
        initialTX = inputs(2)
        initialTY = inputs(3)

        ' game loop
        While True
            Dim remainingTurns as Integer
            remainingTurns = Console.ReadLine() ' The remaining amount of turns Thor can move. Do not remove this line.

            answer = ""

            If lightY > initialTY Then
                answer += "S"
                initialTY+=1
            ElseIf lightY < initialTY Then
                answer += "N"
                initialTY-=1
            End If

            If lightX < initialTX Then
                answer += "W"
                initialTX-=1
            ElseIf lightX > initialTX Then
                answer += "E"
                initialTX+=1
            End If

            Console.WriteLine(answer)
        End While
    End Sub
End Module