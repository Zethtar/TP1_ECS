#include "SpriteComponent.h"

SpriteComponent::SpriteComponent(sf::Shape* drawable, int zOrder)
{
    drawing = drawable;
    this->zOrder = zOrder;
}

SpriteComponent::~SpriteComponent()
{
    delete drawing;
}

void SpriteComponent::Draw(sf::RenderWindow * renderWindow, sf::Vector2f position)
{
    drawing->setPosition(position);
    renderWindow->draw(*drawing);
}
