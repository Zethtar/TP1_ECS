using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            if(game.Init())
            {
                while(!game.IsOver) //Loop de jeu 
                {
                    //game.GetInputs() //Pas nécessaire dans ce contexte
                    game.Update();
                    game.Draw();
                }
            }
        }
    }

 

}

