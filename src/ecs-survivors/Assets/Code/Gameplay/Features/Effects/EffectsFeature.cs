using Code.Gameplay.Features.Effects.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Effects
{
  public sealed class EffectsFeature : Feature
  {
    public EffectsFeature(ISystemFactory systems)
    {
      Add(systems.Create<RemoveEffectsWithoutTargetsSystem>());
      
      Add(systems.Create<ProcessDamageEffectSystem>());
      Add(systems.Create<CleanupProcessedEffectsSystem>());
    }
  }
}