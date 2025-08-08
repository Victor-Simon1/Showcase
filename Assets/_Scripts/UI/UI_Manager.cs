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

    public static UI_Manager Instance { get; private set;}

    void Awake()
    {
        if(Instance != null)
            Logger.LogMessageWarningEditor("UIManager already exist");
        Instance = this;
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
    public static void ShowUI()
    {
        Logger.LogMessage("ShowUI");
        Instance.UIMenuCanvasHelper.Show();
        Instance.PlayerMovementInput.enabled = false;
    }

    public static void HideUI()
    {
        Logger.LogMessage("HideUI");
        Instance.UIMenuCanvasHelper.Hide();
        Instance.PlayerMovementInput.enabled = true;
    }
}
