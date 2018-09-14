using ECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    class Entity
    {
        public int id { get; private set; }

        public List<IComponent> components { get; private set; }

        public Entity(int id)
        {
            this.id = id;

            components = new List<IComponent>();
        }

        public void AddComponent(IComponent newComponent)
        { 
            components.Add(newComponent);
        }

        public void RemoveComponent(IComponent component)
        {
            components.Remove(component);
        }
    }
}
