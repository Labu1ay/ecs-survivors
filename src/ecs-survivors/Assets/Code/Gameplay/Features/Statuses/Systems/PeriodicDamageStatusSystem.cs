using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
  public class PeriodicDamageStatusSystem : IExecuteSystem
  {
    private readonly ITimeService _time;
    private readonly IEffectFactory _effectFactory;
    private readonly IGroup<GameEntity> _statuses;

    public PeriodicDamageStatusSystem(GameContext game, ITimeService time, IEffectFactory effectFactory)
    {
      _time = time;
      _effectFactory = effectFactory;
      _statuses = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Status,
          GameMatcher.Period,
          GameMatcher.TimeSinceLastTick,
          GameMatcher.EffectValue,
          GameMatcher.ProducerId,
          GameMatcher.TargetId));
    }

    public void Execute()
    {
      foreach (GameEntity status in _statuses)
      {
        if(status.TimeSinceLastTick >= 0f)
          status.ReplaceTimeSinceLastTick(status.TimeSinceLastTick - _time.DeltaTime);
        else
        {
          status.ReplaceTimeSinceLastTick(status.Period);
          
          _effectFactory.CreateEffect(new EffectSetup(){EffectTypeId = EffectTypeId.Damage, Value = 1f},
            status.ProducerId, 
            status.TargetId);
        }
      }
    }
  }
}