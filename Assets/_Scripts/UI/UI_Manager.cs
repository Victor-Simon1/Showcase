using UnityEngine;
using MyUnityPackage.Controller;
using UnityEngine.InputSystem;
using MyUnityPackage.Toolkit;

using PlayerInputManager = MyUnityPackage.Controller.PlayerInputManager;
using Logger = MyUnityPackage.Toolkit.Logger;
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
            Logger.LogMessage("OnShow");
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
        }
        public void ShowUI()
        {
            Logger.LogMessage("ShowUI");
            UISettingsCanvasHelper.Show();
            UIGameCanvasHelper.Hide();
            //Replace with function cut all move/interaction
            PlayerMovementInput.enabled = false;
        }

        public void HideUI()
        {
            Logger.LogMessage("HideUI");
            UIGameCanvasHelper.Show();
            UISettingsCanvasHelper.Hide();
            //Replace with function cut all move/interaction
            PlayerMovementInput.enabled = true;
        }
    }
}

