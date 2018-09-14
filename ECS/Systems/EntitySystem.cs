using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Component = ECS.Components.Component;

namespace ECS.Systems
{
    class EntitySystem
    {
        public List<Entity> entities { get; private set; }

        private static EntitySystem instance;

        private EntitySystem()
        {
            entities = new List<Entity>();
        }

        public static EntitySystem GetInstance()
        {
            if(instance == null)
            {
                instance = new EntitySystem();
            }

            return instance;
        }

        public int CreateEntity()
        {
            Entity newEntity = new Entity(entities.Count);

            entities.Add(newEntity);

            return newEntity.id;
        }

        public Entity GetEntity(int entityId)
        {
            foreach(Entity entity in entities)
            {
                if(entity.id == entityId)
                {
                    return entity;
                }
            }

            return null;
        }

        public void AddComponent(int id, Component component)
        {
            Entity entity;

            foreach (Entity ent in entities)
            {
                if (ent.id == id)
                {
                    entity = ent;

                    if(!entity.components.Contains(component))
                        entity.AddComponent(component);

                    break;
                }
            }
        }
    }
}
