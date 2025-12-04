using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Common.Visuals.Systems
{
  public class PlayDiedAnimationOnDestructSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private List<GameEntity> _buffer = new(64);

    public PlayDiedAnimationOnDestructSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf( 
          GameMatcher.SelfDestructTimer,
          GameMatcher.DiedAnimator));
    }
    
    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        entity.DiedAnimator.PlayDied();
        entity.RemoveDiedAnimator();
      }
    }
  }
}