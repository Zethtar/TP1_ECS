#include "MovementComponent.h"

MovementComponent::MovementComponent(sf::Vector2f initialPosition)
{
    position = initialPosition;
}

MovementComponent::~MovementComponent()
{
}

void MovementComponent::Move(float xOffset, float yOffset)
{
    position.x += xOffset;
    position.y += yOffset;
}

void MovementComponent::Move(sf::Vector2f offset)
{
    Move(offset.x, offset.y);
}

sf::Vector2f MovementComponent::GetPosition()
{
    return position;
}
