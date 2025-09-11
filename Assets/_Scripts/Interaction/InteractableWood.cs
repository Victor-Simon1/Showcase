using MyUnityPackage.Interactions;
using System;
using MyUnityPackage.Toolkit;

namespace Showcase
{
    public class InteractableWood : AInteractable
    {
        public static event Action OnWoodGet;
        protected override void Init()
        {
            onInteractAction += InteractWood;
        }

        void InteractWood()
        {
            MUPLogger.LogMessageEditor("Get Wood");
            OnWoodGet?.Invoke();
            EndInteraction();
        }
    }
}

