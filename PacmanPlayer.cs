using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanOOP
{
    class PacmanPlayer:GameObject
    {
        public PacmanPlayer(char displayCharacter, GameCell startCell): base(GameObjectType.PLAYER,displayCharacter)
        {
            this.currentCell = startCell;
        }
        public GameCell move(GameDirection direction)
        {
            return this.currentCell.nextCell(direction);
        }
    }
}
