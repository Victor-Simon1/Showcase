using System;
using MyUnityPackage.Controller;
using MyUnityPackage.Interactions;
using MyUnityPackage.Toolkit;
using Showcase;
using UnityEngine;


namespace Showcase
{
    public class KeyboardVillagerInteraction : AInteractionTrigger
    {
        public override event Action onEnter;
        public override event Action onExit;
        public override event Action onInteract;

        public PNJ pnj;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ServiceLocator.GetService<PlayerActions>().OnPressInteract += OnInteract;
        }

        void OnInteract()
        {
            onInteract?.Invoke();
            MyUnityPackage.Toolkit.Logger.LogMessage("Interaction avec un villageois ! ");
            ServiceLocator.GetService<UI_Game>().ShowDialog(this);
            ServiceLocator.GetService<PlayerController>().enabled = false;
            ServiceLocator.GetService<PlayerController>().gameObject.GetComponent<PlayerAnimation>().enabled = false;
        }
    }
}

