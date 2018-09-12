using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class MovableObject
    {
        private const float SPEED_SECONDS = 5;

        public float xPos { get; protected set; }
        public float yPos { get; protected set; }

        protected float xDirection;
        protected float yDirection;

        public MovableObject()
        {
            this.xPos = 0;
            this.yPos = 0;

            this.xDirection = 0;
            this.yDirection = 0;
        }

        public void Update(float deltaTime)
        {
            Move(deltaTime);
        }

        private void Move(float deltaTime)
        {
            yPos += yDirection * SPEED_SECONDS * (deltaTime / 1000);
            float newXPos = xPos + xDirection * SPEED_SECONDS * (deltaTime / 1000);
            if (newXPos <= 0)
            {
                xDirection *= -1;
                xPos = 1;
            }
            else if(newXPos >= Console.WindowWidth)
            {
                xDirection *= -1;
                xPos = Console.WindowWidth-1;
            }
            else
            {
                xPos = newXPos;
            }

            float newYPos = yPos + yDirection * SPEED_SECONDS * (deltaTime / 1000);
            if (newYPos <= 0)
            {
                yDirection *= -1;
                yPos = 1;
            }
            else if (newYPos >= Console.WindowHeight)
            {
                yDirection *= -1;
                yPos = Console.WindowHeight-1;
            }
            else
            {
                yPos = newYPos;
            }
        }
    }
}
