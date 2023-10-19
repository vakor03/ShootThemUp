using UnityEngine;
using UnityEngine.Splines;

namespace ShootThemUp._Project.Scripts
{
    public class EnemyFactory
    {
        public GameObject CreateEnemy(EnemyType enemyType, SplineContainer spline)
        {
            EnemyBuilder enemyBuilder = new EnemyBuilder()
                .SetEnemyPrefab(enemyType.enemyPrefab)
                .SetSpline(spline)
                .SetWeaponPrefab(enemyType.weaponPrefab)
                .SetSpeed(enemyType.speed);

            return enemyBuilder.Build();
        }
    }
}