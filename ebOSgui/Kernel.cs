using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.IO; 
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using Cosmos.Core.IOGroup;
using System.Threading;
using Cosmos.System;
using System.Reflection;
using System.Net.Sockets;

namespace ebOS
{
    public class Kernel : Sys.Kernel
    {
        public static Canvas canvas;
        public static Mouse m;
        private const string ver = "1.0.0";
        private const string calcver = "1.0.0";
        private const string cryptver = "1.0.0";
        private const string xoxver = "1.0.0";
        //static 
        static Sys.Graphics.Point bp = new Sys.Graphics.Point(30, 30);static int bw = 60;static int bh = 30;

        protected override void BeforeRun()
        {
            System.Console.WriteLine("ebOS booted successfully.");
            System.Console.WriteLine("Maybe a issue on driver which not showing canvas");
            //canvas = new canv();
            canvas = FullScreenCanvas.GetFullScreenCanvas();
            canvas.Mode = new Mode(800, 600, ColorDepth.ColorDepth32);
            canvas.Clear(Color.Green);

            Sys.MouseManager.ScreenWidth = 800;
            Sys.MouseManager.ScreenHeight = 600;

            Sys.MouseManager.X = (uint)((int)canvas.Mode.Columns / 2);
            Sys.MouseManager.Y = (uint)((int)canvas.Mode.Rows / 2);
            drawbutton();
        }

        protected override void Run()
        {
            try
            {
                drawscreen();


            }
            catch (Exception e)
            {
                //mDebugger.Send("Exception occurred: " + e.Message);
                Sys.Power.Shutdown();
            }
        }
        static void drawmouse()
        {
            Pen bluepen = new Pen(Color.Cyan);
            canvas.DrawPoint(bluepen, new Sys.Graphics.Point((int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y));
            canvas.DrawPoint(bluepen, new Sys.Graphics.Point((int)Cosmos.System.MouseManager.X + 1, (int)Cosmos.System.MouseManager.Y));
            canvas.DrawPoint(bluepen, new Sys.Graphics.Point((int)Cosmos.System.MouseManager.X + 2, (int)Cosmos.System.MouseManager.Y));
            canvas.DrawPoint(bluepen, new Sys.Graphics.Point((int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y + 1));
            canvas.DrawPoint(bluepen, new Sys.Graphics.Point((int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y + 2));
            canvas.DrawPoint(bluepen, new Sys.Graphics.Point((int)Cosmos.System.MouseManager.X + 1, (int)Cosmos.System.MouseManager.Y + 1));
            canvas.DrawPoint(bluepen, new Sys.Graphics.Point((int)Cosmos.System.MouseManager.X + 2, (int)Cosmos.System.MouseManager.Y + 2));
            canvas.DrawPoint(bluepen, new Sys.Graphics.Point((int)Cosmos.System.MouseManager.X + 3, (int)Cosmos.System.MouseManager.Y + 3));
        }
        static bool isclick(Sys.Graphics.Point point, int w, int h)
        {
            if (MouseManager.MouseState == MouseState.Left && MouseManager.X >= point.X && MouseManager.X <= point.X + w && MouseManager.Y >= point.Y && MouseManager.Y <= point.Y + h)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void drawscreen()
        {
            canvas.Clear(Color.Green);
            drawbutton();
            button();
            drawmouse();
            canvas.Display();

        }
        static void drawbutton()
        {
            
            Pen blackpen = new Pen(Color.Black);
            Pen whitepen = new Pen(Color.White);
            canvas.DrawFilledRectangle(blackpen, bp, bw, bh);
            //canvas.DrawString("shutdown", whitepen,new Sys.Graphics.Fonts.PCScreenFont,new Sys.Graphics.Point(32, 32));
            //Bitmap shutdown = new Bitmap(120, 30, images.shutdown, ColorDepth.ColorDepth32);
            //canvas.DrawImage(shutdown, new Sys.Graphics.Point(32, 32));
        }
            static void button()
        {
            
            if (isclick(bp, bw, bh))
            {
                Sys.Power.Shutdown();
            }
        }
    }
}
