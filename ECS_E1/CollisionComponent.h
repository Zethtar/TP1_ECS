#ifndef COLLISION_COMPONENT
#define COLLISION_COMPONENT

#include <SFML/Graphics.hpp>

class CollisionComponent
{
public:
    CollisionComponent(sf::Rect<float> boundingBox);
    ~CollisionComponent();

    bool CollideWith(sf::Rect<float> otherBoundingBox);

    sf::Rect<float> GetBoundingBox();

private:
    sf::Rect<float> boundingBox;
};

#endif // !COLLISION_COMPONENT