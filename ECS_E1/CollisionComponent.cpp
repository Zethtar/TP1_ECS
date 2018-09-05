#include "CollisionComponent.h"

CollisionComponent::CollisionComponent(sf::Rect<float> boundingBox)
{
    this->boundingBox = boundingBox;
}

CollisionComponent::~CollisionComponent()
{
}

bool CollisionComponent::CollideWith(sf::Rect<float> otherBoundingBox)
{
    return boundingBox.intersects(otherBoundingBox);
}

sf::Rect<float> CollisionComponent::GetBoundingBox()
{
    return boundingBox;
}
