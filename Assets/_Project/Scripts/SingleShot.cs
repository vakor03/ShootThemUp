using UnityEngine;

namespace ShootThemUp._Project.Scripts
{
    [CreateAssetMenu(menuName = "ShootThemUp/WeaponStrategy/SingleShot", fileName = "SingleShot", order = 0)]
    public class SingleShot : WeaponStrategy
    {
        public override void Fire(Transform firePoint, LayerMask layerMask)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);
            projectile.layer = layerMask;
           
            var projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);
           
            Destroy(projectile, projectileLifetime);
        }
    }
}   