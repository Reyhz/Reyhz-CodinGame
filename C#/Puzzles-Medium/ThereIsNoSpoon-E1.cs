using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Player
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis

        List<string> grid = new List<string>();

        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .
            grid.Add(line);
        }

        int[] x1 = {0,0};
        int[] x2 = {0,0};
        int[] x3 = {0,0};

        for(int i = 0; i < grid.Count; i++){
            for(int j = 0; j < grid[i].Length; j++){
                if(grid[i][j] == '0'){
                    x1 = [j,i];

                    int neigh = j+1; // Checking for nearest horizontal cell neighbor
                    while(neigh < grid[i].Length && grid[i][neigh] != '0'){
                        neigh++;
                    }
                    if( neigh < grid[i].Length && grid[i][neigh] == '0'){
                        x2 = [neigh,i];
                    }
                    else{
                        x2 = [-1,-1];
                    }

                    neigh = i+1; // Checking for nearest vertical cell neighbor
                    while(neigh < grid.Count && grid[neigh][j] != '0'){
                        neigh++;
                    }
                    if( neigh < grid.Count && grid[neigh][j] == '0'){
                        x3 = [j,neigh];
                    }
                    else{
                        x3 = [-1,-1];
                    }
                    
                    // Output
                    string str1 = x1[0].ToString() + " " + x1[1].ToString();
                    string str2 = x2[0].ToString() + " " + x2[1].ToString();
                    string str3 = x3[0].ToString() + " " + x3[1].ToString();
                    Console.WriteLine(str1 + " " + str2 + " " + str3);
                } 
            }
        }
    }
}