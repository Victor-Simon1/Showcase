using MyUnityPackage.Interactions;
using MyUnityPackage.Toolkit;

/// <summary>
/// Displays a villager's name when the player enters an interaction zone.
/// </summary>
/// <remarks>
/// Works with the interactions framework by overriding lifecycle callbacks on <c>AEffect</c>.
/// On enter, it resolves a <c>VillagerNameUI</c> and shows the
/// configured name; on exit, it hides the UI. Use this on an interactable that represents a villager.
/// </remarks>
public class NameEffect : AEffect
{
    /// <summary>
    /// The display name to show in the UI for the current villager.
    /// </summary>
    public string VillagerName{get;set;}
    public override void OnDisable(){}

    public override void OnEnable(){}

    /// <summary>
    /// Shows the villager name UI when the player enters the interaction zone.
    /// </summary>
    public override void OnEnter()
    {
         ServiceLocator.GetService<VillagerNameUI>().Show(VillagerName);
    }

    /// <summary>
    /// Hides the villager name UI when the player exits the interaction zone.
    /// </summary>
    public override void OnExit()
    {
        ServiceLocator.GetService<VillagerNameUI>().Hide();
    }

    public override void OnInteract(){}


}
