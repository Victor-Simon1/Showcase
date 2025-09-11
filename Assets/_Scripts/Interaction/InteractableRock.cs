using MyUnityPackage.Interactions;
using System;

namespace Showcase
{
    public class InteractableRock : AInteractable
    {
        public static event Action OnRockGet;
        protected override void Init()
        {
            onInteractAction += InteractWood;
        }

        void InteractWood()
        {
            OnRockGet?.Invoke();
            EndInteraction();
        }
    }
}

