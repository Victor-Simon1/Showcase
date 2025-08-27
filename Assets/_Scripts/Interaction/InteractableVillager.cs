using System;
using MyUnityPackage.Interactions;
using UnityEngine;


namespace Showcase
{
    public enum PNJ
    {
        Mayor,
    }
    public class InteractableVillager : AInteractable
    {
        public PNJ pnj;

        public static event Action<PNJ> OnTalkPNJ;
        protected override void Init()
        {
            MyUnityPackage.Toolkit.Logger.LogMessageEditor("INIT VILLAGER");
            onInteractAction += InteractVillager;
        }
        public static bool OnTalkPnjIsNull()
        {
            return OnTalkPNJ == null;
        }
        private void InteractVillager()
        {
            MyUnityPackage.Toolkit.Logger.LogMessage("Interaction avec un villageois ! ");
            OnTalkPNJ?.Invoke(pnj);
            //ServiceLocator.GetService<UI_Game>().ShowDialog(this);
            //ServiceLocator.GetService<PlayerController>().enabled = false;
            //ServiceLocator.GetService<PlayerController>().gameObject.GetComponent<PlayerAnimation>().enabled = false;
            
            //Si derniere dialog
            EndInteraction();
        }
    }
}

