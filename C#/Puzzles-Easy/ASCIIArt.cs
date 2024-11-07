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
    // 07/11/2024 : I was starting C# at this point, there might be way more elegant ways to solve this
    // Maybe I will comeback to it later if I don't forget
    static void Main(string[] args)
    {
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine().ToUpper();
        
        for (int i = 0; i < H; i++)
        {
            string ROW = Console.ReadLine();

            foreach( char c in T ){
                char letter = c;
                int letterIdx = (letter - 'A') * L; // This gives the corresponding index of Letter in given ASCII Style as Input
                                                    // Example : D - A = 3 * 4 = 12 ( With L = 4 )
                if( c < 'A' || c > 'Z' ){
                    letter = '?'; // If letter isn't in the alphabet we replace with ?
                    letterIdx = ('Z' - 'A' + 1) * L; // Hardcoding is bad :( Would not work if the style string was different (e.g Supporting more characters)
                }

                for (int j = 0; j < L; j++){
                    Console.Write(ROW[j+letterIdx]); // Offset the letter index with each column to print all the ASCII characters of each letter for each Row
                }
            }
            Console.WriteLine(); // Printing new line
        }
    }
}