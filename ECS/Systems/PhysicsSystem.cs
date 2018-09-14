using ECS.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Component = ECS.Components.Component;

namespace ECS.Systems
{
    class PhysicsSystem : IComponentSystem
    {
        private const float MAX_FRAME_RATE = 15f; //Frame rate par seconde
        //Pour éviter d'avoir besoin de recalculer plusieurs fois
        private const float MAX_FRAME_RATE_IN_MILLISECONDS = 1.0f / MAX_FRAME_RATE * 1000.0f;

        private Stopwatch stopWatch;
        private float deltaTime;

        private static PhysicsSystem instance;

        private PhysicsSystem()
        { 
            stopWatch = new Stopwatch();
            stopWatch.Start();
            deltaTime = 0;
        }

        public static PhysicsSystem GetInstance()
        {
            if (instance == null)
                instance = new PhysicsSystem();

            return instance;
        }

        public void UpdateComponents()
        {
            if (deltaTime < MAX_FRAME_RATE_IN_MILLISECONDS)
            {
                Thread.Sleep((int)(MAX_FRAME_RATE_IN_MILLISECONDS - deltaTime));
            }

            deltaTime = stopWatch.ElapsedMilliseconds;
            stopWatch.Restart();

            foreach (Entity ent in EntitySystem.GetInstance().entities)
            {
                UpdateEntity(ent);
            }
        }

        private void UpdateEntity(Entity entity)
        {
            PhysicsComponent entityPhysics = null;

            for (int i = 0; i < entity.components.Count; i++)
            {
                if (typeof(PhysicsComponent) == entity.components.ElementAt(i).GetType())
                {
                    entityPhysics = (PhysicsComponent)entity.components.ElementAt(i);
                }
            }

            if (entityPhysics != null)
            {
                entityPhysics.Move(deltaTime);

                CheckForCollisions(entityPhysics, entity.id);
            }
        }

        private void CheckForCollisions(PhysicsComponent entityPhysics, int entityId)
        {
            foreach (Entity other in EntitySystem.GetInstance().entities)
            {
                if (other.id != entityId)
                {
                    PhysicsComponent otherEntityPhysics = null;

                    for (int i = 0; i < other.components.Count; i++)
                    {
                        if (typeof(PhysicsComponent) == other.components.ElementAt(i).GetType())
                        {
                            otherEntityPhysics = (PhysicsComponent)other.components.ElementAt(i);
                        }
                    }

                    if (otherEntityPhysics != null &&
                        (int)entityPhysics.xPosition == (int)otherEntityPhysics.xPosition
                        && (int)entityPhysics.yPosition == (int)otherEntityPhysics.yPosition)
                    {
                        entityPhysics.Collide();

                        otherEntityPhysics.Collide();
                    }
                }
            }
        }
    }
}
