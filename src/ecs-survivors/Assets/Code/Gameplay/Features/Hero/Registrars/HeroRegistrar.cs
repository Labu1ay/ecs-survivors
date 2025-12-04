using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
  public class HeroRegistrar : EntityComponentRegistrar
  {
    public float MaxHP = 100;
    public float Speed = 2;
    public float Damage = 1;

    public override void RegisterComponents()
    {
      Entity
        .AddWorldPosition(transform.position)
        .AddDirection(Vector2.zero)
        .AddSpeed(Speed)
        .AddCurrentHP(MaxHP)
        .AddMaxHP(MaxHP)
        .AddDamage(Damage)
        .AddTargetsBuffer(new List<int>(1))
        .AddRadius(0.3f)
        .AddCollectTargetsInterval(0.5f)
        .AddCollectTargetsTimer(0)
        .AddLayerMask(CollisionLayer.Enemy.AsMask())
        .With(x => x.isHero = true)
        .With(x => x.isTurnedAlongDirection = true);
    }

    public override void UnregisterComponents()
    {
      
    }
  }
}