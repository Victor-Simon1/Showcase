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

    }
}


