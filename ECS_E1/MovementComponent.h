#ifndef MOVEMENT_COMPONENT
#define MOVEMENT_COMPONENT

#include <SFML/Graphics.hpp>

class MovementComponent
{
public:
    MovementComponent(sf::Vector2f initialPosition = sf::Vector2f());
    ~MovementComponent();

    void Move(float xOffset, float yOffset);
    void Move(sf::Vector2f offset);

    sf::Vector2f GetPosition();

private:
    sf::Vector2f position;
};

#endif // !MOVEMENT_COMPONENT