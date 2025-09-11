using System;
using MyUnityPackage.Controller;
using MyUnityPackage.Toolkit;
using UnityEngine;
using UnityEngine.InputSystem;

using PlayerInputManager = MyUnityPackage.Controller.PlayerInputManager;

namespace Showcase
{
    [DefaultExecutionOrder(-2)]
    public class PlayerActions : MonoBehaviour,PlayerControls.IPlayerActionsActions
    {

        public event Action OnPressInteract;
        void Awake()
        {
            ServiceLocator.AddService<PlayerActions>(gameObject);
        }
        void OnEnable()
        {
            if(PlayerInputManager.Instance.PlayerControls == null)
            {
                Debug.Log("Players controls is not set !");
                return;
            }
            PlayerInputManager.Instance.PlayerControls.PlayerActions.Enable();
            PlayerInputManager.Instance.PlayerControls.PlayerActions.SetCallbacks(this);
        }
        void OnDisable()
        {
            if(PlayerInputManager.Instance.PlayerControls == null)
            {
                Debug.Log("Players controls is not set !");
                return;
            }
            PlayerInputManager.Instance.PlayerControls.PlayerActions.Disable();
            PlayerInputManager.Instance.PlayerControls.PlayerActions.RemoveCallbacks(this);
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if(!context.performed)
                return;
            MUPLogger.LogMessage("Interact press");
            OnPressInteract.Invoke();
        }


    }

}
