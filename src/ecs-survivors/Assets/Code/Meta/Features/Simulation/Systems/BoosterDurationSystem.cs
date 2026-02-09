using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
  public class BoosterDurationSystem : IExecuteSystem
  {
    private readonly IGroup<MetaEntity> _boosters;
    private readonly IGroup<MetaEntity> _ticks;

    public BoosterDurationSystem(MetaContext meta)
    {
      _ticks = meta.GetGroup(MetaMatcher.Tick);
      
      _boosters = meta.GetGroup(MetaMatcher
        .AllOf(MetaMatcher.GoldGainBoost, MetaMatcher.Duration));
    }

    public void Execute()
    {
      foreach (MetaEntity tick in _ticks)
      foreach (MetaEntity booster in _boosters)
      {
        booster.ReplaceDuration(booster.Duration - tick.Tick);
        
        if (booster.Duration <= 0) 
          booster.isDestructed = true;
      }
    }
  }
}