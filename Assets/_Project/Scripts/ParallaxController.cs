using UnityEngine;

namespace ShootThemUp
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] private Transform[] backgrounds; // Array of background layers
        [SerializeField] private float smoothing = 10f;
        [SerializeField] private float multiplier = 15f; // How much parallax effect increments per layer

        private Transform _mainCameraTransform;
        private Vector3 _previousCameraPosition;

        private void Awake()
        {
            _mainCameraTransform = Camera.main.transform;
        }

        private void Start()
        {
            _previousCameraPosition = _mainCameraTransform.position;
        }

        private void Update()
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                float parallax = (_previousCameraPosition.y - _mainCameraTransform.position.y) * (i * multiplier);
                float targetY = backgrounds[i].position.y + parallax;

                Vector3 targetPosition = new Vector3(backgrounds[i].position.x, targetY, backgrounds[i].position.z);

                backgrounds[i].position =
                    Vector3.Lerp(backgrounds[i].position, targetPosition, smoothing * Time.deltaTime);
            }

            _previousCameraPosition = _mainCameraTransform.position;
        }
    }
}