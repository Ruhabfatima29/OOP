using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanOOP
{
    class GameCell
    {
        public int x;
        public int y;
        public GameObject currentGameObject;
        public GameGrid gameGrid;
        public GameCell(int x, int y, GameGrid grid)
        {
            this.x = x;
            this.y = y;
            this.gameGrid = grid;
        }
        public int X { get => x; set => x = value; }

        public int Y { get => y; set => y = value; }
        public GameObject CurrentGameObject { get => currentGameObject; set => currentGameObject = value; }
        public GameCell nextCell(GameDirection direction)
        {
            if(direction == GameDirection.LEFT)
            {
                if(y>0)
                {
                    GameCell next = gameGrid.getCell(x, y - 1);
                    if(next.currentGameObject.gameObjectType  != GameObjectType.WALL)
                    {
                        return next;
                    }
                }
            }
            else if (direction == GameDirection.Right)
            {
                if(y<gameGrid.columns-1)
                {
                    GameCell next = gameGrid.getCell(x, y + 1);
                    if(next.currentGameObject.gameObjectType != GameObjectType.WALL)
                    {
                        return next;
                    }
                }
            }
            else if (direction == GameDirection.UP)
            {
                if (x>0)
                {
                    GameCell next = gameGrid.getCell(x-1, y );
                    if (next.currentGameObject.gameObjectType != GameObjectType.WALL)
                    {
                        return next;
                    }
                }
            }
            else if (direction == GameDirection.DOWN)
            {
                if (x < gameGrid.rows - 1)
                {
                    GameCell next = gameGrid.getCell(x+1, y);
                    if (next.currentGameObject.gameObjectType != GameObjectType.WALL)
                    {
                        return next;
                    }
                }
            }
            return this;
        }

    }
}
