#include "HealthComponent.h"

HealthComponent::HealthComponent(int startingHealthPoints)
{
    nbHealthPoints = startingHealthPoints;
}

HealthComponent::~HealthComponent()
{
}

void HealthComponent::Heal(int nbHealthPoints)
{
    this->nbHealthPoints += nbHealthPoints;
}

void HealthComponent::Hit(int nbHealthPoints)
{
    this->nbHealthPoints -= nbHealthPoints;
}

int HealthComponent::GetHealthPoints()
{
    return this->nbHealthPoints;
}

bool HealthComponent::IsAlive()
{
    return this->nbHealthPoints > 0;
}
