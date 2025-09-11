using UnityEngine;
using MyUnityPackage.Controller;
using UnityEngine.InputSystem;
using MyUnityPackage.Toolkit;

using PlayerInputManager = MyUnityPackage.Controller.PlayerInputManager;

namespace Showcase
{
    public class UI_Manager : MonoBehaviour, PlayerControls.IUIActions
    {
        [SerializeField] private CanvasHelper UIMenuCanvasHelper;
        [SerializeField] private CanvasHelper UIGameCanvasHelper;
        [SerializeField] private CanvasHelper UISettingsCanvasHelper;
        [SerializeField] private PlayerMovementInput PlayerMovementInput;

        void Awake()
        {
            ServiceLocator.AddService<UI_Manager>(gameObject);
        }
        void OnEnable()
        {
            PlayerInputManager.Instance.PlayerControls.UI.Enable();
            PlayerInputManager.Instance.PlayerControls.UI.SetCallbacks(this);
        }
        void OnDiable()
        {
            PlayerInputManager.Instance.PlayerControls.UI.Disable();
            PlayerInputManager.Instance.PlayerControls.UI.RemoveCallbacks(this);
        }
        public void OnShow(InputAction.CallbackContext context)
        {
            if(!context.performed)
                return;
            MUPLogger.LogMessage("OnShow");
            if(!UIMenuCanvasHelper.Canvas.enabled)
            {
                ShowUI();
            }
            else
            {
                HideUI();
            }
                
        }

        public void StartUI()
        {
            UIGameCanvasHelper.Show();
            UIMenuCanvasHelper.Hide();
            
            Cursor.lockState = CursorLockMode.Locked;
        }
        public void ShowUI()
        {
            MUPLogger.LogMessage("ShowUI");
            UISettingsCanvasHelper.Show();
            UIGameCanvasHelper.Hide();
            //Replace with function cut all move/interaction
            PlayerMovementInput.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }

        public void HideUI()
        {
            MUPLogger.LogMessage("HideUI");
            UIGameCanvasHelper.Show();
            UISettingsCanvasHelper.Hide();
            //Replace with function cut all move/interaction
            PlayerMovementInput.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

