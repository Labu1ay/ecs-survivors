using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
  public class CleanupCollected : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _collected;

    public CleanupCollected(GameContext game)
    {
      _collected = game.GetGroup(GameMatcher.Collected);
    }

    public void Cleanup()
    {
      foreach (GameEntity collected in _collected)
      {
        collected.isDestructed = true;
      }
    }
  }
}