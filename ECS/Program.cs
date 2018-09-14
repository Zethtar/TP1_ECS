using ECS.Components;
using ECS.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    class Program
    {
        private const int NB_CHARACTER = 52;
        private const float CHARACTER_SPEED = 5;

        private static char currentChar = 'a';
        private static Random rnd;

        static void Main(string[] args)
        {
            rnd = new Random();

            for (int i = 0; i < NB_CHARACTER; i++)
            {
                CreatePlayer();
            }

            while(true) //Les système pourraient être des "Threads" continues
            {
                PhysicsSystem.GetInstance().UpdateComponents();
                RenderSystem.GetInstance().UpdateComponents();
            }
        }

        private static void CreatePlayer()
        {
            int entityId = EntitySystem.GetInstance().CreateEntity();

            //Initialisation du component de physique
            PhysicsComponent physics = new PhysicsComponent();

            float xDirection = (float)rnd.Next(250, 750) / 1000;
            float yDirection = 1f - xDirection;

            physics.xPosition = rnd.Next(Console.WindowLeft, Console.WindowWidth);
            physics.yPosition = rnd.Next(Console.WindowTop, Console.WindowHeight);
            physics.xDirection = rnd.Next(0, 2) == 1 ? xDirection : -xDirection;
            physics.yDirection = rnd.Next(0, 2) == 1 ? yDirection : -yDirection;
            physics.speed = CHARACTER_SPEED;

            EntitySystem.GetInstance().AddComponent(entityId, physics);

            //Initialisation du component de rendu
            RenderComponent render = new RenderComponent();

            render.character = currentChar;

            EntitySystem.GetInstance().AddComponent(entityId, render);

            currentChar++;
        }
    }
}
