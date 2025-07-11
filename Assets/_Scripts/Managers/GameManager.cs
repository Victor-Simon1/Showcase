using UnityEngine;
using MyUnityPackage.Toolkit;

namespace Showcase
{
    public class GameManager: MonoBehaviour
    {
        private void Awake()
        {
            SetupGame();
        }

        private void SetupGame()
        {
            AudioManager.Initialize();
        }

        public void StartGame()
        {
            Debug.Log("StartGame");
        }

        public void EndGame()
        {
            Debug.Log("EndGame");   
        }
    }
}
