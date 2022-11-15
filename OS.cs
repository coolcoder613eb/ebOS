using System;
using System.IO;

//in BeforeRun: Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
public class Program
{
    private const string ver = "1.0.0";
    //Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
    public static void Main()
	{
		Program program = new Program();
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
		program.about();
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
                    program.about();
					break;
				case "ver":
					program.about();
					break;
				case "help":
					program.help();
					break;
				case "dir":
					if (!(ilist.Length > 1))
                    {
						program.getdir(ilist[1])
                    }
                    else
                    {
						program.getdir()
                    }
					program.about();
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
					Console.WriteLine(i+" is not a command!");
					break;

			}
			
		}

	}
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
}