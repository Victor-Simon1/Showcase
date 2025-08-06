using UnityEngine;
using MyUnityPackage.Controller;
using UnityEngine.InputSystem;
using MyUnityPackage.Toolkit;

using PlayerInputManager = MyUnityPackage.Controller.PlayerInputManager;
using Logger = MyUnityPackage.Toolkit.Logger;
public class UI_Manager : MonoBehaviour, PlayerControls.IUIActions
{
    [SerializeField] private CanvasHelper UIMenuCanvasHelper;
    [SerializeField] private PlayerMovementInput PlayerMovementInput;
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
        Logger.LogMessage("OnShow");
        if(!UIMenuCanvasHelper.Canvas.enabled)
        {
            UIMenuCanvasHelper.Show();
            PlayerMovementInput.enabled = false;
        }
        else
        {
            UIMenuCanvasHelper.Hide();
            PlayerMovementInput.enabled = true;
        }
            
    }
}
