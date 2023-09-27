using System;
using UnityEngine;

namespace ShootThemUp._Project.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputReader inputReader;

        [SerializeField] private float speed = 5f;
        [SerializeField] private float smoothing = 0.1f;


        [SerializeField] private float leanAngle;
        [SerializeField] private float leanSpeed;
        [SerializeField] private GameObject model;

        [Header("Camera bounds")] [SerializeField]
        private Transform cameraFollow;

        [SerializeField] private float xMin = -2.5f;

        [SerializeField] private float xMax = 2.5f;
        [SerializeField] private float yMin = -5f;
        [SerializeField] private float yMax = 5f;

        private Vector3 _currentVelocity;
        private Vector3 _targetPosition;

        private void Update()
        {
            _targetPosition += new Vector3(inputReader.Move.x, inputReader.Move.y, 0f) * (speed * Time.deltaTime);

            float minPlayerX = cameraFollow.position.x + xMin;
            float maxPlayerX = cameraFollow.position.x + xMax;
            float minPlayerY = cameraFollow.position.y + yMin;
            float maxPlayerY = cameraFollow.position.y + yMax;
            
            _targetPosition.x = Mathf.Clamp(_targetPosition.x, minPlayerX, maxPlayerX);
            _targetPosition.y = Mathf.Clamp(_targetPosition.y, minPlayerY, maxPlayerY);
            
            transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVelocity, smoothing);
            
            float targetRotationAngle =  -inputReader.Move.x * leanAngle;
            
            float currentRotationY = model.transform.localEulerAngles.y;
            float rotationY = Mathf.LerpAngle(currentRotationY, targetRotationAngle, Time.deltaTime * leanSpeed);
            
            model.transform.localEulerAngles = new Vector3(0f, rotationY, 0f);
        }
    }
}