using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace ShootThemUp._Project.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyType> enemyTypes;
        [SerializeField] private int maxEnemies;
        [SerializeField] private float spawnInterval;
        
        private List<SplineContainer> _splines;
        private EnemyFactory _enemyFactory;
        
        private float _spawnTimer;
        private int _enemiesSpawned;

        private void OnValidate()
        {
            _splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        }

        private void Start()
        {
            _enemyFactory = new EnemyFactory();
        }

        private void Update()
        {
            _spawnTimer += Time.deltaTime;

            if (_enemiesSpawned < maxEnemies && _spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                _spawnTimer = 0f;
            }
        }

        private void SpawnEnemy()
        {
            EnemyType enemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            SplineContainer spline = _splines[UnityEngine.Random.Range(0, _splines.Count)];
            
            // TODO: Possible optimization - pool enemies
            _enemyFactory.CreateEnemy(enemyType, spline);
            _enemiesSpawned++;
        }
    }
}