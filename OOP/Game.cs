using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Game
    {
        private static long lastTime;
        private static long deltaTime;

        private Hero hero;

        public bool IsOver { get; private set; }

        public bool Init()
        {
            try
            {
                lastTime = DateTime.Now.Millisecond;

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
        }

        public void Update()
        {
            long now = DateTime.Now.Millisecond;
            deltaTime = now - lastTime;
            lastTime = now;
        }

        //Dans ce contexte, draw affichera seulement l'état des objets dans la console
        public void Draw()
        {
            Console.Clear();

            Console.WriteLine("Delta time : {0} milliseconds", deltaTime);
            hero.Draw();
        }
    }
}
