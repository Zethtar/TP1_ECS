#ifndef HEALTH_COMPONENT
#define HEALTH_COMPONENT

class HealthComponent
{
public:
    HealthComponent(int startingHealthPoints = 100);
    ~HealthComponent();

    void Heal(int nbHealthPoints);
    void Hit(int nbHealthPoints);

    int GetHealthPoints();
    bool IsAlive();

private:
    int nbHealthPoints;
};

#endif // !HEALTH_COMPONENT

