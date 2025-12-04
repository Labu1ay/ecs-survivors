using System.Collections.Generic;
using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
  public class DestructOnZeroHPSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private List<GameEntity> _buffer = new (64);

    public DestructOnZeroHPSystem(GameContext game)
    { 
      _entities = game.GetGroup(GameMatcher.CurrentHP);
    }
    
    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        if (entity.CurrentHP <= 0f)
        {
          entity.AddSelfDestructTimer(1f);
          entity.RemoveTargetCollectionComponents();
          entity.RemoveCurrentHP();
        }
      }
    }
  }
}