using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Games.GameGL
{
    public class GamePacManPlayer : GameObject
    {
        public bool IsStopped { get; set; }
        public GamePacManPlayer(Image image, GameCell startCell) : base(GameObjectType.PLAYER, image)
        {
            this.CurrentCell = startCell;
        }
        public void move(GameDirection direction)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);

            if (Collision.CheckCollision(nextCell))
            {
                if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
                {
                    Form1.Score += 1;
                    nextCell.setGameObject(Game.getBlankGameObject());
                }
                if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
                {
                    Form1.DecreaseHealth();
                }
            }
            this.CurrentCell = nextCell;
            currentCell.setGameObject(Game.getBlankGameObject());
        }
       
    }
}
