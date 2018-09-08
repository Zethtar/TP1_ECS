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
                while(!game.IsOver)
                {
                    game.GetInput();
                    game.Update();
                    game.Draw();
                }
            }
        }
    }

 

}

