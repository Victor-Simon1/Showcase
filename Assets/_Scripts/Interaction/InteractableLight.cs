using System;
using MyUnityPackage.Interactions;
using UnityEngine;
using MyUnityPackage.Toolkit;

namespace Showcase
{
    /// <summary>
    /// An interactable light that can be toggled on/off by player interaction.
    /// </summary>
    /// <remarks>
    /// This class extends AInteractable to provide light switching functionality.
    /// When the player interacts with this object, it toggles the light state and
    /// fires a global event that other systems can listen to.
    /// </remarks>
    public class InteractableLight : AInteractable
    {
        /// <summary>
        /// The current state of the light (true = on, false = off).
        /// </summary>
        bool isOn;
        
        /// <summary>
        /// The Unity Light component that will be toggled on/off.
        /// </summary>
        [SerializeField] Light lightComponent;

        /// <summary>
        /// Global event fired when the light is turned on.
        /// Other systems can subscribe to this event to react to light state changes.
        /// </summary>
        public static event Action OnLightOn;
        
        /// <summary>
        /// Initializes the interactable light component.
        /// Sets up the initial state and registers the interaction callback.
        /// </summary>
        protected override void Init()
        {
           isOn = false;
           onInteractAction += InteractLight;
        }

        /// <summary>
        /// Handles the light interaction logic.
        /// Toggles the light state, updates the Unity Light component, and fires the OnLightOn event.
        /// </summary>
        private void InteractLight()
        {
            OnLightOn?.Invoke();
            isOn = !isOn;
            lightComponent.enabled = isOn;
            MUPLogger.Info("Interact ligth : " + isOn);
        }

        
    }

}
