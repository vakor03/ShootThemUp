using ShootThemUp.Utilities.Extensions;
using UnityEngine;
using UnityEngine.Splines;

namespace ShootThemUp
{
    public class EnemyBuilder
    {
        private GameObject _enemyPrefab;
        private SplineContainer _spline;
        private GameObject _weaponPrefab;
        private float _speed;
        
        public EnemyBuilder SetEnemyPrefab(GameObject enemyPrefab)
        {
            _enemyPrefab = enemyPrefab;
            return this;
        }
        
        public EnemyBuilder SetSpline(SplineContainer spline)
        {
            _spline = spline;
            return this;
        }
        
        public EnemyBuilder SetWeaponPrefab(GameObject weaponPrefab)
        {
            _weaponPrefab = weaponPrefab;
            return this;
        }
        
        public EnemyBuilder SetSpeed(float speed)
        {
            _speed = speed;
            return this;
        }

        public GameObject Build()
        {
            GameObject instance = Object.Instantiate(_enemyPrefab);

            SplineAnimate splineAnimate = instance.GetOrAdd<SplineAnimate>();
            splineAnimate.Container = _spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineAnimate.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = _speed;

            // Weapons
            
            // Set instance transform to the first point of the spline
            instance.transform.position = _spline.EvaluatePosition(0f);
            
            return instance;
        }
    }
}