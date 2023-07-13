using EZInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PacmanOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            GameGrid grid = new GameGrid("E:\\Final Projects\\PacmanOOP\\PacmanOOP\\maze.txt", 24, 71);
            GameCell start = new GameCell(12, 22, grid);
            PacmanPlayer pacman = new PacmanPlayer('P', start);
            printMaze(grid);
            printGameObject(pacman);
            bool gameRunning = true;
            while(gameRunning)
            {
                if(Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveGameObject(pacman,GameDirection.UP);
                }
                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveGameObject(pacman, GameDirection.DOWN);
                }
                else if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveGameObject(pacman, GameDirection.LEFT);
                }
                else if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveGameObject(pacman, GameDirection.Right);
                }
                Thread.Sleep(200);

            }
            Console.ReadLine();
        }
        static void clearGameCellContent(GameCell gameCell, GameObject newGameObject)
        {
            gameCell.currentGameObject = newGameObject;
            Console.SetCursorPosition(gameCell.y, gameCell.x);
            Console.Write(newGameObject.displayChar);

        }
        static void printGameObject(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.currentCell.y, gameObject.currentCell.x);
            Console.Write(gameObject.displayChar);

        }

        static void moveGameObject(GameObject gameObject, GameDirection direction)
        {
            GameCell nextCell = gameObject.currentCell.nextCell(direction);
            if (nextCell != null)
            {
                GameObject newGO = new GameObject(GameObjectType.NONE, ' ');
                GameCell currentCell = gameObject.currentCell;
                clearGameCellContent(currentCell, newGO);
                gameObject.currentCell = nextCell;
                printGameObject(gameObject);
            }
        }

        static void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.rows; x++)
            {
                for (int y = 0; y < grid.columns; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    printCell(cell);
                }

            }
        }

        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.y, cell.x);
            Console.Write(cell.currentGameObject.displayChar);
        }
    }
}
