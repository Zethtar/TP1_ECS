#pragma once
#include "Entity.h"

class EntityManager
{
public:
    EntityManager();
    ~EntityManager();

   

private:
    Entity* entities;
    static int entityCounter;
};

