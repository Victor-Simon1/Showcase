using MyUnityPackage.Interactions;
using UnityEngine;
using System;
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
            OnWoodGet?.Invoke();
        }
    }
}

