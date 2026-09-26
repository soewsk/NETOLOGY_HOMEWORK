using Netologia.Behaviours;
using Netologia.TowerDefence;
using Netologia.TowerDefence.Behaviors;
using UnityEngine;
using Zenject;

namespace Netologia.Systems
{
	public class TowerSystem : GameObjectPoolContainer<Tower>, Director.IManualUpdate
	{
		private UnitSystem _units;				//injected
		private ProjectileSystem _projectiles;  //injected

        public void ManualUpdate()
        {
            foreach (var pair in this)
                foreach (var tower in pair)
                {
                    if (!tower.DecrementAttackReload(TimeManager.DeltaTime))
                    {
                        continue; 
                    }

                    if(!tower.HasTarget)
					{
						tower.Target = _units.FindTarget(tower.transform.position, tower.Range);
					}
                    if (!tower.HasTarget) continue;

					var projectile = _projectiles[tower.Projectile].Get;
					projectile.PrepareData(tower.transform.position, tower.Target, tower.Damage, tower.AttackElemental);
					tower.Attack();
                }
        }

        public void OnDespawnUnit(int unitID)
		{
			foreach (var pair in this)
				foreach (var tower in pair)
					if (tower.TargetID == unitID)
						tower.Target = null;
		}
		
		[Inject]
		private void Construct(UnitSystem units, ProjectileSystem projectiles)
		{
			_units = units;
			_projectiles = projectiles;
		}
	}
}