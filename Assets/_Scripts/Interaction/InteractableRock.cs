using MyUnityPackage.Interactions;
using System;

namespace Showcase
{
    /// <summary>
    /// An interactable rock that can be collected by the player.
    /// </summary>
    /// <remarks>
    /// This class extends AInteractable to provide rock collection functionality.
    /// When the player interacts with this object, it fires a global event and
    /// ends the interaction sequence. This is typically used for collectible items
    /// in the game world.
    /// </remarks>
    public class InteractableRock : AInteractable
    {
        /// <summary>
        /// Global event fired when the rock is collected.
        /// Other systems can subscribe to this event to react to rock collection.
        /// </summary>
        public static event Action OnRockGet;
        
        /// <summary>
        /// Initializes the interactable rock component.
        /// Sets up the interaction callback for rock collection.
        /// </summary>
        protected override void Init()
        {
            onInteractAction += InteractWood;
        }

        /// <summary>
        /// Handles the rock collection interaction.
        /// Fires the OnRockGet event and ends the interaction sequence.
        /// </summary>
        void InteractWood()
        {
            OnRockGet?.Invoke();
            EndInteraction();
        }
    }
}

