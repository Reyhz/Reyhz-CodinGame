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
        string val = "2345678910JQKA"; // Char index is the card value
        Queue<string> deckp1 = new Queue<string>();
        Queue<string> deckp2 = new Queue<string>();

        int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
        for (int i = 0; i < n; i++)
        {
            string cardp1 = Console.ReadLine(); // the n cards of player 1
            deckp1.Enqueue(cardp1);
        }
        int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
        for (int i = 0; i < m; i++)
        {
            string cardp2 = Console.ReadLine(); // the m cards of player 2
            deckp2.Enqueue(cardp2);
        }

        int rounds = 0;
        bool exAqueo = false;
        List<string> fieldp1 = new List<string>();
        List<string> fieldp2 = new List<string>();
        while(deckp1.Count > 0 && deckp2.Count > 0 && !exAqueo){
            fieldp1.Add(deckp1.Dequeue());
            fieldp2.Add(deckp2.Dequeue());

            if(val.IndexOf(fieldp1[fieldp1.Count-1][0]) > val.IndexOf(fieldp2[fieldp2.Count-1][0])){
                foreach(string s in fieldp1){
                    deckp1.Enqueue(s);
                }
                foreach(string s in fieldp2){
                    deckp1.Enqueue(s);
                }
            }
            else if(val.IndexOf(fieldp1[fieldp1.Count-1][0]) < val.IndexOf(fieldp2[fieldp2.Count-1][0])){
                foreach(string s in fieldp1){
                    deckp2.Enqueue(s);
                }
                foreach(string s in fieldp2){
                    deckp2.Enqueue(s);
                }
            }
            else{
                for(int i = 0; i<3; i++){
                    if(deckp1.Count <= 0 || deckp2.Count <= 0){
                        exAqueo = true;
                        break;
                    }
                    fieldp1.Add(deckp1.Dequeue());
                    fieldp2.Add(deckp2.Dequeue());
                }
                continue; // If a war happens, it's all in one round, so we skip the round increment
            }

            rounds++;
            // We empty the Card on the playing field once a round finishes
            fieldp1.RemoveAll(i => true);
            fieldp2.RemoveAll(i => true);
        }

        if(exAqueo){
            Console.WriteLine("PAT");
        }
        else if(deckp1.Count == 0){
            Console.WriteLine("2 " + rounds);
        }
        else{
            Console.WriteLine("1 " + rounds);
        }
    }
}