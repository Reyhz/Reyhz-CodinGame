using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // width of the building.
        int H = int.Parse(inputs[1]); // height of the building.
        int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);
        
        var min = (x: 0, y: 0);
        var max = (x: W-1, y: H-1); // Coordinates start at 0

        // game loop
        while (true)
        {
            string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

            if(bombDir.Contains("U")){
                max.y = Y0 - 1;
            }
            else if(bombDir.Contains("D")){
                min.y = Y0 + 1;
            }

            if(bombDir.Contains("L")){
                max.x = X0 - 1;
            }
            else if(bombDir.Contains("R")){
                min.x = X0 + 1;
            }

            X0 = min.x + (max.x - min.x) / 2; // Offset bisecsearch by minimum to have next coordinate
            Y0 = min.y + (max.y - min.y) / 2;

            // the location of the next window Batman should jump to.
            Console.WriteLine("{0} {1}",X0,Y0);
        }
    }
}