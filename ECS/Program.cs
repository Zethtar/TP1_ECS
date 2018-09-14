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
        private static char currentChar = 'a';
        private static Random rnd;

        static void Main(string[] args)
        {
            rnd = new Random();

            for (int i = 0; i < 52; i++)
            {
                CreatePlayer();
            }

            while(true)
            {
                PhysicsSystem.GetInstance().UpdateComponents();
                RenderSystem.GetInstance().UpdateComponents();
            }
        }

        private static void CreatePlayer()
        {
            int entityId = EntitySystem.GetInstance().CreateEntity();

            PhysicsComponent physics = new PhysicsComponent();

            float xDirection = (float)rnd.Next(250, 750) / 1000;
            float yDirection = 1f - xDirection;

            physics.xPosition = rnd.Next(Console.WindowLeft, Console.WindowWidth);
            physics.yPosition = rnd.Next(Console.WindowTop, Console.WindowHeight);
            physics.xDirection = rnd.Next(0, 2) == 1 ? xDirection : -xDirection;
            physics.yDirection = rnd.Next(0, 2) == 1 ? yDirection : -yDirection;
            physics.speed = 5;

            EntitySystem.GetInstance().AddComponent(entityId, physics);

            RenderComponent render = new RenderComponent();

            render.character = currentChar;
            currentChar++;

            EntitySystem.GetInstance().AddComponent(entityId, render);
        }
    }
}
