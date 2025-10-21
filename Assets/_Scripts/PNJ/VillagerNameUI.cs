using TMPro;
using UnityEngine;

/// <summary>
/// UI component that displays villager names when the player is near them.
/// </summary>
/// <remarks>
/// This component manages the display of villager names in the game world.
/// It works in conjunction with the NameEffect to show/hide villager names
/// based on player proximity to interactable villagers.
/// </remarks>
public class VillagerNameUI : MonoBehaviour
{
    /// <summary>
    /// The container GameObject that holds the name display UI elements.
    /// This is shown/hidden to control the visibility of the villager name.
    /// </summary>
    [SerializeField] private GameObject container;
    
    /// <summary>
    /// The TextMeshPro component that displays the villager's name.
    /// This text is updated when showing a villager's name.
    /// </summary>
    [SerializeField] private TextMeshProUGUI nameText;

    /// <summary>
    /// Shows the villager name UI with the specified name.
    /// </summary>
    /// <param name="name">The name of the villager to display</param>
    public void Show(string name)
    {
        nameText.text = name;
        container.SetActive(true);
    }
    
    /// <summary>
    /// Hides the villager name UI.
    /// </summary>
    public void Hide()
    {
        container.SetActive(false);
    }
}
