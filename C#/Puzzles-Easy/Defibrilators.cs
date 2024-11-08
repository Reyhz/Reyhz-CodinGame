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
        // .Replace() could be swapped with CultureInfo.GetCultureInfo("fr-FR") using System.Globalization
        double LON = double.Parse(Console.ReadLine().Replace(',','.'));
        double LAT = double.Parse(Console.ReadLine().Replace(',','.'));

        int N = int.Parse(Console.ReadLine());
        
        double distToClosest = double.MaxValue;
        string defibName = string.Empty;
        for (int i = 0; i < N; i++)
        {
            string DEFIB = Console.ReadLine();
            string[] defibData = DEFIB.Split(';',6);

            // Data is always formatted the same way, so idx 4 is Longitude while idx 5 is Latitude
            double defibLON = double.Parse(defibData[4].Replace(',','.'));
            double defibLAT = double.Parse(defibData[5].Replace(',','.'));

            /** Dist is calculated using the following formulas
             *  x = (LonB - LonA) * cos((LatA + LatB) / 2)
             *  y = (LatB - LatA)
             *  dist = sqrt(x^2 + y^2) * 6371 : 6371 is Earth Diameter in km
             **/
            double x = (defibLON - LON) * Math.Cos((LAT + defibLAT)/2); // Math.Cos() returns a value in radians, no converting necessary !
            double y = defibLAT - LAT;

            double defibDist = Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2)) * 6371;

            if( defibDist < distToClosest ){
                distToClosest = defibDist;
                defibName = defibData[1];
            }
        }
        Console.WriteLine(defibName);
    }
}