using I2.Loc;
using PixelCrushers.DialogueSystem;
using System.Collections;
using UnityEngine;

public class DialogueHelper : MonoBehaviour
{
    /*
    [SerializeField] private Transform answersContainer;
    [SerializeField] private GameObject validButton;
    [SerializeField] private GameObject panelFeedback;
    [SerializeField] private Animator gifImage;
    [SerializeField] private Localize feedbackText;
    [SerializeField] private GameObject nextButton;

    [SerializeField] private Color unselectedColor;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color goodColor;
    [SerializeField] private Color badColor;
    [SerializeField] private Color textColorDefault;
    [SerializeField] private Color textColor;

    private AnswerElement correctResponse;
    private AnswerElement currentResponse;
    private bool cansAnswer = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnConversationStart()
    {
        Risk currentRisk = ServiceProvider.GameManager.CurrentRisk;
        ServiceProvider.UIManager.UI_HUD.StartGame();
        validButton.SetActive(false);
        nextButton.SetActive(false);
        
    }

    public void OnConversationLine(Subtitle subtitle)
    {
        nextButton.SetActive(false);
    }

    public void OnConversationEnd()
    {
        ServiceProvider.UIManager.UI_HUD.EndGame();
        CanvasGroup[] canvasElem = answersContainer.GetComponentsInChildren<CanvasGroup>(false);
        for (int i = 0; i < canvasElem.Length; i++)
        {
            canvasElem[i].interactable = false;
            canvasElem[i].blocksRaycasts = false;
        }
    }

    public void OnConversationResponseMenu(Response[] responses)
    {
        StartCoroutine(InitUI());
    }

    public void OnClickAnswer(Transform response)
    {
        if (!cansAnswer) return;

        validButton.SetActive(true);

        AnswerElement[] answers = answersContainer.GetComponentsInChildren<AnswerElement>();

        foreach (var answer in answers)
        {
            answer.SelectAnswer(true);
        }  

        currentResponse = response.GetComponent<AnswerElement>();
        currentResponse.SelectAnswer(false);  
    }

    public void CheckAnswer()
    {
        AnswerElement[] answers = answersContainer.GetComponentsInChildren<AnswerElement>();

        panelFeedback.SetActive(false);
        if (currentResponse.isCorrectAnswer)
        {
            currentResponse.SetBGColor(goodColor, textColor);
        }
        else
        {
            currentResponse.SetBGColor(badColor, textColor);
            correctResponse.SetBGColor(goodColor, textColor);
        }

        foreach (var answer in answers)
        {
            answer.SelectAnswer(false);
        }

        nextButton.SetActive(true);     
    }

    public void ShowFeedback()
    {
        panelFeedback.SetActive(true);
        validButton.SetActive(false);
        cansAnswer = false;
        if (currentResponse.isCorrectAnswer)
        {
            gifImage.SetTrigger("success");
           // feedbackText.SetTerm("UI/feedback/good");
        }
        else
        {
            gifImage.SetTrigger("fail");         
            //feedbackText.SetTerm("UI/feedback/bad");
        }

        Invoke("CheckAnswer", 2f);
    }

    public void ContinueDialogue()
    {
        currentResponse.transform.GetComponent<StandardUIResponseButton>().OnClick();  
    }

    public IEnumerator InitUI()
    {
        yield return new WaitForEndOfFrame();
        Risk currentRisk = ServiceProvider.GameManager.CurrentRisk;
        cansAnswer = true;

        // Set up answers
        CanvasGroup[] canvasElem = answersContainer.GetComponentsInChildren<CanvasGroup>(false);
        for (int i = 0; i < canvasElem.Length; i++)
        {
            canvasElem[i].interactable = true;
            canvasElem[i].blocksRaycasts = true;
        }
        AnswerElement answer;
        AnswerElement[] responses = answersContainer.GetComponentsInChildren<AnswerElement>(false);
        correctResponse = responses[0];
        for (int i = 0; i < responses.Length; i++)
        {
            responses[i].isCorrectAnswer = false;
        }
        correctResponse.isCorrectAnswer = true;
        int nb = 0, count = 0;
        string[] letters = { "A", "B", "C", "D" };
        for (int i = 0; i < responses.Length; i++)// shuffle
        {
            nb = Random.Range(0, responses.Length);
            answersContainer.GetChild(i).SetSiblingIndex(nb);
        }
        for (int i = 0; i < answersContainer.childCount; i++)// update letters
        {
            if (answersContainer.GetChild(i).gameObject.activeSelf)
            {
                answer = answersContainer.GetChild(i).GetComponent<AnswerElement>();
                answer.UpdateAnswerUI(letters[count++], currentRisk.colorFont, currentRisk.color);
                answer.SetBGColor(unselectedColor, textColorDefault);
                answer.SelectAnswer(false);
            }
        }

    }
    */
}
