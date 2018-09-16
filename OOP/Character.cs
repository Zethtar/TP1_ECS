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

        public Character(int xPos, int yPos, float xDirection, float yDirection) :
            base(currentChar, xPos, yPos, xDirection, yDirection)
        {
            currentChar++; //Pour éviter que tous les Characters aient la même lettre
        }
    }
}
