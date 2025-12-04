using Code.Gameplay.Common.Visuals.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Common.Visuals
{
  public class VisualFeature : Feature
  {
    public VisualFeature(ISystemFactory systems)
    {
      Add(systems.Create<PlayDiedAnimationOnDestructSystem>());
    }
  }
}