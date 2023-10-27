using System;
using UnityEngine;

namespace ShootThemUp
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private GameObject muzzlePrefab;
        [SerializeField] private GameObject hitPrefab;

        private Transform _parent;
        private Transform _transform; // transform cache
        public event Action Callback;

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }
        
        public void SetParent(Transform parent)
        {
            _parent = parent;
        }

        private void Awake()
        {
            _transform = transform;
        }

        private void Start()
        {
            if (muzzlePrefab != null)
            {
                var muzzleVfx = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVfx.transform.forward = gameObject.transform.forward;
                muzzleVfx.transform.SetParent(_parent);
                
                DestroyParticleSystem(muzzleVfx);
            }
        }
        
        private void Update()
        {
            _transform.SetParent(null);
            _transform.position += _transform.forward * (speed * Time.deltaTime);
            
            Callback?.Invoke();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (hitPrefab != null)
            {
                ContactPoint contactPoint = other.contacts[0];
                var hitVfx = Instantiate(hitPrefab, contactPoint.point, Quaternion.identity);
                
                DestroyParticleSystem(hitVfx);
            }
            
            Destroy(gameObject);
        }

        private void DestroyParticleSystem(GameObject vfx)
        {
            ParticleSystem ps = vfx.GetComponent<ParticleSystem>();
            if (ps == null)
            {
                ps = vfx.GetComponentInChildren<ParticleSystem>();
            }
            
            Destroy(vfx, ps.main.duration);
        }
    }
}