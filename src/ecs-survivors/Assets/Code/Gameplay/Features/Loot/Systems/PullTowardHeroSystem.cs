using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
  public class PullTowardHeroSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _heroes;
    private readonly IGroup<GameEntity> _pullables;

    public PullTowardHeroSystem(GameContext game)
    {
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero, 
          GameMatcher.WorldPosition));
      
      _pullables = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Pulling, 
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes)
      foreach (GameEntity pullable in _pullables)
      {
        pullable.ReplaceDirection((hero.WorldPosition - pullable.WorldPosition).normalized);
        pullable.ReplaceSpeed(4);
        pullable.isMoving = true;
        pullable.isMovementAvailable = true;
      }
    }
  }
}