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

            AudioUpdater[] audioUpdatersList = FindObjectsByType<AudioUpdater>(FindObjectsInactive.Include ,FindObjectsSortMode.None);
            foreach (AudioUpdater audioUpdater in audioUpdatersList)
            {
                audioUpdater.Initialize(); 
            }
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
