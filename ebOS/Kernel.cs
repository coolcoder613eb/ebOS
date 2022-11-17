﻿using System;
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
			void about()
			{
				Console.WriteLine("ebOS " + ver);
			}
			/*string[] getdir(string path)
			{
				string[] dirs = Directory.GetFileSystemEntries(path);
				return dirs;
			}*/
			void help()
			{
				Console.WriteLine("ebOS " + ver+"\n");
				Console.WriteLine(@"system commands: 
shutdown - shut down
reboot/restart - reboot the system

info:
about/ver - show version
help - show this help message
					
other:
zen - show the zen of python

terminal:
cls - clear terminal
echo - echo text

apps:
calc - calculator 
");
				//		"hello - display greeting\n" +
				//		"zen - display zen of python\n");
			}
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
				string i = Console.ReadLine().ToLower();
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
						Console.WriteLine(i.Remove(0, 5));
						break;
					//apps
					case "calc":
						Console.WriteLine("calc " + calcver);
						Console.WriteLine("Evaluate expression:");
						EvaluateString.Run();
						break;
					case "crypt":
						Console.WriteLine("crypt " + cryptver);
						Console.Write("Encrypt or decrypt? ");
						string input = Console.ReadLine();
						if (input == "encrypt")
                        {
							Console.Write("text: ");
							string textinput = Console.ReadLine();
							Console.WriteLine(Encrypt.EncryptString(textinput));
						}
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
