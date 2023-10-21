using System;
using ShootThemUp._Project.Scripts.Utilities.Attributes;
using UnityEngine;

namespace ShootThemUp._Project.Scripts
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected WeaponStrategy weaponStrategy;
        [SerializeField] protected Transform firePoint;
        [SerializeField, Layer] protected int layer;

        private void OnValidate()
        {
            layer = gameObject.layer;
        }

        private void Start()
        {
            weaponStrategy.Initialize();
        }
        
        public void SetWeaponStrategy(WeaponStrategy newStrategy)
        {
            weaponStrategy = newStrategy;
            weaponStrategy.Initialize();
        }
    }
}