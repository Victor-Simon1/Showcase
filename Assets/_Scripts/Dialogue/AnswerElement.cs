using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerElement : MonoBehaviour
{
    [SerializeField] private Image colorBG;
    [SerializeField] private Image answerColor;
    [SerializeField] private GameObject filterBG;
    [SerializeField] private TextMeshProUGUI letterText;
    [SerializeField] private TextMeshProUGUI answerText;

    public bool isCorrectAnswer = false;

   public void UpdateAnswerUI(string letter, Color letterColor, Color color)
   {
        answerColor.color = color;
        letterText.text = letter;
        letterText.color = letterColor;
   }

    public void SetBGColor(Color color, Color colorText)
    {
        colorBG.color = color;
        answerText.color = colorText;
    }

    public void SelectAnswer(bool isSelect)
    {
        filterBG.SetActive(isSelect);
    }
}
