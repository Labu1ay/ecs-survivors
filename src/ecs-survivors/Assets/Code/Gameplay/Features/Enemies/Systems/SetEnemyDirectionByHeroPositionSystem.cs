using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class SetEnemyDirectionByHeroPositionSystem : IExecuteSystem
    {
        
        
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;

        public SetEnemyDirectionByHeroPositionSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.Hero);
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.StoppingDistance));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity enemy in _enemies)
            {
                enemy.isMoving = Vector3.Distance(enemy.WorldPosition, hero.WorldPosition) > enemy.StoppingDistance;
                
                if(enemy.isMoving)
                    enemy.ReplaceDirection(hero.WorldPosition - enemy.WorldPosition);
            }
        }
    }
}