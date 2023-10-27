using Eflatun.SceneReference;
using ShootThemUp.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace ShootThemUp
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private SceneReference startingLevel;
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;

        private void Awake()
        {
            playButton.onClick.AddListener(()=> Loader.Load(startingLevel));
            quitButton.onClick.AddListener(Helpers.QuitGame);
            Time.timeScale = 1f;
        }
    }
}