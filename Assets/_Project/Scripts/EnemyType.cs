﻿using UnityEngine;

namespace ShootThemUp
{
    [CreateAssetMenu(menuName = "ShootThemUp/EnemyType", fileName = "EnemyType", order = 0)]
    public class EnemyType : ScriptableObject
    {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed;
    }
}