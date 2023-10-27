using UnityEngine;

namespace ShootThemUp
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        private int _score;
        private Player _player;

        public bool IsGameOver => _player.GetHealthNormalized() <= 0 
                                  || _player.GetFuelNormalized() <= 0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            _player = FindObjectOfType<Player>();
        }

        public void AddScore(int score)
        {
            _score += score;
        }

        public int GetScore()
        {
            return _score;
        }
    }
}