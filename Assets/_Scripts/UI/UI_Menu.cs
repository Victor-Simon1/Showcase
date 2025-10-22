using UnityEngine;
using MyUnityPackage.Toolkit;
using UnityEngine.Splines;
using UnityEngine.Playables;
using PixelCrushers.DialogueSystem;
using MyUnityPackage.Controller;
using System.Collections;

namespace Showcase
{
    public class UI_Menu : UI_Base
    {

        [SerializeField] SplineAnimate splineAnimate;
        void Start()
        {
            DialogueManager.SetLanguage(Localization.GetLanguage(SystemLanguage.French ));
            I2.Loc.LocalizationManager.CurrentLanguage = Localization.GetLanguage(SystemLanguage.French );
            
            ServiceLocator.AddService<UI_Menu>(gameObject);
            UIManager.AddCanvasUI<UI_Menu>(gameObject);
        }

        public void OnPlayButton()
        {
            ServiceLocator.GetService<UI_Manager>().StartUI();
            //StartCoroutine(EndBeginSpline(splineAnimate.Duration));
            ServiceLocator.GetService<GameManager>().StartGame();
            splineAnimate.Play();
        }

       
    }
}

