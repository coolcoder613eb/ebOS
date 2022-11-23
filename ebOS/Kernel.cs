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
		private const string xoxver = "1.0.0";
		//static 
		

		protected override void BeforeRun()
		{
			Console.WriteLine("ebOS booted successfully.");
		}

		protected override void Run()
		{
			Dictionary<string, string> scripts = new() {
				{ "ysnp", "cls\necho Gandalf - YOU SHALL NOT PASS!\necho Balrog - Why not?\npause\necho Gandalf - BECAUSE I'M IN A RUSH!" },
				{ "sc", "echo Scripts:\nterm list\n" },
				{ "scrhow", "echo How To Write Term Scripts\npause\ncls\necho How To Write Term Scripts\necho  \necho Term scripts are a feature of ebOS,\necho similar to shell scripting.\necho You may write any command\necho which can be used in the terminal.\necho Due to there only four terminal commands\necho (echo, pause, cls and ```), the main function\necho of term scripts seems to be to tell a story,\necho a joke, or to be a manual of some kind.\necho `pause' could be employed before the \necho punchline of a joke, as so;\npause\n```\necho echo Why did the chicken cross the road?\necho pause\necho echo To get to the other side!\n```\necho to run it;\npause\necho Why did the chicken cross the road?\npause\necho To get to the other side!\necho Commands:\npause\ncls\necho Commands:\necho echo:\necho echo's text back to you\necho  \necho pause:\necho pauses execution,\necho and displays the message:\necho Press any key to continue . . .\necho  \necho cls:\necho clears the console\necho  \necho ```:\necho start and end of a code block\necho (will execute commands within)" }
			};
			string[] p = { };
			//scripts["scr"] = "echo Scripts:\nterm list\n";
			/*scripts.Add("ysnp", @"echo Gandalf - YOU SHALL NOT PASS!
echo Balrog - Why not?
pause
echo Gandalf - BECAUSE I'M IN A RUSH!");*/
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
			string[] inputs = p;
			bool isscript = false;
			string i2 = "";
			/*foreach (KeyValuePair<string, string> kvp in scripts)
			{
				Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
			}*/
			int ticks = 0;
			while (true)
			{
				
				if (!isscript)
				{
					Console.Write("ebOS:> ");
					i2 = Console.ReadLine();
					string[] f = { i2 };
					inputs = f;
				}
				isscript = false;
				
				string[] inputs2 = { i2 };

				foreach (string i1 in inputs)
				{
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
						case "```":
							if ((ticks % 2) == 0)
							{
								Console.BackgroundColor = ConsoleColor.Gray;
								Console.ForegroundColor = ConsoleColor.Black;
							}
							else
							{
								Console.BackgroundColor = ConsoleColor.Black;
								Console.ForegroundColor = ConsoleColor.White;
							}
							ticks++;
							break;
						case "cls":
							Console.Clear();
							break;
						case "pause":
							Console.Write("Press any key to continue . . . ");
							Console.ReadKey();
							Console.Write("\n");
							break;
						case "echo":
							Console.WriteLine(i1.Remove(0, 5));
							break;
						//scripts
						case "term":
							//result = input.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
							if (ilist.Length > 1)
							{
								if (ilist[1] == "new")
								{
									string text = Term.Edit();
									Console.Clear();
									if (!String.IsNullOrEmpty(text))
									{
										Console.Write("Name: ");
										string name = Console.ReadLine().ToLower();
										if (!string.IsNullOrWhiteSpace(name))
										{
											try
											{
												scripts.Add(name, text);
											}
											catch
											{
												Console.Write("Are you sure you want to overwrite? ");
												if (Console.ReadLine().ToLower() == "yes")
												{
													scripts[name] = text;
												}
											}
										}
									}

								}
								else if (ilist[1] == "run")
								{
									try
									{
										//Console.Clear();
										/*Console.WriteLine("scr == ilist[2]"+("scr" == ilist[2]));
										Console.WriteLine($"scripts.Keys.Contains(\"{ilist[2]}\") = "+scripts.Keys.Contains(ilist[2]));*/
										inputs = scripts[ilist[2]].Split("\n", StringSplitOptions.RemoveEmptyEntries);
										//Console.Clear();
										//Console.WriteLine(scripts[ilist[2]]);
										isscript = true;
									}
									catch(Exception e)
									{
										//Console.WriteLine(e.ToString());
										Console.WriteLine("Invalid! use `term list' to list term scripts");
									}
								}
								else if (ilist[1] == "type")
								{
									try
									{
										Console.WriteLine(scripts[ilist[2]].ToString());
										
									}
									catch(Exception e)
									{
										//Console.WriteLine(e.ToString());
										Console.WriteLine("Invalid! use `term list' to list term scripts");
									}
									break;
								}
								else if (ilist[1] == "list")
								{
									foreach (string x in scripts.Keys)
									{
										Console.WriteLine(x);
									}
								}
							}
							else
							{
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine("term scripts:");
								Console.ForegroundColor = ConsoleColor.Blue;
								Console.WriteLine("term new - new script");
								Console.WriteLine("term list - list scripts");
								Console.WriteLine("term run {scriptname} - run script");
								Console.WriteLine("term type {scriptname} - type contents of script");
								Console.ForegroundColor = ConsoleColor.White;
							}
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
						//games
						case "xox":
							//Console.ForegroundColor = ConsoleColor.Blue;
							Console.WriteLine("xox " + xoxver);
							//Console.ForegroundColor = ConsoleColor.White;
							XOX.Run();
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
							Console.WriteLine("\"" + i1 + "\"" + " is not a command!");
							Console.ForegroundColor = ConsoleColor.White;
							break;
					}
				}
				//Console.WriteLine(inputs.ToString());

				
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
			Console.Clear();////////////////////
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
			Console.WriteLine("terminal:");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("cls - clear terminal");
			Console.WriteLine("echo - echo text");
			Console.WriteLine("pause - pause");
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("term scripts:");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("term new - new script");
			Console.WriteLine("term list - list scripts");
			Console.WriteLine("term run {scriptname} - run script");
			Console.WriteLine("term type {scriptname} - type contents of script");
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey();
			Console.Write("\n");
			Console.Clear();////////////
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("apps:");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("calc - calculator ");
			Console.WriteLine("crypt - encrypt and decrypt messages");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey();
			Console.Write("\n");
			Console.Clear();/////////////
		}

	}
}
