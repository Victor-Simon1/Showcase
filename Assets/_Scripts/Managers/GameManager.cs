using UnityEngine;
using MyUnityPackage.Toolkit;
using MyUnityPackage.ProgressionSystem;
using System.Collections;
using MyUnityPackage.Controller;
using UnityEngine.Splines;

namespace Showcase
{
    public class GameManager: MonoBehaviour
    {
        [SerializeField] QuestManager questManager;
        [SerializeField] SplineAnimate splineAnimate;
        private void Awake()
        {
            ServiceLocator.AddService<GameManager>(gameObject);
            SetupGame();
        }
        void Start()
        {
            questManager.Init();
        }
        private void SetupGame()
        {
            AudioManager.Initialize();

           // AudioUpdater[] audioUpdatersList = FindObjectsByType<AudioUpdater>(FindObjectsInactive.Include ,FindObjectsSortMode.None);
            //foreach (AudioUpdater audioUpdater in audioUpdatersList)
            //{
                //TODO
                //audioUpdater.Initialize(); 
            //}
            ElementExtensions.InitializationElement();
        }
       
        public void StartGame()
        {
            //Debug.Log("StartGame");
            StartCoroutine(EndBeginSpline(splineAnimate.Duration));
        }
        IEnumerator EndBeginSpline(float timeAnimationBegin)
        {    
            ServiceLocator.GetService<PlayerState>().enabled = false;
            ServiceLocator.GetService<PlayerAnimation>().enabled = false;
            splineAnimate.GetComponent<Animator>().SetFloat("InputY",1);
            
            yield return new WaitForSeconds(timeAnimationBegin);
            ServiceLocator.GetService<PlayerState>().enabled = true;
            ServiceLocator.GetService<PlayerAnimation>().enabled = true;
            splineAnimate.GetComponent<Animator>().SetFloat("InputY",0);
            splineAnimate.GetComponent<PlayerController>().enabled = true;
            
            questManager.ActivateQuest("Quest1");

        }
        public void EndGame()
        {
            Debug.Log("EndGame");   
        }
    }
}
