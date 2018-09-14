using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IComponent = ECS.Components.IComponent;

namespace ECS.Systems
{
    class EntitySystem
    {
        private static EntitySystem instance;

        private static int entitiesCount = 0;

        public List<Entity> entities { get; private set; }

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
            Entity newEntity = new Entity(entitiesCount);

            entities.Add(newEntity);
            entitiesCount++;

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

        public void AddComponent(int entityId, IComponent component)
        {
            foreach (Entity entity in entities)
            {
                if (entity.id == entityId)
                {
                    if(!entity.components.Contains(component))
                        entity.AddComponent(component);

                    break;
                }
            }
        }
    }
}
