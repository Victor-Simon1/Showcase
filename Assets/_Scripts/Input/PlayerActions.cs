using MyUnityPackage.Controller;
using UnityEngine;
using UnityEngine.InputSystem;
using Logger =  MyUnityPackage.Toolkit.Logger;

using PlayerInputManager = MyUnityPackage.Controller.PlayerInputManager;

namespace Showcase
{
    [DefaultExecutionOrder(-2)]
    public class PlayerActions : MonoBehaviour,PlayerControls.IPlayerActionsActions
    {

        PlayerInteract playerInteract;


        void Awake()
        {
            playerInteract = GetComponent<PlayerInteract>();   
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

        public void OnAttack(InputAction.CallbackContext context)
        {
            //throw new System.NotImplementedException();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if(!context.performed)
                return;
            Logger.LogMessage("Interact press");
            playerInteract.Interact();
        }

        public void OnNewaction(InputAction.CallbackContext context)
        {
            //throw new System.NotImplementedException();
        }

    }

}
