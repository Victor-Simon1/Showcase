using System.Collections.Generic;
using UnityEngine;

namespace Showcase
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] float interactRange = 2f;
        public void Interact()
        {    
            IInteractable interactable = GetInteractableObject();
            if(interactable != null)
                interactable.Interact(transform);
        }

        private IInteractable GetInteractableObject()
        {
            List<IInteractable> interactablesList = new List<IInteractable>();
            
            Collider[] colliderArray = Physics.OverlapSphere(transform.position,interactRange);
            foreach (Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out IInteractable interactable))
                {
                    interactablesList.Add(interactable);
                }
            }

            IInteractable closestInteractable = null;
            foreach (IInteractable interactable in interactablesList)
            {
                if(closestInteractable == null)
                    closestInteractable = interactable;
                else
                {
                    if(Vector3.Distance(transform.position,interactable.GetTransform().position)
                        < Vector3.Distance(transform.position,interactable.GetTransform().position))
                        closestInteractable = interactable;
                }
            }
            return closestInteractable;
        }
    }
}

