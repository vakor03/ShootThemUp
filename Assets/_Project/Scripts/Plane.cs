using System;
using UnityEngine;

namespace ShootThemUp
{
    public abstract class Plane : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        private int _health;

        protected void Awake()
        {
            _health = maxHealth;
        }
        
        public void SetMaxHealth(int amount)
        {
            maxHealth = amount;
        }
        
        public void TakeDamage(int amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                Die();
            }
        }
        
        public float GetHealthNormalized()
        {
            return (float) _health / maxHealth;
        }

        protected abstract void Die();
    }
}