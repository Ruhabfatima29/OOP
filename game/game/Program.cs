using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;
namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            string option = "0";
            while (option != "3")
            {
                Console.Clear();
                option = logo();
                if (option == "1")
                {
                    string choice = "0";
                    while (choice != "3")
                    {
                        Console.Clear();
                       // header();
                        choice = headerMenu();
                        if (choice == "1")
                        {
                            // print keys functionality
                           // keysFunctions();
                        }
                        if (choice == "2")
                        {
                            // print instructions menu]
                           // instructMenu();
                        }
                        Thread.Sleep(100);
                        Console.Read();
                    }
                }
                else if (option == "2")
                {
                    // Start game
                    Console.Clear();
                    // mickeyHeader();
                    Console.SetCursorPosition(55, 25);
                    Console.Write("Loading");
                    int num = 0;
                    while (num != 7)
                    {
                        Console.Write(".");
                        Thread.Sleep(1000);
                        num++;
                    }
                    game();
                }
                Thread.Sleep(100);
                Console.ReadKey();
            }
        }
        static string logo()
        {

            //header();
            string option;
            Console.WriteLine("1.Display menu ");
            Console.WriteLine("2.Start Game " );
            Console.WriteLine("3.Exit ");
            Console.WriteLine();
            Console.WriteLine("Enter your choice: ");
            option= Console.ReadLine();
            return option;
        }
        static string headerMenu()
        {
           
            string choice;
            Console.WriteLine("________________________________________________________________________________________________________________" );

            Console.WriteLine("1. Keys Funtions " );
            Console.WriteLine("2. Game Instructions " );
            Console.WriteLine("3. Exit " );
            Console.WriteLine("Enter your choice : ");
            choice= Console.ReadLine();
            return choice;
        }
        static void game()
        {
            int mickeyX = 3;
            int mickeyY = 10;
           
            int stinkyTimer = 1;
            int bulletCount = 0;
            int[] mickBulletX= new int[2000];
            int[] mickBulletY= new int[2000];
            int mickeyHealth = 50;
            int stinkyX = 90;
            int stinkyY = 20;
            bool[] isStinkyBulletActive= new bool[2000];
            int mickeyLife = 3;
            bool[] isBulletActive= new bool[2000]; 
            int[] stinkyBulletX = new int[2000];
            int[] stinkyBulletY= new int[2000];
            int stinkyBulletCount = 0;
            int score = 0;
            int key = 0;

            char[,] maze = new char [30, 115];



            string stinkyDirection = "Down";
            Console.Clear();
            loadDataFromMazeFile(maze);
            printMaze(maze);
            printStinky(ref stinkyX,ref stinkyY);
            printMickey(ref mickeyX,ref mickeyY);
            bool gameRunning = true;
            while (gameRunning == true)
            {
               /* printScore(score);
                printMickeyHealth(mickeyHealth);
                printMickeyLife(mickeyLife);
                printKeys(key);*/
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveMickeyLeft(maze, ref mickeyX,ref mickeyY,ref mickeyHealth,ref key);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveMickeyRight(maze, ref mickeyX, ref mickeyY, ref mickeyHealth, ref key);
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveMickeyUp(maze, ref mickeyX, ref mickeyY,ref mickeyHealth,ref key);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveMickeyDown(maze, ref mickeyX, ref mickeyY, ref mickeyHealth, ref key);
                }
                /*if (GetAsyncKeyState(VK_SPACE))
                {
                    createBullet(mickeyX, mickeyY, mickBulletX, mickBulletY, isBulletActive, bulletCount);
                }*/
              /*  if (stinkyTimer == 6)
                {
                    moveStinky(stinkyX, stinkyY, stinkyDirection);
                    stinkyTimer = 0;
                }
                if (theifTimer == 5)
                {
                    createTheifBullet(theifX, theifY, theifBulletX, theifBulletY, isTheifBulletActive, theifBulletCount);
                    theifTimer = 0;
                }
                createStinkyBullet(stinkyX, stinkyY, isStinkyBulletActive, stinkyBulletX, stinkyBulletY, stinkyBulletCount);
                createBoombieBullet(boombieBulletX, boombieBulletY, isBoombieBulletActive, boomieBulletCount, boombieX, boombieY);*/
                if (mickeyHealth <= 0 && mickeyLife > 0)
                {
                    mickeyHealth = 50;
                    mickeyLife--;
                }
                if (mickeyLife == 0 && mickeyHealth <= 0)
                {
                    gameRunning = false;
                    mickeyLife = 3;
                    mickeyHealth = 50;
                }
                /* if (GetAsyncKeyState(VK_ESCAPE))
                 {
                     storeDataToResumeFile();
                     gameRunning = false;
                 }*/
                if (key >= 12)
                {
                    Console.SetCursorPosition(120, 20);
                    Console.WriteLine( "You Won");
                    Thread.Sleep(200);
                    gameRunning = false;
                    Console.Read();
                }
                //moveStinkyBullet(isStinkyBulletActive, stinkyBulletX, stinkyBulletY, stinkyBulletCount);
                stinkyTimer++;
                
               // moveBullet(mickBulletX, mickBulletY, isBulletActive, bulletCount);
                //StinkyBulletDetectionwithMickey(mickeyX, mickeyY, mickeyHealth, isStinkyBulletActive, stinkyBulletX, stinkyBulletY, stinkyBulletCount);
                //mickBulletDetectionwithEnemies(boombieX, boombieY, mickBulletX, mickBulletY, isBulletActive, bulletCount, stinkyX, stinkyY, score, theifX, theifY);
                Thread.Sleep(100);
            }

        }
        static void loadDataFromMazeFile(char[,] maze)
        {
            StreamReader fp = new StreamReader("E:\\OOP\\game\\maze.txt");
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < maze.GetLength(1); x++)
                {
                    maze[row, x] = record[x];
                }
                row++;
            }
            fp.Close();
        }
        static void printMaze(char[,] maze)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
        }
        static void printMickey( ref int mickeyX,  ref int mickeyY)
        {
            //char body = (char)178;
            int x = mickeyX;
            int y = mickeyY;
            char body = '\u2588';
            char[,] mickey=new char [5,7]  {
                { '(', ')', '_', '_', '_', '(', ')'},
                { '(', 'o', ' ', '^', ' ', 'o', ')'},
                { ' ', '(', ']', body, '[', ')', '}'},
                { ' ', ' ', body, body, body, ' ', ' '},
                { ' ', ' ', '@', ' ', '@',' ',' '}
                };
            for (int row = 0; row < 5; row++)
            {
                Console.SetCursorPosition( x, y + row);
                for (int col = 0; col < 7; col++)
                {
                    
                    Console.Write( mickey[row,col]);
                }
                Console.WriteLine();
            }
        }
        static void moveMickeyUp(char[,] maze, ref int mickeyX, ref int mickeyY, ref int mickeyHealth, ref int key)
        {
            // checks all the coordinates in up direction
           // char next = maze[mickeyY - 1, mickeyX];
            char next1 = maze[mickeyY - 1, mickeyX + 1];
            char next2 = maze[mickeyY - 1,mickeyX + 2];
            char next3 = maze[mickeyY - 1,mickeyX + 3];
            char next4 = maze[mickeyY - 1,mickeyX + 4];
            char next5 = maze[mickeyY - 1,mickeyX + 5];
            char next6 = maze[mickeyY - 1,mickeyX + 6];

            if (/*(next == ' ' || next == 'k' || next == '%')*/ /*&&*/ (next1 == ' ' || next1 == 'k' || next1 == '%') && (next2 == ' ' || next2 == 'k' || next2 == '%') && (next3 == ' ' || next3 == 'k' || next3 == '%') && (next4 == ' ' || next4 == 'k' || next4 == '%') && (next5 == ' ' || next5 == 'k' || next5 == '%') && (next6 == ' ' || next6 == 'k' || next6 == '%'))
            {
              /*  next = ' ';
                next1 = ' ';
                next2 = ' ';
                next3 = ' ';
                next4 = ' ';
                next5 = ' ';  
                next6 = ' ';*/
               // Console.SetCursorPosition(mickeyY, mickeyX);
                eraseMickey(ref mickeyX, ref mickeyY);
                mickeyY = mickeyY - 1;
               // Console.SetCursorPosition(mickeyY, mickeyX);
                printMickey(ref mickeyX,ref mickeyY);
            }
            if (/*next == 'k' ||*/ next1 == 'k' || next2 == 'k' || next3 == 'k' || next4 == 'k'|| next5 == 'k' || next6 == 'k')
            {
                key = key + 1;
            }
            if (/*next == '%' ||*/ next1 == '%' || next2 == '%' || next3 == '%' || next4 == '%')
            {
                mickeyHealth = mickeyHealth + 10;
            }
        }
        static void eraseMickey(ref int mickeyX,ref int mickeyY)
        {
            int x = mickeyX;
            int y = mickeyY;
            for (int row = 0; row < 5; row++)
            {
                Console.SetCursorPosition(x, y);
                for (int col = 0; col < 7; col++)
                {
                    Console.Write(' ');
                }
               // Console.WriteLine();
                y++;

            }
        }
        static void moveMickeyDown(char[,] maze ,ref int mickeyX,ref int mickeyY,ref int mickeyHealth,ref int key)
        {
            char next =  maze[ mickeyY + 5, mickeyX];
            char next1 = maze[ mickeyY + 5, mickeyX + 1];
            char next2 = maze[ mickeyY + 5, mickeyX + 2];
            char next3 = maze[ mickeyY + 5, mickeyX + 3];
            char next4 = maze[ mickeyY + 5, mickeyX + 4];
            char next5 = maze[ mickeyY + 5, mickeyX + 5];
            char next6 = maze[ mickeyY + 5, mickeyX + 6];

            if ((next == ' ' || next == 'k' || next == '%') && (next1 == ' ' || next1 == 'k' || next1 == '%') && (next2 == ' ' || next2 == 'k' || next2 == '%') && (next3 == ' ' || next3 == 'k' || next3 == '%') && (next4 == ' ' || next4 == 'k' || next4 == '%') && (next5 == ' ' || next5 == 'k' || next5 == '%') && (next6 == ' ' || next6 == 'k' || next6 == '%'))
            {
                //Console.SetCursorPosition(mickeyY, mickeyX);
                eraseMickey(ref mickeyX,ref mickeyY);
                mickeyY = mickeyY + 1;
               // Console.SetCursorPosition(mickeyY, mickeyX);
                printMickey(ref mickeyX,ref mickeyY);
            }
            if (next == 'k' || next1 == 'k' || next2 == 'k' || next3 == 'k' || next4 == 'k')
            {
                key = key + 1;
            }
            if (next == '%' || next1 == '%' || next2 == '%' || next3 == '%' || next4 == '%')
            {
                mickeyHealth = mickeyHealth + 10;
            }
        }
        static void moveMickeyLeft(char[,] maze,ref int mickeyX, ref int mickeyY,ref int mickeyHealth,ref int key)
        {

            char next = maze[mickeyY,mickeyX - 1 ];
            char next1 = maze[mickeyY + 1, mickeyX - 1];
            char next2 = maze[mickeyY + 2, mickeyX - 1];
            char next3 = maze[mickeyY + 3, mickeyX - 1];
            char next4 = maze[mickeyY + 4, mickeyX - 1];
           

            if ((next == ' ' || next == 'k' || next == '%') && (next1 == ' ' || next1 == 'k' || next1 == '%') && (next2 == ' ' || next2 == 'k' || next2 == '%') && (next3 == ' ' || next3 == 'k' || next3 == '%') && (next4 == ' ' || next4 == 'k' || next4 == '%'))
            {
               //Console.SetCursorPosition(mickeyY, mickeyX);
                eraseMickey(ref mickeyX,ref mickeyY);
                mickeyX = mickeyX - 1;
               //Console.SetCursorPosition(mickeyY, mickeyX);
                printMickey(ref mickeyX,ref mickeyY);
            }
            if (next == 'k' || next1 == 'k' || next2 == 'k' || next3 == 'k' || next4 == 'k')
            {
                key = key + 1;
            }
            if (next == '%' || next1 == '%' || next2 == '%' || next3 == '%' || next4 == '%')
            {
                mickeyHealth = mickeyHealth + 10;
            }
        }
        static void moveMickeyRight(char[,] maze,ref int mickeyX,ref int mickeyY,ref int mickeyHealth,ref int key)
        {
            char next = maze[ mickeyY, mickeyX + 7];
            char next1 = maze[mickeyY + 1,mickeyX + 7];
            char next2 = maze[ mickeyY + 2, mickeyX + 7];
            char next3 = maze[ mickeyY + 3, mickeyX + 7];
            char next4 = maze[ mickeyY + 4, mickeyX + 7];
            /* char next = maze[mickeyX, mickeyY + 6];
             char next1 = maze[mickeyX + 1, mickeyY + 6];
             char next2 = maze[mickeyX + 2, mickeyY + 6];
             char next3 = maze[mickeyX + 3, mickeyY + 6];
             char next4 = maze[mickeyX + 4, mickeyY + 6];
             char next5 = maze[mickeyX + 5, mickeyY + 6];
             char next6 = maze[mickeyX + 6, mickeyY + 6];*/
            if ((next == ' ' || next == 'k' || next == '%') && (next1 == ' ' || next1 == 'k' || next1 == '%') && (next2 == ' ' || next2 == 'k' || next2 == '%') && (next3 == ' ' || next3 == 'k' || next3 == '%') && (next4 == ' ' || next4 == 'k' || next4 == '%'))
            {
                //Console.SetCursorPosition(mickeyY, mickeyX);
                eraseMickey(ref mickeyX,ref mickeyY);
                mickeyX = mickeyX + 1;
               // Console.SetCursorPosition(mickeyY, mickeyX);
                printMickey(ref mickeyX,ref mickeyY);
            }
            if (next == 'k' || next1 == 'k' || next2 == 'k' || next3 == 'k' || next4 == 'k')
            {
                key = key + 1;
            }
            if (next == '%' || next1 == '%' || next2 == '%' || next3 == '%' || next4 == '%')
            {
                mickeyHealth = mickeyHealth + 10;
            }
        }
        static void eraseStinky(ref int stinkyX, ref int stinkyY)
        {
            for (int row = 0; row < 3; row++)
            {
               Console.SetCursorPosition(stinkyX, stinkyY + row);
                for (int col = 0; col < 6; col++)
                {
                    Console.Write( " ");
                }
            }
        }
        static void printStinky(ref int stinkyX,ref int stinkyY)
        {
            char head = (char)1;
            char body = (char)178;
            char arrow = (char)174;
            char b = (char)185;
            char c = (char)186;
            char[,] stinky = new char [3,6]{
            { ' ', ' ', head, ' ', ' ', ' '},
            { arrow, b, body, body, '>',' '},
            { ' ', ' ', c, c, ' ', ' '}
            };
            for (int row = 0; row < 3; row++)
            {
                Console.SetCursorPosition(stinkyX, stinkyY + row);
                for (int col = 0; col < 6; col++)
                {
                    Console.Write(stinky[row,col]);
                }
            }
        }
    }
}
