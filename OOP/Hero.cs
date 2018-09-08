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

        public Hero()
        {
            healthPointsCount = 10;
        }

        public void Draw()
        {
            Console.WriteLine("Hero have {0} health points", healthPointsCount);
        }
    }
}
