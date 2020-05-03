using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace Pigeon_OS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("@@@@@@@   @@@   @@@@@@@@  @@@@@@@@   @@@@@@   @@@  @@@   @@@@@@    @@@@@@ ");
            Console.WriteLine("@@@@@@@@  @@@  @@@@@@@@@  @@@@@@@@  @@@@@@@@  @@@@ @@@  @@@@@@@@  @@@@@@@ ");
            Console.WriteLine("@@!  @@@  @@!  !@@        @@!       @@!  @@@  @@!@!@@@  @@!  @@@  !@@     ");
            Console.WriteLine("!@!  @!@  !@!  !@!        !@!       !@!  @!@  !@!!@!@!  !@!  @!@  !@!     ");
            Console.WriteLine("@!@@!@!   !!@  !@! @!@!@  @!!!:!    @!@  !@!  @!@ !!@!  @!@  !@!  !!@@!!  ");
            Console.WriteLine("!!@!!!    !!!  !!! !!@!!  !!!!!:    !@!  !!!  !@!  !!!  !@!  !!!   !!@!!! ");
            Console.WriteLine("!!:       !!:  :!!   !!:  !!:       !!:  !!!  !!:  !!!  !!:  !!!       !:!");
            Console.WriteLine(":!:       :!:  :!:   !::  :!:       :!:  !:!  :!:  !:!  :!:  !:!      !:! ");
            Console.WriteLine(" ::        ::   ::: ::::   :: ::::  ::::: ::   ::   ::  ::::: ::  :::: :: ");
            Console.WriteLine(" :        :     :: :: :   : :: ::    : :  :   ::    :    : :  :   :: : :  ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected override void Run()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("PigeonOS: ");
            var input = Console.ReadLine();
            if (input == "help")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("hello");
                Console.WriteLine("shutdown");
                Console.WriteLine("create");
                Console.WriteLine("delete");
                Console.WriteLine("ls");
                Console.WriteLine("write");
                Console.WriteLine("read");
                Console.WriteLine("echo");
            }
            if (input == "hello")
            {
                Console.WriteLine("Hello there, welcome to PigeonOS");
            }
            else if (input == "shutdown")
            {
                Sys.Power.Shutdown();
            }
            else if (input.Contains("create "))
            {
                var filetomake = input.Remove(0, 7);
                var dir = Directory.GetCurrentDirectory();
                File.Create(dir + "\\" + filetomake);
            }
            else if (input.Contains("delete "))
            {
                var filetomake = input.Remove(0, 7);
                var dir = Directory.GetCurrentDirectory();
                File.Delete(dir + "\\" + filetomake);
            }
            else if (input == "ls")
            {
                var dir = Directory.GetCurrentDirectory();
                foreach (var directory in Directory.GetDirectories(dir))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(directory);
                }
                foreach (var file in Directory.GetFiles(dir))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(file);
                }
            }
            else if (input.Contains("write "))
            {
                var filetowriteto = input.Remove(0, 6);
                var dir = Directory.GetCurrentDirectory();
                var txtfile = dir + "\\" + filetowriteto;
                using (var tw = new StreamWriter(txtfile, true))
                {
                    Console.WriteLine("Text to write to file: ");
                    var ttw = Console.ReadLine();
                    tw.WriteLine(ttw);
                    tw.Close();
                }
            }
            else if (input.Contains("read "))
            {
                var filetomake = input.Remove(0, 5);
                var dir = Directory.GetCurrentDirectory();
                Console.WriteLine(File.ReadAllText(dir + "\\" + filetomake));
            }
            else if (input.Contains("echo "))
            {
                Console.WriteLine(input.Remove(0, 5));
            }
            else
            {
                Console.WriteLine("Command not recognized: " + input);
            }
        }
    }
}
