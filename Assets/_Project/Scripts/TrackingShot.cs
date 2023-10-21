using ShootThemUp._Project.Scripts.Utilities.Extensions;
using UnityEngine;

namespace ShootThemUp._Project.Scripts
{
    [CreateAssetMenu(menuName = "ShootThemUp/WeaponStrategy/TrackingShot", fileName = "TrackingShot", order = 0)]
    public class TrackingShot : WeaponStrategy
    {
        [SerializeField] private float trackingSpeed;
        
        private Transform _target;
        
        public override void Initialize()
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
        public override void Fire(Transform firePoint, LayerMask layerMask)
        {
            var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);
            projectile.layer = layerMask;
            
            var projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);
            projectileComponent.Callback += () =>
            {
                var direction = (_target.position - projectile.transform.position).With(z:firePoint.position.z).normalized;
                
                var rotation = Quaternion.LookRotation(direction, Vector3.forward);
                projectile.transform.rotation = Quaternion.Slerp(projectile.transform.rotation, rotation, trackingSpeed * Time.deltaTime);
            };
            
            Destroy(projectile, projectileLifetime);
        }
    }
}