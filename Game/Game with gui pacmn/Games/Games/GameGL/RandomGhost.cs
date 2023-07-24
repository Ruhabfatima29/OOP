using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Games.GameGL
{
    public class RandomGhost : Ghost
    {
       
        public RandomGhost(Image image, GameCell startCell) : base(image, startCell)
        {
            this.CurrentCell = startCell;
        }
        public int ghostDirection()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }
        public override GameCell Move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell;
            int value = ghostDirection();

            if (value == 0)
            {
                nextCell = currentCell.nextCell(GameDirection.Left);
            }
            else if (value == 1)
            {
                nextCell = currentCell.nextCell(GameDirection.Right);
            }
            else if (value == 2)
            {
                nextCell = currentCell.nextCell(GameDirection.Up);
            }
            else if (value == 3)
            {
                nextCell = currentCell.nextCell(GameDirection.Down);
            }

            this.CurrentCell = nextCell;

            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL || nextCell == currentCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());
            }
            else if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());
            }
            return nextCell;
        }
    }
}
