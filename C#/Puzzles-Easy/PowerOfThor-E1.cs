using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int lightX = int.Parse(inputs[0]); // the X position of the light of power
        int lightY = int.Parse(inputs[1]); // the Y position of the light of power
        int initialTx = int.Parse(inputs[2]); // Thor's starting X position
        int initialTy = int.Parse(inputs[3]); // Thor's starting Y position

        // game loop
        while (true)
        {
            int remainingTurns = int.Parse(Console.ReadLine()); // The remaining amount of turns Thor can move. Do not remove this line.

            // Calculating the distance to objective using Manhattan Distance
            // distX = X2 - X1 & distY = Y2 - Y1
            // This also conveniently gives us the direction of the objective
            int dirX = lightX - initialTx;
            int dirY = lightY - initialTy;
            
            string move = string.Empty;
            
            if( dirY > 0 ){
                move += 'S'; // adding two string or two character in C# concatenate them
                initialTy++;
            }
            if( dirY < 0 ){
                move += 'N';
                initialTy--;
            }

            if( dirX > 0 ){
                move += 'E';
                initialTx++;
            }
            if( dirX < 0 ){
                move += 'W';
                initialTx--;
            }

            // A single line providing the move to be made: N NE E SE S SW W or NW
            Console.WriteLine(move);
        }
    }
}