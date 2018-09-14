using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Component = ECS.Components.Component;

namespace ECS.Systems
{
    interface IComponentSystem
    {
        void UpdateComponents();
    }
}
