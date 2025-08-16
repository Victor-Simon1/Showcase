using UnityEngine;
using MyUnityPackage.Toolkit;
using UnityEngine.UI;

namespace Showcase
{
    public class UI_Menu : UI_Base
    {
        [SerializeField] private Button buttonPlay;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ServiceLocator.AddService<UI_Menu>(gameObject);

            UIManager.AddCanvasUI<UI_Menu>(gameObject);
            buttonPlay.onClick.AddListener(OnButtonPlayClick);
        }

        private void OnButtonPlayClick()
        {
            Debug.Log("OnButtonPlayClick");

            //BUG
            //UIManager.PlayTransitionByName(UIManager.GetCanvasUI<UI_Menu_>().gameObject, "FadeOut");
            //UIManager.PlayTransitionByName(UIManager.GetCanvasUI<UI_Game>().gameObject, "FadeIn");
            
            ServiceLocator.GetService<UI_Manager>().HideUI();
        }
    }
}

