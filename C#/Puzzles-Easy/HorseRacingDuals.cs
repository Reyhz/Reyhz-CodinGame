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
        int N = int.Parse(Console.ReadLine());
        int[] powers = new int[N];

        for (int i = 0; i < N; i++)
        {
            powers[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(powers);

        int closest = int.MaxValue;
        for(int i = 1; i < N; i++){
            closest = Math.Min(closest, powers[i] - powers[i-1]); // Array is sorted, so the closest values are next to each other
        }

        Console.WriteLine(closest);
    }
}