// in progress
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.IO;
using Sys = Cosmos.System;
namespace ebOS
{
    public class XOX
    {
        static string[] game1 = { " ", " ", " " };
        static string[] game2 = { " ", " ", " " };
        static string[] game3 = { " ", " ", " " };
        static string[][] game = {
        game1,
        game2,
        game3 };
        //string[,] game = {{ " ", " ", " " },{ " ", " ", " " },{ " ", " ", " " }};
        //int[,] game = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        static int turn = 0;
        static bool dorun = true;
        static void draw()
        {
            Console.Clear();
            Console.WriteLine("+-+-+-+");
            /*for (int y = 0; y < game.GetLength(0); y++)
            {
                for (int x = 0; x < game.GetLength(1); x++)
                {
                    Console.Write(game[y, x] + "|");
                }
                Console.Write("\n");
                //Console.WriteLine(x);
                Console.WriteLine("+-+-+-+");
            }*/
            foreach (string[] x in game)
            {
                Console.Write("|");
                foreach (string y in x)
                {
                    Console.Write(y+"|");
                }
                Console.Write("\n");
                //Console.WriteLine(x);
                Console.WriteLine("+-+-+-+");
            }
        }
        public static void Run()
        {
            /*string[] game1 = { " ", " ", " " };
            string[] game2 = { " ", " ", " " };
            string[] game3 = { " ", " ", " " };
            string[][] game = {game1,game2,game3 };*/
            string c = "O";
            turn = 0;
            dorun = true;
            while (dorun)
            {
                draw();
                if ((turn % 2) == 1)
                {
                    Console.WriteLine("X:");
                    c = "X";
                }
                else
                {
                    Console.WriteLine("O:");
                    c = "O";
                }
                bool good = false;
                while (!good)
                {
                    Console.Write("column: ");
                    string col = Console.ReadLine();
                    Console.Write("row: ");
                    string row = Console.ReadLine();
                    if (col == "exit" || row == "exit")
                    {
                        good = true;
                        dorun = false;
                    }
                    else
                    {
                        try
                        {
                            int colint = int.Parse(col);
                            int rowint = int.Parse(row);
                            if ((colint >= 1 && colint <= 3) && (rowint >= 1 && rowint <= 3))
                            {
                                game[rowint - 1][colint - 1] = c;
                                good = true;
                                turn++;
                            }
                            else
                            {
                                Console.WriteLine("Not A Number 1-3!");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Not A Number 1-3!");
                        }
                    }
                    
                }
            }
            
        } 
    }
}