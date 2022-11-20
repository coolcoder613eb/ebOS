using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.IO;
using Sys = Cosmos.System;

namespace ebOS
{
    public class Kernel : Sys.Kernel
    {
		private const string ver = "1.0.0";
		private const string calcver = "1.0.0";
		private const string cryptver = "1.0.0";

		protected override void BeforeRun()
        {
            Console.WriteLine("ebOS booted successfully.");
        }

        protected override void Run()
        {
			
			/*string[] getdir(string path)
			{
				string[] dirs = Directory.GetFileSystemEntries(path);
				return dirs;
			}*/
			
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			string ebos = @"
           ##
           ##         ####     #####
           ##        ##  ##   ##   ##
   #####   ######   ##    ##  ##
  ##   ##  ##   ##  ##    ##   #####
  #######  ##   ##  ##    ##       ##
  ##       ##   ##   ##  ##   ##   ##
   #####   ######     ####     #####

";
			Console.WriteLine(ebos);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("  ");
			about();
			Console.ForegroundColor = ConsoleColor.White;
			while (true)
			{
				
				Console.Write("ebOS:> ");
				string i1 = Console.ReadLine();
				string i = i1.ToLower();
				string[] ilist = i.Split(' ');
				switch (ilist[0])
				{
					//system commands
					case "shutdown":
						Console.WriteLine("Shutting down...");
						Sys.Power.Shutdown();
						break;
					case "reboot":
						Console.WriteLine("Rebooting...");
						Sys.Power.Reboot();
						break;
					case "restart":
						Console.WriteLine("Rebooting...");
						Sys.Power.Reboot();
						break;
					//info
					case "about":
						about();
						break;
					case "ver":
						about();
						break;
					case "help":
						help();
						break;
					/*
					case "dir":
						if (!(ilist.Length > 1))
						{
							getdir(ilist[1]);

						}
						else
						{
							getdir(Directory.GetCurrentDirectory());

						}
						about();
						break;
					*/
					//terminal
					case "cls":
						Console.Clear();
						break;
					case "echo":
						Console.WriteLine(i1.Remove(0, 5));
						break;
					//apps
					case "calc":
						//Console.ForegroundColor = ConsoleColor.Blue;
						Console.WriteLine("calc " + calcver);
						//Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("Evaluate expression:");
						EvaluateString.Run();
						break;
					case "crypt":
						//Console.ForegroundColor = ConsoleColor.Blue;
						Console.WriteLine("crypt " + cryptver);
						//Console.ForegroundColor = ConsoleColor.White;
						Encrypt.Run();
						break;
					//no reason
					case "hello":
						Console.WriteLine("Hello World");
						break;
					case "zen":
						Console.WriteLine("The Zen of Python, by Tim Peters\n\nBeautiful is better than ugly.\nExplicit is better than implicit.\nSimple is better than complex.\nComplex is better than complicated.\nFlat is better than nested.\nSparse is better than dense.\nReadability counts.\nSpecial cases aren't special enough to break the rules.\nAlthough practicality beats purity.\nErrors should never pass silently.\nUnless explicitly silenced.\nIn the face of ambiguity, refuse the temptation to guess.\nThere should be one-- and preferably only one --obvious way to do it.\nAlthough that way may not be obvious at first unless you're Dutch.\nNow is better than never.\nAlthough never is often better than *right* now.\nIf the implementation is hard to explain, it's a bad idea.\nIf the implementation is easy to explain, it may be a good idea.\nNamespaces are one honking great idea -- let's do more of those!");
						break;
					//default
					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("\"" + i + "\"" + " is not a command!");
						Console.ForegroundColor = ConsoleColor.White;
						break;
				}
			}
        }
		static void about()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("ebOS " + ver);
			Console.ForegroundColor = ConsoleColor.White;
		}
		static void help()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("ebOS " + ver);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("system commands: ");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("shutdown - shut down");
			Console.WriteLine("reboot/restart - reboot the system");
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("info:");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("about/ver - show version");
			Console.WriteLine("help - show this help message");
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("other:");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("zen - show the zen of python");
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("terminal:");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("cls - clear terminal");
			Console.WriteLine("echo - echo text");
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("apps:");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("calc - calculator ");
			Console.WriteLine("crypt - encrypt and decrypt messages");
			Console.ForegroundColor = ConsoleColor.White;
		}

	}
}
