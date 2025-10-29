using EPOOutline;
using MyUnityPackage.Interactions;
using MyUnityPackage.Toolkit;
using UnityEngine;

/// <summary>
/// Provides visual outline effects for interactive objects using the EPO Outline system.
/// This effect automatically enables/disables object outlines when players enter or exit interaction zones.
/// </summary>
/// <remarks>
/// The OutlinerEffect is designed to work with the MyUnityPackage.Interactions system and provides
/// visual feedback to players by highlighting interactive objects with outlines. It integrates with
/// the EPO Outline package to create smooth, customizable outline effects.
/// </remarks>

public class OutlinerEffect : AEffect
{
    /// <summary>
    /// The Outlinable component that handles the visual outline rendering.
    /// This should be assigned in the inspector to the target object that needs outlining.
    /// </summary>
    [SerializeField] Outlinable outlinable;

    /// <summary>
    /// Called when the effect is disabled. Disables the outline to ensure no visual artifacts remain.
    /// </summary>
    public override void OnDisable()
    {
        outlinable.enabled = false;
    }

    public override void OnEnable()
    {
        //outlinable.enabled = true;
    }

    /// <summary>
    /// Called when the player enters the interaction zone. Enables the outline effect.
    /// </summary>
    public override void OnEnter()
    {
        //MUPLogger.Info("Je rentre dans la zone");
        outlinable.enabled = true;
    }

    /// <summary>
    /// Called when the player exits the interaction zone. Disables the outline effect.
    /// </summary>
    public override void OnExit()
    {
        //MUPLogger.Info("Je sors de la zone");
        outlinable.enabled = false;
    }

    public override void OnInteract()
    {

    }
}
