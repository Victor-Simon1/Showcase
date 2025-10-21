using TMPro;
using UnityEngine;

public class VillagerNameUI : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private TextMeshProUGUI nameText;

    public void Show(string name)
    {
        nameText.text = name;
        container.SetActive(true);
    }
    public void Hide()
    {
        container.SetActive(false);
    }
}
