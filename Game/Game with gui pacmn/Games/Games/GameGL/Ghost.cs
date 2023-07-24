using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Games.GameGL
{
    public abstract class Ghost : GameObject
    {
        GameCell CurrentCell;
        GameGrid gameGrid;
        GameDirection currentDirection;
        private bool isStopped = true;

        public bool IsStopped
        {
            get { return isStopped; }
            set { isStopped = value; }
        }
        public GameDirection CurrentDirection { get => currentDirection; set => currentDirection = value; }

        public Ghost(char displayCharacter, GameCell startCell) : base(GameObjectType.ENEMY, displayCharacter)
        {
            this.CurrentCell = startCell;
        }
        public Ghost(Image image, GameCell startCell) : base(GameObjectType.ENEMY, image)
        {
            this.CurrentCell = startCell;
        }
        public GameGrid GameGrid { get => gameGrid; set => gameGrid = value; }
        public GameCell CurrentCell1 { get => this.CurrentCell; set => this.CurrentCell = value; }

        public abstract GameCell Move();
    }
}
