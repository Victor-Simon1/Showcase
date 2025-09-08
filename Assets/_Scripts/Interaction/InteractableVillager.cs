using System;
using MyUnityPackage.Interactions;
using MyUnityPackage.Toolkit;
using PixelCrushers.DialogueSystem;
using UnityEngine;



namespace Showcase
{
    public enum PNJ
    {
        Mayor,
        Carpenter,
        Blacksmith,
    }
    public class InteractableVillager : AInteractable
    {
        public PNJ pnj;

        public static event Action<PNJ> OnTalkPNJ;
        [SerializeField] DialogueSystemTrigger dsTrigger;
        protected override void Init()
        {
            MyUnityPackage.Toolkit.Logger.LogMessageEditor("INIT VILLAGER");
            onInteractAction += InteractVillager;
            dsTrigger = GetComponent<DialogueSystemTrigger>();
        }
        public static bool OnTalkPnjIsNull()
        {
            return OnTalkPNJ == null;
        }
        private void InteractVillager()
        {
            MyUnityPackage.Toolkit.Logger.LogMessage("Interaction avec un villageois ! ");
            OnTalkPNJ?.Invoke(pnj);
            //DialogueSystemTrigger dialog;
            DialogueManager.StartConversation(dsTrigger.conversation , ServiceLocator.GetService<PlayerActions>().transform, transform);
            //ServiceLocator.GetService<UI_Game>().ShowDialog(this);
            //ServiceLocator.GetService<PlayerController>().enabled = false;
            //ServiceLocator.GetService<PlayerController>().gameObject.GetComponent<PlayerAnimation>().enabled = false;
           
            
            //Si derniere dialog
            EndInteraction();
        }
    }
}

