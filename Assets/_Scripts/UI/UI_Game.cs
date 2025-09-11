using UnityEngine;
using UnityEngine.UI;
using MyUnityPackage.Toolkit;
using MyUnityPackage.ProgressionSystem;
using TMPro;

namespace Showcase
{
    public class UI_Game : UI_Base
    {
        [SerializeField] private Button buttonBack;
        QuestManager questManager;

        [SerializeField] private GameObject dialogGO;
       
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ServiceLocator.AddService<UI_Game>(gameObject);
            //questManager = QuestManager;
            //UIManager.AddCanvasUI<UI_Game>(gameObject);
            //buttonBack.onClick.AddListener(OnButtonBackClick);
        }
        //TODO Get Active Quest
        void UpdateQuestPanel()
        {

        }

        public void ShowDialog(InteractableVillager pNJTalk)
        {
            dialogGO.SetActive(true);
            dialogGO.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = pNJTalk.pnj.ToString();
        }
        public void HideDialog()
        {
            dialogGO.SetActive(false);
        }
        /*private void OnButtonBackClick()
        {
            Debug.Log("OnButtonBackClick");
            UIManager.PlayTransitionByName(UIManager.GetCanvasUI<UI_Game>().gameObject, "FadeOut");
            UIManager.PlayTransitionByName(UIManager.GetCanvasUI<UI_Menu>().gameObject, "FadeIn");
        }*/
    }
}


