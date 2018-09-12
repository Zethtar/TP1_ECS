using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Character : DrawableObject
    {
        private static char currentChar = 'a';

        public Character(int xPos, int yPos, float xDirection, float yDirection) : base(currentChar)
        {
            currentChar++;  
            this.xPos = xPos;
            this.yPos = yPos;

            this.xDirection = xDirection;
            this.yDirection = yDirection;
        }
    }
}
