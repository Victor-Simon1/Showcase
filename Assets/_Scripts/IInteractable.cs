using UnityEngine;


namespace Showcase
{
    public interface IInteractable 
    {
        void Interact(Transform interactor);
        string GetInteractText();
        Transform GetTransform();
    }
}

