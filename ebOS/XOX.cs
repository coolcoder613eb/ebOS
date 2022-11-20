// in progress
using System;
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

        void draw()
        {
            Console.Clear();
            Console.WriteLine("+-+-+-+");
            foreach (string[] x in game)
            {
                Console.Write("|");
                foreach (string y in x)
                {
                    Console.Write(y+"|");
                }
                //Console.WriteLine(x);
                Console.WriteLine("+-+-+-+");
            }
            Console.WriteLine("+-+-+-+");
        }
        public void Run()
        {
            draw();
        }
    }
}