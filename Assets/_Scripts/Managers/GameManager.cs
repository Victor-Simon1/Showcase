using UnityEngine;
using MyUnityPackage.Toolkit;
using MyUnityPackage.ProgressionSystem;

namespace Showcase
{
    public class GameManager: MonoBehaviour
    {
        [SerializeField] QuestManager questManager;
        private void Awake()
        {
            ServiceLocator.AddService<GameManager>(gameObject);
            SetupGame();
        }
        void Start()
        {
            questManager.ActivateQuest("Quest1");
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
