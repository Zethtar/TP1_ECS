using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Hero
    {
        private int healthPointsCount;

        private float xPos;
        private float yPos;

        private const float SPEED_SECONDS = 1;

        public Hero()
        {
            healthPointsCount = 10;

            xPos = 0;
            yPos = 0;
        }

        public void Move(float deltaTime)
        {
            xPos += SPEED_SECONDS * (deltaTime / 1000);

            Console.WriteLine("Hero has moved. My new position is {0}", xPos);
        }

        public void Draw()
        {
            Console.WriteLine("Hero have {0} health points", healthPointsCount);
        }
    }
}
