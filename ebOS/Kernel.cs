using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;

namespace ebOS
{
    public class Kernel : Sys.Kernel
    {
		private const string ver = "1.0.0";
		protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
        }

        protected override void Run()
        {
			void about()
			{
				Console.WriteLine("ebOS " + ver);
			}
			string[] getdir(string path)
			{
				string[] dirs = Directory.GetFileSystemEntries(path);
				return dirs;
			}
			void help()
			{
				Console.WriteLine("ebOS " + ver);
				Console.WriteLine("\nsystem commands:\n" +
					"shutdown - shut down\n" +
					"reboot/restart - reboot the system\n" +
					"\ninfo:\n" +
					"about/ver - show version\n" +
					"help - show this help message\n" +
					"\nother:\n" +
					"zen - show the zen of python");
				//		"hello - display greeting\n" +
				//		"zen - display zen of python\n");
			}
			Kernel program = new Kernel();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(@"
           ##
           ##         ###     #####
           ##        ## ##   ##   ##
   #####   ######   ##   ##  ##
  ##   ##  ##   ##  ##   ##   #####
  #######  ##   ##  ##   ##       ##
  ##       ##   ##   ## ##   ##   ##
   #####   ######     ###     #####

");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("  ");
			about();
			Console.ForegroundColor = ConsoleColor.White;
			while (true)
			{
				Console.Write("0:> ");
				string i = Console.ReadLine().ToLower();
				string[] ilist = i.Split(' ');
				switch (ilist[0])
				{
					//system commands
					case "shutdown":
						//Cosmos.Sys.Deboot.ShutDown()
						Console.WriteLine("Shutting down...");
						break;
					case "reboot":
						//Cosmos.Sys.Deboot.Reboot();
						Console.WriteLine("Rebooting...");
						break;
					case "restart":
						//Cosmos.Sys.Deboot.Reboot();
						Console.WriteLine("Rebooting...");
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
					//no reason
					case "hello":
						Console.WriteLine("Hello World");
						break;
					case "zen":
						Console.WriteLine("The Zen of Python, by Tim Peters\n\nBeautiful is better than ugly.\nExplicit is better than implicit.\nSimple is better than complex.\nComplex is better than complicated.\nFlat is better than nested.\nSparse is better than dense.\nReadability counts.\nSpecial cases aren't special enough to break the rules.\nAlthough practicality beats purity.\nErrors should never pass silently.\nUnless explicitly silenced.\nIn the face of ambiguity, refuse the temptation to guess.\nThere should be one-- and preferably only one --obvious way to do it.\nAlthough that way may not be obvious at first unless you're Dutch.\nNow is better than never.\nAlthough never is often better than *right* now.\nIf the implementation is hard to explain, it's a bad idea.\nIf the implementation is easy to explain, it may be a good idea.\nNamespaces are one honking great idea -- let's do more of those!");
						break;

					//default
					default:
						Console.WriteLine(i + " is not a command!");
						break;

				}
			}
        }
		
		
	}
}
