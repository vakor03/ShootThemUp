using UnityEngine;

namespace ShootThemUp
{
    public class PlayerWeapon : Weapon
    {
        [SerializeField] private InputReader inputReader;
        
        private float _fireTimer;

        private void Update()
        {
            _fireTimer += Time.deltaTime;
            if (inputReader.Fire && _fireTimer >= weaponStrategy.FireRate)
            {
                _fireTimer = 0f;
                weaponStrategy.Fire(firePoint, layer);
            }
        }
    }
}