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
class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        string[] inputs = Console.ReadLine().Split(' ');

        int closest = 6000; // 6000 > 5526 (Max Temp), if unchanged, no temperature was inputted
        int temperature = 0; // Storing the closest temperature to zero. Init with 0 in case no temperature is given as input
        for (int i = 0; i < n; i++)
        {
            int t = int.Parse(inputs[i]);// a temperature expressed as an integer ranging from -273 to 5526
            int tmp = Math.Abs(t);
            if( Math.Min(closest,tmp) != closest || (closest == tmp && t > 0)){
                closest = tmp;
                temperature = t;
            }
        }

        Console.WriteLine(temperature);
    }
}