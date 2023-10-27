using UnityEngine;

namespace ShootThemUp
{
    public class EnemyWeapon : Weapon
    {
        private float _fireTimer;

        private void Update()
        {
            _fireTimer += Time.deltaTime;
            if (_fireTimer >= weaponStrategy.FireRate)
            {
                _fireTimer = 0f;
                weaponStrategy.Fire(firePoint, layer);
            }
        }
    }
}