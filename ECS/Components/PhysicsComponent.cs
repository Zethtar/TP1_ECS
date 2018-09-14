using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                                                  
namespace ECS.Components                                          
{                                                                 
    class PhysicsComponent : IComponent                                 
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

            if (newXPos <= 0) //Collision avec le mur gauche
            {
                xDirection *= -1;
                xPosition = 1;
            }
            else if (newXPos >= Console.WindowWidth) //Collision avec le mur droit
            {
                xDirection *= -1;
                xPosition = Console.WindowWidth - 1;
            }
            else
            {
                xPosition = newXPos;
            }

            float newYPos = yPosition + yDirection * speed * (deltaTime / 1000);

            if (newYPos <= 0) //Collision avec le mur haut
            {
                yDirection *= -1;
                yPosition = 1;
            }
            else if (newYPos >= Console.WindowHeight) //Collision avec le mur bas
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
                                                                  