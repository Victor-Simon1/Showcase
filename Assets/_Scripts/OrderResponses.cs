using MyUnityPackage.Toolkit;
using UnityEngine;
using UnityEngine.UI;

public class OrderResponses : MonoBehaviour
{

    [SerializeField] GameObject[] buttons;
    
    [SerializeField] GameObject activeContainer;
    [SerializeField] GameObject unactiveContainer;

    [SerializeField]private RectTransform transformParent;

    void Start()
    {
       // transformParent = transform.parent.GetComponent<RectTransform>();
       //activeContainer.GetComponent<GridLayoutGroup>().cellSize = new Vector2(activeContainer.GetComponent<GridLayoutGroup>().cellSize.x, buttons[0].GetComponent<RectTransform>().rect.height);
    }
    public void OnOpen()
    {
        float nb_line = 0;
        foreach (var button in buttons)
        {
            if (button.gameObject.activeSelf)
            {
                button.transform.SetParent(activeContainer.transform, false);
                nb_line++;
            }
        }
        //nb_line = Mathf.Ceil(nb_line /2); 
        //Vector2 size = transformParent.sizeDelta;
        //size.y = nb_line * 100 + 50;
        //MUPLogger.Info("Size " + size);
        //transformParent.sizeDelta = size;
    }
    public void OnClose()
    {
        foreach (var button in buttons)
        {
            //if (button.gameObject.activeSelf)
            {
                button.transform.SetParent(unactiveContainer.transform, false);
            }
        }
    }
}
