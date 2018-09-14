using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                                                  
namespace ECS.Components                                          
{                                                                 
    class PhysicsComponent : Component                                 
    {
        public float speed;

        public float xDirection;                                  
        public float yDirection;                                  
                                                                  
        public float xPosition;                                   
        public float yPosition; 
        
        public void Collide()
        {
            xDirection *= -1;
            yDirection *= -1;

            Move(250);
        }

        public void Move(float deltaTime)
        {
            float newXPos = xPosition + xDirection * speed * (deltaTime / 1000);

            if (newXPos <= 0)
            {
                xDirection *= -1;
                xPosition = 1;
            }
            else if (newXPos >= Console.WindowWidth)
            {
                xDirection *= -1;
                xPosition = Console.WindowWidth - 1;
            }
            else
            {
                xPosition = newXPos;
            }

            float newYPos = yPosition + yDirection * speed * (deltaTime / 1000);

            if (newYPos <= 0)
            {
                yDirection *= -1;
                yPosition = 1;
            }
            else if (newYPos >= Console.WindowHeight)
            {
                yDirection *= -1;
                yPosition = Console.WindowHeight - 1;
            }
            else
            {
                yPosition = newYPos;
            }
        }
    }                                                             
}                                                                 
                                                                  