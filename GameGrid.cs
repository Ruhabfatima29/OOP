using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanOOP
{
    class GameGrid
    {
        public GameCell[,] GameCells; 
        public int rows;
        public int columns;
        public GameGrid(string fileName, int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            GameCells = new GameCell[rows,columns];
            loadGrid(fileName);
        }
        private void loadGrid(string filename)
        {
            
            if(File.Exists(filename))
            {
                StreamReader file = new StreamReader(filename);
                string record;
                for(int x=0; x<this.rows; x++)
                {
                record = file.ReadLine();
                for (int y=0; y<this.columns; y++)
                {
                        GameCell cell = new GameCell(x, y, this);
                        Char character = record[y];
                        GameObjectType type = GameObject.GetGameObjectType(character);
                        GameObject obj = new GameObject(type, character);
                        cell.currentGameObject = obj;
                        GameCells[x,y] = cell;
                }
                }
                file.Close();
            }
        }
        public GameCell getCell(int x, int y)
        {
            return GameCells[x,y];
        }
    }
}
