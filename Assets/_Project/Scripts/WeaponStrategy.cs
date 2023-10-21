using UnityEngine;

namespace ShootThemUp._Project.Scripts
{
    public abstract class WeaponStrategy : ScriptableObject
    {
        [SerializeField] private int damage;
        [SerializeField] private float fireRate;
        [SerializeField] protected float projectileSpeed;
        [SerializeField] protected float projectileLifetime;
        [SerializeField] protected GameObject projectilePrefab;
        
        public int Damage => damage;
        public float FireRate => fireRate;

        public virtual void Initialize()
        {
            // no-op
        }

        public abstract void Fire(Transform firePoint, LayerMask layerMask);
    }
}