using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Games.GameGL
{
    public class VerticalGhost : Ghost
    {
        private GameCell initialCell;
        public VerticalGhost(Image image, GameCell startCell) : base(image, startCell)
        {
            this.CurrentCell = startCell;
            this.initialCell = startCell;
        }
        public override GameCell Move()
        {
             GameCell currentCell = this.CurrentCell;
              GameCell nextCell = currentCell.nextCell(GameDirection.Down);
          
            this.CurrentCell = nextCell;
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL|| nextCell == currentCell)
            {
                  currentCell.setGameObject(Game.getBlankGameObject());
                  this.CurrentCell = this.initialCell;
                  nextCell = this.initialCell.nextCell(GameDirection.Up);
            }
           
              else if (currentCell != nextCell)
              {
                  currentCell.setGameObject(Game.getBlankGameObject());
              }
              return nextCell;
          
        }
    }
}
