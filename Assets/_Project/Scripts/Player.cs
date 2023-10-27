using System;
using UnityEngine;

namespace ShootThemUp
{
    public class Player : Plane
    {
        [SerializeField] private float maxFuel;
        [SerializeField] private float fuelConsumptionRate;

        private float _fuel;
        
        private void Awake()
        {
            base.Awake();
            
            _fuel = maxFuel;
        }

        private void Update()
        {
            _fuel -= fuelConsumptionRate * Time.deltaTime;
        }

        public float GetFuelNormalized()
        {
            return _fuel / maxFuel;
        }

        protected override void Die()
        {
            // TODO: Implement player death
        }
    }
}