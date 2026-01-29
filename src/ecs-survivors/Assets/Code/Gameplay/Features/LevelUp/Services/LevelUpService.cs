using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;

namespace Code.Gameplay.Features.LevelUp.Services
{
  public class LevelUpService : ILevelUpService
  {
    private readonly IStaticDataService _staticData;

    public float CurrentExperience { get; private set; }
    public int CurrentLevel { get; private set; }


    public LevelUpService(IStaticDataService staticData) => 
      _staticData = staticData;

    public void AddExperience(float value)
    {
      CurrentExperience += value;

      UpdateLevel();
    }
    
    public float ExperienceForLevelUp() => 
      _staticData.ExperienceForLevel(CurrentLevel + 1);

    private void UpdateLevel()
    {
      if(CurrentLevel >= _staticData.MaxLevel()) 
        return;

      float experienceForLevel = _staticData.ExperienceForLevel(CurrentLevel + 1);
      
      if(CurrentExperience < experienceForLevel)
        return;
      
      CurrentExperience -= experienceForLevel;
      CurrentLevel++;

      CreateEntity.Empty()
        .isLevelUp = true;
      
      UpdateLevel();
    }
  }
}