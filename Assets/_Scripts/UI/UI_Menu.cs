using UnityEngine;
using MyUnityPackage.Toolkit;
using UnityEngine.UI;

public class UI_Menu : UI_Base
{
    [SerializeField] private Button buttonPlay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIManager.AddCanvasUI<UI_Menu_>(gameObject);
        buttonPlay.onClick.AddListener(OnButtonPlayClick);

    }

    private void OnButtonPlayClick()
    {
        Debug.Log("OnButtonPlayClick");
        UIManager.PlayTransitionByName(UIManager.GetCanvasUI<UI_Menu_>().gameObject, "FadeOut");
        UIManager.PlayTransitionByName(UIManager.GetCanvasUI<UI_Game>().gameObject, "FadeIn");
        UI_Manager.HideUI();
    }
}
