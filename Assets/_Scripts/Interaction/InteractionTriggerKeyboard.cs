using System;
using MyUnityPackage.Controller;
using MyUnityPackage.Interactions;
using MyUnityPackage.Toolkit;
using Showcase;
using UnityEngine;


namespace Showcase
{
    
    public class InteractionTriggerKeyboard : AInteractionTrigger
    {
        public override event Action onEnter;
        public override event Action onExit;
        public override event Action onInteract;

        

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ServiceLocator.GetService<PlayerActions>().OnPressInteract += OnInteract;
        }

        void OnInteract()
        {
            MyUnityPackage.Toolkit.Logger.LogMessageEditor("Press InteractionTrigger");
            onInteract?.Invoke();
        }
    }
}

