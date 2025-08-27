using System;
using MyUnityPackage.Interactions;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace Showcase
{
    public class InteractableLight : AInteractable
    {
        bool isOn;
        [SerializeField] Light light;

        public static event Action OnLightOn;
        protected override void Init()
        {
           isOn = false;
           onInteractAction += InteractLight;
        }

        private void InteractLight()
        {
            OnLightOn?.Invoke();
            isOn = !isOn;
            light.enabled = isOn;
            MyUnityPackage.Toolkit.Logger.LogMessageWarningEditor("Interact ligth : " + isOn);
        }

        
    }

}
