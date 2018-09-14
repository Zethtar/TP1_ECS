using ECS.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component = ECS.Components.Component;

namespace ECS.Systems
{
    class RenderSystem : IComponentSystem
    {
        private static RenderSystem instance;

        private RenderSystem()
        {
        }

        public static RenderSystem GetInstance()
        {
            if (instance == null)
                instance = new RenderSystem();

            return instance;
        }

        public void UpdateComponents()
        {
            Console.Clear();

            foreach(Entity ent in EntitySystem.GetInstance().entities)
            {
                PhysicsComponent physics = null;
                RenderComponent render = null;

                for (int i = 0; i < ent.components.Count; i++)
                {
                    if (typeof(PhysicsComponent) == ent.components.ElementAt(i).GetType())
                        physics = (PhysicsComponent)ent.components.ElementAt(i);

                    if (typeof(RenderComponent) == ent.components.ElementAt(i).GetType())
                        render = (RenderComponent)ent.components.ElementAt(i);
                } 

                if(render != null && physics != null)
                {
                    Console.SetCursorPosition(
                        (int)physics.xPosition,
                        (int)physics.yPosition);
                    Console.Write(render.character);
                }
            }
        }
    }
}
