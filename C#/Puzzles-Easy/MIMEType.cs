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
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.

        Dictionary<string,string> fExt = new Dictionary<string, string>(); // Extention is Key, MIME Type is Value
        List<string> files = new List<string>(); // Will be used to store the file extension later

        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string EXT = inputs[0].ToLower(); // file extension
            string MT = inputs[1]; // MIME type.
            fExt.Add(EXT,MT);
        }
        for (int i = 0; i < Q; i++)
        {
            string FNAME = Console.ReadLine(); // One file name per line.
            FNAME = FNAME.ToLower(); // Set filename to lowercase to make it case-insensitive

            if(FNAME.Contains('.')){
                FNAME = FNAME.Substring(FNAME.LastIndexOf('.')+1); // Don't care about name, we keep only the extention
            }
            else{
                FNAME = "NO_EXT";
            }
            files.Add(FNAME);
        }

        foreach(string f in files){
            if(f == "NO_EXT"){
                Console.WriteLine("UNKNOWN");
            }
            else if(fExt.ContainsKey(f)){
                // Output MT/EXT on stdout
                string MIMEOutput = string.Empty;
                fExt.TryGetValue(f, out MIMEOutput);
                Console.WriteLine(MIMEOutput);
            }
            else{ // Will print UNKNOWN if extention don't have a MIME Type Associated
                Console.WriteLine("UNKNOWN");
            }

        }
    }
}