using Code.Gameplay.Features.Enemies.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Enemies
{
    public class EnemyComponents
    {
        [Game] public class Enemy : IComponent { }
        [Game] public class EnemyAnimatorComponent : IComponent { public EnemyAnimator Value; }
        [Game] public class StoppingDistance : IComponent { public float Value; }
    }
}