using System;
using System.Collections.Generic;
using Eflatun.SceneReference;
using MEC;
using UnityEngine.SceneManagement;

namespace ShootThemUp
{
    public static class Loader
    {
        private static SceneReference _loadingScene =
            new(SceneGuidToPathMapProvider.ScenePathToGuidMap["Assets/_Project/Scenes/Loading.unity"]);

        private static SceneReference _targetScene;

        public static void Load(SceneReference targetScene)
        {
            _targetScene = targetScene;
            SceneManager.LoadScene("Loading");
            Timing.RunCoroutine(LoadTargetScene());
        }

        private static IEnumerator<float> LoadTargetScene()
        {
            yield return Timing.WaitForOneFrame;
            SceneManager.LoadScene(_targetScene.Name);
        }
    }
}