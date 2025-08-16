using System;
using UnityEngine;
using MyUnityPackage.Toolkit;
namespace Showcase
{
    public enum PNJ
    {
        Mayor,
    }

    public class PNJTalk : MonoBehaviour,IInteractable
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
            ServiceLocator.GetService<UI_Game>().ShowDialog(this);
        }
    }
}

