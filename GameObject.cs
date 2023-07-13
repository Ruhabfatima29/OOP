using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanOOP
{
    class GameObject
    {
        public char displayChar;
        public GameCell currentCell;
        public GameObjectType gameObjectType;
        public GameObject(GameObjectType type,char displayChararter)
        {
            this.gameObjectType = type;
            this.displayChar = displayChararter;
        }
        public static GameObjectType GetGameObjectType(char displayCharacter)
        {
            if(displayCharacter == 'P')
            {
               return  GameObjectType.PLAYER;
            }
            else if (displayCharacter == '#' || displayCharacter == '|' || displayCharacter == '%')
            {
                return GameObjectType.WALL;
            }
            else if(displayCharacter == '.')
            {
                return GameObjectType.REWARD;
            }
            return GameObjectType.NONE;
        }
    }
}
