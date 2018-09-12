using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;


namespace OOP
{
    class Game
    {
        private const float MAX_FRAME_RATE = 15f;
        private const float MAX_FRAME_RATE_IN_MILLISECONDS = 1.0f / MAX_FRAME_RATE * 1000.0f;

        private Stopwatch stopWatch;
        private float deltaTime;

        Character[] objects;

        public bool IsOver { get; private set; }

        public bool Init()
        {
            try
            {
                stopWatch = new Stopwatch();
                stopWatch.Start();
                deltaTime = 0;

                Random rnd = new Random();

                objects = new Character[52];
                for (int i = 0; i < objects.Length; i++)
                {
                    float xDirection = (float)rnd.Next(250, 750) / 1000;

                    objects[i] = new Character(
                        rnd.Next(Console.WindowLeft+5, Console.WindowWidth-5),
                        rnd.Next(Console.WindowTop+5, Console.WindowHeight-5),
                        rnd.Next(0, 2) == 1 ? xDirection : -xDirection,
                        rnd.Next(0, 2) == 1 ? 1f - xDirection : -(1f - xDirection));
                }

                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                Console.Read();
                return false;
            }
        }

        public void GetInput()
        {
        }

        public void Update()
        {
            if(deltaTime < MAX_FRAME_RATE_IN_MILLISECONDS)
            {
                Thread.Sleep((int)(MAX_FRAME_RATE_IN_MILLISECONDS - deltaTime));
            }

            deltaTime = stopWatch.ElapsedMilliseconds;
            stopWatch.Restart();

            //Update
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].Update(deltaTime);
            }

            //Collision
            for (int i = 0; i < objects.Length; i++)
            {
                for (int j = 0; j < objects.Length; j++)
                {
                    if(i != j && objects[i].CollideWith(objects[j]))
                    {
                        objects[i].Collided();
                        objects[j].Collided();
                    }
                }
            }
        }

        //Dans ce contexte, draw affichera seulement l'état des objets dans la console
        public void Draw()
        {
            Console.Clear();

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].Draw();
            }
        }
    }
}
