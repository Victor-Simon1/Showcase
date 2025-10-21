using MyUnityPackage.Interactions;
using System;
using MyUnityPackage.Toolkit;

namespace Showcase
{
    /// <summary>
    /// An interactable wood that can be collected by the player.
    /// </summary>
    /// <remarks>
    /// This class extends AInteractable to provide wood collection functionality.
    /// When the player interacts with this object, it logs the collection, fires a global event,
    /// and ends the interaction sequence. This is typically used for collectible wood resources
    /// in the game world.
    /// </remarks>
    public class InteractableWood : AInteractable
    {
        /// <summary>
        /// Global event fired when the wood is collected.
        /// Other systems can subscribe to this event to react to wood collection.
        /// </summary>
        public static event Action OnWoodGet;
        
        /// <summary>
        /// Initializes the interactable wood component.
        /// Sets up the interaction callback for wood collection.
        /// </summary>
        protected override void Init()
        {
            onInteractAction += InteractWood;
        }

        /// <summary>
        /// Handles the wood collection interaction.
        /// Logs the collection, fires the OnWoodGet event, and ends the interaction sequence.
        /// </summary>
        void InteractWood()
        {
            MUPLogger.Info("Get Wood");
            OnWoodGet?.Invoke();
            EndInteraction();
        }
    }
}

