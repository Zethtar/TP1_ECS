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
        private const float MAX_FRAME_RATE = 15f; //Frame rate par seconde
        //Pour éviter d'avoir besoin de recalculer plusieurs fois
        private const float MAX_FRAME_RATE_IN_MILLISECONDS = 1.0f / MAX_FRAME_RATE * 1000.0f;

        private Stopwatch stopWatch;
        private float deltaTime;

        Character[] characters;

        public bool IsOver { get; private set; }

        public bool Init()
        {
            try
            {
                stopWatch = new Stopwatch();
                stopWatch.Start();
                deltaTime = 0;

                Random rnd = new Random();

                characters = new Character[52];
                for (int i = 0; i < characters.Length; i++)
                {
                    float xDirection = (float)rnd.Next(250, 750) / 1000;
                    float yDirection = 1f - xDirection;

                    characters[i] = new Character(
                        rnd.Next(Console.WindowLeft, Console.WindowWidth),
                        rnd.Next(Console.WindowTop, Console.WindowHeight),
                        rnd.Next(0, 2) == 1 ? xDirection : -xDirection,
                        rnd.Next(0, 2) == 1 ? yDirection : -yDirection
                        );
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

        public void Update()
        {
            //Pour éviter de rafraichir l'écran trop souvent
            if(deltaTime < MAX_FRAME_RATE_IN_MILLISECONDS)
            {
                Thread.Sleep((int)(MAX_FRAME_RATE_IN_MILLISECONDS - deltaTime));
            }

            deltaTime = stopWatch.ElapsedMilliseconds;
            stopWatch.Restart();

            //Update
            for (int i = 0; i < characters.Length; i++)
            {
                characters[i].Update(deltaTime);
            }

            //Collision
            for (int i = 0; i < characters.Length; i++)
            {
                for (int j = 0; j < characters.Length; j++)
                {
                    if(i != j && characters[i].CollideWith(characters[j]))
                    {
                        characters[i].Collided();
                        characters[j].Collided();
                    }
                }
            }
        }

        public void Draw()
        {
            Console.Clear();

            for (int i = 0; i < characters.Length; i++)
            {
                characters[i].Draw();
            }
        }
    }
}
