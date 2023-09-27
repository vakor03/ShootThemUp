using System;
using UnityEngine;

namespace ShootThemUp._Project.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float speed;

        private void Start()
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }

        private void LateUpdate()
        {
            transform.position += Vector3.up * (speed * Time.deltaTime);
        }
    }
}