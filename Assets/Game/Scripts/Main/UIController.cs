using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private static GameObject centerText;
    private static GameObject bottomText;

    void Start()
    {
        centerText = GameObject.FindWithTag("CenterText");
        bottomText = GameObject.FindWithTag("BottomText");
    }

    public static void SetCenterTextWithAnswer(string center, string answer)
    {
        string text = center;
        text = text + "\n\nA. " + answer;

        centerText.GetComponent<TextMeshProUGUI>().text = text;
    }

    public static void SetExitText()
    {
        bottomText.GetComponent<TextMeshProUGUI>().text = "";
        centerText.GetComponent<TextMeshProUGUI>().text = "Нажмите A, чтобы выйти";
    }

    public static void SetAnswersText(string first, string second = "")
    {
        string text = "A. " + first;

        if (second != "") text = text + "\nB. " + second;

        bottomText.GetComponent<TextMeshProUGUI>().text = text;
        centerText.GetComponent<TextMeshProUGUI>().text = "";
    }

    public static void SetPickItemText()
    {
        bottomText.GetComponent<TextMeshProUGUI>().text = "";
        centerText.GetComponent<TextMeshProUGUI>().text = "Нажмите A, чтобы подобрать";
    }

    public static void SetStartDialogueText()
    {
        bottomText.GetComponent<TextMeshProUGUI>().text = "";
        centerText.GetComponent<TextMeshProUGUI>().text = "Нажмите A для диалога";
    }

    public static void RemoveText()
    {
        bottomText.GetComponent<TextMeshProUGUI>().text = "";
        centerText.GetComponent<TextMeshProUGUI>().text = "";
    }
}
