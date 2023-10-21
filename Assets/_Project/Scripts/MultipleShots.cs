using UnityEngine;

namespace ShootThemUp._Project.Scripts
{
    [CreateAssetMenu(menuName = "ShootThemUp/WeaponStrategy/MultipleShots", fileName = "MultipleShotsStrategy",
        order = 0)]
    public class MultipleShots : WeaponStrategy
    {
        [SerializeField] private int shotsCount = 3;
        [SerializeField] private float angleBetweenShots = 15f;

        public override void Fire(Transform firePoint, LayerMask layerMask)
        {
            for (int i = 0; i < shotsCount; i++)
            {
                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                projectile.transform.SetParent(firePoint);
                projectile.layer = layerMask;
                
                projectile.transform.Rotate(0f, angleBetweenShots * (i - (shotsCount-1) / 2f), 0f);

                var projectileComponent = projectile.GetComponent<Projectile>();
                projectileComponent.SetSpeed(projectileSpeed);

                Destroy(projectile, projectileLifetime);
            }
        }
    }
}