using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Games.GameGL
{
    public static class Collision
    {

          public static bool CheckCollision(GameCell cell)
          {
              if (cell.CurrentGameObject.GameObjectType == GameObjectType.REWARD || cell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
              {
                  return true;
              }
              return false;
          }

    }
}