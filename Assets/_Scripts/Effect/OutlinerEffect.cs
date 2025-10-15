using EPOOutline;
using MyUnityPackage.Interactions;
using MyUnityPackage.Toolkit;
using UnityEngine;

public class OutlinerEffect : AEffect
{
    [SerializeField] Outlinable outlinable;

    public override void OnDisable()
    {
        outlinable.enabled = false;
    }

    public override void OnEnable()
    {
        //outlinable.enabled = true;
    }

    public override void OnEnter()
    {
        MUPLogger.Info("Je rentre dans la zone");
        outlinable.enabled = true;
    }

    public override void OnExit()
    {
        MUPLogger.Info("Je sors de la zone");
        outlinable.enabled = false;
    }

    public override void OnInteract()
    {

    }
}
