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
            MUPLogger.Info("INIT VILLAGER");
            onInteractAction += InteractVillager;
            dsTrigger = GetComponent<DialogueSystemTrigger>();

            NameEffect nameEffect = GetComponentInChildren<NameEffect>();
            if(nameEffect != null)
                nameEffect.VillagerName = pnj.ToString();
        }
        public static bool OnTalkPnjIsNull()
        {
            return OnTalkPNJ == null;
        }
        private void InteractVillager()
        {
            MUPLogger.Info("Interaction avec un villageois ! ");
            OnTalkPNJ?.Invoke(pnj);
            DialogueManager.StartConversation(dsTrigger.conversation , ServiceLocator.GetService<PlayerActions>().transform, transform);

            //Si derniere dialog
            EndInteraction();
        }
    }
}

