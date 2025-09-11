using System;
using UnityEngine;
using MyUnityPackage.Toolkit;
using MyUnityPackage.Controller;

namespace Showcase
{
    public class PNJTalk : MonoBehaviour
    {
        public PNJ pnj;

        public static event Action<PNJ> TalkAction;

        public string GetInteractText()
        {
            throw new NotImplementedException();
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void Interact(Transform interactor)
        {
           // ServiceLocator.GetService<UI_Game>().ShowDialog(this);
            ServiceLocator.GetService<PlayerController>().enabled = false;
            ServiceLocator.GetService<PlayerController>().gameObject.GetComponent<PlayerAnimation>().enabled = false;
        }
    }
}

