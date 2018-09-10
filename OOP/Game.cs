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
        private Stopwatch stopWatch;
        private float deltaTime;

        private Hero hero;

        public bool IsOver { get; private set; }

        public bool Init()
        {
            try
            {
                stopWatch = new Stopwatch();
                stopWatch.Start();
                deltaTime = 0;

                hero = new Hero();

                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //Dans ce contexte, GetInput lira la console pour savoir quoi faire
        //On a donc seulement quelques commandes pré-déterminées
        public void GetInput()
        {
            Console.Write("What is your command : ");
            string command = Console.ReadLine();

            if(command == "end")
            {
                IsOver = true;
            }
            else if(command == "heromove")
            {
                
            }
        }

        public void Update()
        {
            deltaTime = stopWatch.ElapsedMilliseconds;
            stopWatch.Restart();
        }

        //Dans ce contexte, draw affichera seulement l'état des objets dans la console
        public void Draw()
        {
            Console.WriteLine("\n---------------------\n");

            Console.WriteLine("Delta time : {0} milliseconds", deltaTime);
            hero.Draw();
        }
    }
}
