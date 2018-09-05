#include <SFML/Graphics.hpp>

#ifndef SPRITE_COMPONENT
#define SPRITE_COMPONENT

class SpriteComponent
{
public:
    SpriteComponent(sf::Shape* drawable, int zOrder = 1);
    ~SpriteComponent();

    void Draw(sf::RenderWindow* renderWindow, sf::Vector2f position);
private:
    sf::Shape* drawing;
    int zOrder;
};

#endif // !SPRITE_COMPONENT

