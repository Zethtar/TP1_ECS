﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class DrawableObject : MovableObject
    {
        private char character;

        public DrawableObject(char character)
        {
            this.character = character;
        }

        public DrawableObject(char character, float xPos, float yPos, float xDirection, float yDirection) :
            base(xPos, yPos, xDirection, yDirection)
        {
            this.character = character;
        }

        public void Draw()
        {
            Console.SetCursorPosition((int)xPos, (int)yPos);
            Console.Write(character);
        }
    }
}
