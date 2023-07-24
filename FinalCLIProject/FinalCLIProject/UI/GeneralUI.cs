using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCLIProject.UI
{
    class GeneralUI
    {
        public static void printHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("||*************************************************************************************||");
            Console.WriteLine("||**************************ELECTION VOTING MANAGEMENT SYSTEM**************************||");
            Console.WriteLine("||*************************************************************************************||");
            Console.ResetColor();
        }
        public static string loginMenu()
        {
            string option;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Sign up: ");
            Console.WriteLine("2. Sign in: ");
            Console.WriteLine("3. Exit: ");
            Console.WriteLine("Enter your option: ");
            option = Console.ReadLine();
            Console.ResetColor();
            return option;
        }
        public static void displayMsg(string p)
        {
            Console.WriteLine(p);
        }
        public static void showChoice(string choice)
        {
            Console.WriteLine("You choosed: " + choice + "\n");
        }
        public static void printWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string asciiArt =  @"
                                 /$$      /$$           /$$                                            
                                | $$  /$ | $$          | $$                                            
                                | $$ /$$$| $$  /$$$$$$ | $$  /$$$$$$$  /$$$$$$  /$$$$$$/$$$$   /$$$$$$ 
                                | $$/$$ $$ $$ /$$__  $$| $$ /$$_____/ /$$__  $$| $$_  $$_  $$ /$$__  $$
                                | $$$$_  $$$$| $$$$$$$$| $$| $$      | $$  \ $$| $$ \ $$ \ $$| $$$$$$$$
                                | $$$/ \  $$$| $$_____/| $$| $$      | $$  | $$| $$ | $$ | $$| $$_____/
                                | $$/   \  $$|  $$$$$$$| $$|  $$$$$$$|  $$$$$$/| $$ | $$ | $$|  $$$$$$$
                                |__/     \__/ \_______/|__/ \_______/ \______/ |__/ |__/ |__/ \_______/";

            displayMsg(asciiArt);
            Console.ResetColor();
        }
        public static void header()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            string asciiArt = @"
                            _____ _           _   _                       _   _       _   _             
                           |  ___| |         | | (_)                     | | | |     | | (_)            
                           | |__ | | ___  ___| |_ _  ___  _ __           | | | | ___ | |_ _ _ __   __ _ 
                           |  __|| |/ _ \/ __| __| |/ _ \| '_ \          | | | |/ _ \| __| | '_ \ / _` |
                           | |___| |  __/ (__| |_| | (_) | | | |         \ \_/ / (_) | |_| | | | | (_| |
                           \____/|_|\___|\___|\__|_|\___/|_| |_|          \___/ \___/ \__|_|_| |_|\__, |
                                                                                                   __/ |
                                                                                                  |___/ 
                                                 _____           _                                   
                                                /  ___|         | |                                  
                                                \ `--. _   _ ___| |_ ___ _ __ ___                    
                                                 `--. \ | | / __| __/ _ \ '_ ` _ \                   
                                                /\__/ / |_| \__ \ ||  __/ | | | | |                  
                                                \____/ \__, |___/\__\___|_| |_| |_|                  
                                                        __/ |                                        
                                                       |___/                               ";
            displayMsg(asciiArt);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n                      >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("                      <>    The Ignorance of one voter in a democracy impairs the security of all            <> ");
            Console.WriteLine("                      _________________________________________________________________________________________\n\n");
            Console.ResetColor();
        }
        public static void subMenu(string submenu)
        {
            string message = "Main Menu > " + submenu;
            Console.WriteLine( message );
            Console.WriteLine("_____________________________________________________________________________________\n" );
        }
    }
}
