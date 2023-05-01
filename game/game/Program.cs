using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;
using game.Mickey.BL;
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
            Meckey mick = new Meckey();
            mick.xMic = 3;
            mick.yMic = 10;          
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
            printMickey(mick);
            bool gameRunning = true;
            while (gameRunning == true)
            {
               /* printScore(score);
                printMickeyHealth(mickeyHealth);
                printMickeyLife(mickeyLife);
                printKeys(key);*/
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveMickeyLeft(maze, mick,ref mickeyHealth,ref key);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveMickeyRight(maze, mick, ref mickeyHealth, ref key);
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveMickeyUp(maze, mick,ref mickeyHealth,ref key);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveMickeyDown(maze, mick , ref mickeyHealth, ref key);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    createBullet( mick , mickBulletX, mickBulletY, isBulletActive,ref bulletCount);
                }
                if (stinkyTimer == 6)
                {
                    moveStinky(ref stinkyX,ref stinkyY,ref stinkyDirection, maze);
                    stinkyTimer = 0;
                }
           
               // createStinkyBullet(stinkyX, stinkyY, isStinkyBulletActive, stinkyBulletX, stinkyBulletY, stinkyBulletCount);
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
               /* //if (key >= 12)
                {
                    Console.SetCursorPosition(120, 20);
                    Console.WriteLine( "You Won");
                    Thread.Sleep(200);
                    gameRunning = false;
                    Console.Read();
                }*/
                //moveStinkyBullet(isStinkyBulletActive, stinkyBulletX, stinkyBulletY, stinkyBulletCount);
                stinkyTimer++;
                
                moveBullet(mickBulletX, mickBulletY, isBulletActive,ref bulletCount, maze);
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
        static void printMickey( Meckey mick)
        {
            //char body = (char)178;
            int x = mick.xMic;
            int y = mick.yMic;
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
        
        static void moveMickeyUp(char[,] maze,Meckey mick, ref int mickeyHealth, ref int key)
        {
            char next = maze[mick.yMic , mick.xMic];
            char next1 = maze[mick.yMic, mick.xMic + 1];
            char next2 = maze[mick.yMic, mick.xMic + 2];
            char next3 = maze[mick.yMic, mick.xMic + 3];
            char next4 = maze[mick.yMic, mick.xMic + 4];
            char next5 = maze[mick.yMic, mick.xMic + 5];
            char next6 = maze[mick.yMic, mick.xMic + 6];

            if ((next == ' ' || next == 'k' || next == '%') && (next1 == ' ' || next1 == 'k' || next1 == '%') && (next2 == ' ' || next2 == 'k' || next2 == '%') && (next3 == ' ' || next3 == 'k' || next3 == '%') && (next4 == ' ' || next4 == 'k' || next4 == '%') && (next5 == ' ' || next5 == 'k' || next5 == '%') && (next6 == ' ' || next6 == 'k' || next6 == '%'))
            {
                eraseMickey(mick);
                mick.yMic--;
                printMickey(mick);
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

        static void eraseMickey(Meckey mick)
        {
            int x = mick.xMic;
            int y = mick.yMic;
            for (int row = 0; row < 5; row++)
            {
                Console.SetCursorPosition(x,y);
                for (int col = 0; col < 7; col++)
                {
                    Console.Write(' ');
                }
               // Console.WriteLine();
                y++;

            }
        }
        static void moveMickeyDown(char[,] maze, Meckey mick, ref int mickeyHealth, ref int key)
        {
            char next  = maze[mick.yMic + 6, mick.xMic];
            char next1 = maze[mick.yMic + 6, mick.xMic + 1];
            char next2 = maze[mick.yMic + 6, mick.xMic + 2];
            char next3 = maze[mick.yMic + 6, mick.xMic + 3];
            char next4 = maze[mick.yMic + 6, mick.xMic + 4];
            char next5 = maze[mick.yMic + 6, mick.xMic + 5];
            char next6 = maze[mick.yMic + 6, mick.xMic + 6];

            if ((next == ' ' || next == 'k' || next == '%') && (next1 == ' ' || next1 == 'k' || next1 == '%') && (next2 == ' ' || next2 == 'k' || next2 == '%') && (next3 == ' ' || next3 == 'k' || next3 == '%') && (next4 == ' ' || next4 == 'k' || next4 == '%') && (next5 == ' ' || next5 == 'k' || next5 == '%') && (next6 == ' ' || next6 == 'k' || next6 == '%'))
            {
                //Console.SetCursorPosition(mickeyY, mickeyX);
                eraseMickey(mick);
                mick.yMic = mick.yMic + 1;
                // Console.SetCursorPosition(mickeyY, mickeyX);
                printMickey(mick);
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
       
        static void moveMickeyLeft(char[,] maze,Meckey mick,ref int mickeyHealth,ref int key)
        {

            char next = maze[mick.yMic, mick.xMic - 1 ];
            char next1 = maze[mick.yMic + 1, mick.xMic - 1];
            char next2 = maze[mick.yMic + 2, mick.xMic - 1];
            char next3 = maze[mick.yMic + 3, mick.xMic - 1];
            char next4 = maze[mick.yMic + 4, mick.xMic - 1];
           

            if ((next == ' ' || next == 'k' || next == '%') && (next1 == ' ' || next1 == 'k' || next1 == '%') && (next2 == ' ' || next2 == 'k' || next2 == '%') && (next3 == ' ' || next3 == 'k' || next3 == '%') && (next4 == ' ' || next4 == 'k' || next4 == '%'))
            {
               //Console.SetCursorPosition(mickeyY, mickeyX);
                eraseMickey(mick);
                mick.xMic--;
               //Console.SetCursorPosition(mickeyY, mickeyX);
                printMickey(mick);
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
        static void moveMickeyRight(char[,] maze,Meckey mick,ref int mickeyHealth,ref int key)
        {
            char next = maze[mick.yMic, mick.xMic + 7];
            char next1 = maze[mick.yMic + 1, mick.xMic + 7];
            char next2 = maze[mick.yMic + 2, mick.xMic + 7];
            char next3 = maze[mick.yMic + 3, mick.xMic + 7];
            char next4 = maze[mick.yMic + 4, mick.xMic + 7];
            if ((next == ' ' || next == 'k' || next == '%') && (next1 == ' ' || next1 == 'k' || next1 == '%') && (next2 == ' ' || next2 == 'k' || next2 == '%') && (next3 == ' ' || next3 == 'k' || next3 == '%') && (next4 == ' ' || next4 == 'k' || next4 == '%'))
            {
                //Console.SetCursorPosition(mickeyY, mickeyX);
                eraseMickey(mick);
                mick.xMic++;
               // Console.SetCursorPosition(mickeyY, mickeyX);
                printMickey(mick);
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
            char head = '\u0001';
            char body = '\u2588';
            char arrow = '\u2192';
            char b = '\u00B9';
            char c = '\u2502';
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
        static void moveStinky(ref int stinkyX,ref int stinkyY,ref string stinkyDirection, char[,] maze)
        {
            if (stinkyDirection == "Up")
            {
                char next = maze[ stinkyY , stinkyX];
                char next1 = maze[ stinkyY  , stinkyX + 1];
                char next2 = maze[ stinkyY , stinkyX + 2];
                if (next == ' ' && next1 == ' ' && next2 == ' ')
                {
                    eraseStinky(ref stinkyX, ref stinkyY);
                    stinkyY--;
                    printStinky(ref stinkyX,ref stinkyY);
                }
                if (next == '$')
                {
                    stinkyDirection = "Down";
                }
            }
            if (stinkyDirection == "Down")
            {
                char next = maze[stinkyY + 4, stinkyX];
                char next1 = maze[stinkyY + 4, stinkyX + 1];
                char next2 = maze[stinkyY + 4, stinkyX + 2];
                char next3 = maze[stinkyY + 4, stinkyX + 3];
                if (next == ' ' && next1 == ' ' && next2 == ' ' && next3 == ' ')
                {
                    eraseStinky(ref stinkyX, ref stinkyY);
                    stinkyY++;
                    printStinky(ref stinkyX, ref stinkyY);
                }
                if (next == '$')
                {
                    stinkyDirection = "Up";
                }
            }

        }
        static void moveBullet(int[] mickBulletX, int[] mickBulletY, bool[] isBulletActive, ref int bulletCount, char[,] maze)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                if (isBulletActive[i] == true)
                {
                    char next = maze[ mickBulletY[i], mickBulletX[i] + 1];
                    if (next != ' ')
                    {
                        eraseBullet(mickBulletX[i], mickBulletY[i]);
                        makeBulletInactive(i, isBulletActive);
                    }
                    else
                    {
                        eraseBullet(mickBulletX[i], mickBulletY[i]);
                        mickBulletX[i]++;
                        printBullet(mickBulletX[i], mickBulletY[i]);
                    }
                }
            }
        }
        static void eraseBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        static void makeBulletInactive(int index, bool[] isBulletActive)
        {
            isBulletActive[index] = false;
        }
        static void printBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("-");
        }
        static void createBullet(Meckey mick, int[] mickBulletX, int[] mickBulletY, bool[] isBulletActive,ref int bulletCount)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            mickBulletX[bulletCount] = mick.xMic + 9;
            mickBulletY[bulletCount] = mick.yMic + 2;
            isBulletActive[bulletCount] = true;
            Console.SetCursorPosition(mick.xMic + 9, mick.yMic + 2);
            Console.Write("-");
            bulletCount++;
        }
    }
}
