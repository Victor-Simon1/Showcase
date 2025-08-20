using UnityEngine;
using MyUnityPackage.Toolkit;
using UnityEngine.Splines;
using UnityEngine.Playables;

namespace Showcase
{
    public class UI_Menu : UI_Base
    {

        [SerializeField] SplineAnimate splineAnimate;
        [SerializeField] PlayableDirector timelineEntrance;
        void Start()
        {
            ServiceLocator.AddService<UI_Menu>(gameObject);
            UIManager.AddCanvasUI<UI_Menu>(gameObject);
        }

        public void StartGame()
        {
            ServiceLocator.GetService<UI_Manager>().StartUI();
            timelineEntrance.Play();
            splineAnimate.Play();
           
        }
    }
}

