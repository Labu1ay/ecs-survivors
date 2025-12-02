using Code.Gameplay.Features.Enemies.Systems;

namespace Code.Gameplay.Features.Enemies
{
    public class EnemyFeature : Feature
    {
        public EnemyFeature(GameContext game)
        {
            Add(new SetEnemyDirectionByHeroPositionSystem(game));

            Add(new AnimateEnemyMovementSystem(game));
        }
    }
}