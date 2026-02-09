using UnityEngine;

namespace Code.Meta.Features.AfkGain.Configs
{
  [CreateAssetMenu(fileName = "AfkGainConfig", menuName = "ECS Survivors/Afk Gain Config", order = 0)]
  public class AfkGainConfig : ScriptableObject
  {
    public float GoldPerSecond = 1;
  }
}