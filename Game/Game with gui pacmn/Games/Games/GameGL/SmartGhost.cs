using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Games.GameGL
{
    public class SmartGhost : Ghost
    {

        public SmartGhost(Image image, GameCell startCell) : base(image, startCell)
        {
            this.CurrentCell = startCell;
        }
        public double calculateDistance(GameCell startCell)
        {
            //  GameCell pacman = new GameCell(X , Y , grid)
            GameCell pacman = new GameCell();
            return Math.Sqrt(Math.Pow((pacman.X - startCell.X), 2) + Math.Pow((pacman.Y - startCell.Y), 2));
        }
        public override GameCell Move()
        {
            GameDirection currentDirection = CurrentDirection;
            GameCell currentCell = this.CurrentCell;
            double[] distance = new double[4] { 1000000, 1000000, 1000000, 1000000 };

            if (currentCell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                GameCell nextCell = currentCell.nextCell(GameDirection.Left);
                distance[0] = calculateDistance(nextCell);
            }

            if (currentCell.CurrentGameObject.GameObjectType != GameObjectType.WALL )
            {
                GameCell nextCell = currentCell.nextCell(GameDirection.Right);
                distance[1] = calculateDistance(nextCell);
            }

            if (currentCell.CurrentGameObject.GameObjectType != GameObjectType.WALL )
            {
                GameCell nextCell = currentCell.nextCell(GameDirection.Down);
                distance[2] = calculateDistance(nextCell);
            }

            if (currentCell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                GameCell nextCell = currentCell.nextCell(GameDirection.Up);
                distance[3] = calculateDistance(nextCell);
            }

            int minDistanceIndex = Array.IndexOf(distance, distance.Min());
            currentDirection = (GameDirection)minDistanceIndex;
            GameCell nextMoveCell = currentCell.nextCell(currentDirection);
            
            if (nextMoveCell != currentCell && nextMoveCell.CurrentGameObject.GameObjectType != GameObjectType.WALL )
            {
                currentCell.setGameObject(Game.getBlankGameObject());
                this.CurrentCell = nextMoveCell;
            }

            return nextMoveCell;
        }
    }
}
