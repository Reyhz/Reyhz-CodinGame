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
        string MESSAGE = Console.ReadLine();
        string binaryStr = string.Empty;

        foreach(char letter in MESSAGE){
            string concatenate = Convert.ToString(letter,2); // Converting character to binary
            if(letter < 64){ // Numbers under 64 are 6bits
                concatenate = '0' + concatenate; // making sure it's always 7bit long
            }
            binaryStr += concatenate;
        }

        char lastNumber = '?'; // ? is not a number so the first number will always go in the first if statement
        for(int i = 0; i < binaryStr.Length; i++){
            if(binaryStr[i] != lastNumber){
                if(i != 0){
                    Console.Write(' '); // Add a space if it's not first character
                }
                lastNumber = binaryStr[i];
                if(lastNumber == '0'){
                    Console.Write("00 ");
                }
                else{
                    Console.Write("0 ");
                }
            }
            Console.Write("0"); // This will print a zero for each repeating binary number
        }
    }
}