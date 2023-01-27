using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtistCall : MonoBehaviour
{
    private string text = "Это Кристина Крейл. В доме что-то странное. Я наняла вас расследовать пропажу красок, но боюсь дело сложнее. Я не сумасшедшая, но все картины, вся мебель, стены, все стало черно-белым. Я так понимаю вы уже прибыли на место и сами все видите. Мне страшно, сегодня я переночую в мастерской музея";
    private CallState state;
    private static bool buttonsIsBlocked;
    public GameObject audio;

    void Start()
    {
        audio.GetComponent<AudioSource>().enabled = true;
        state = CallState.ring;
        buttonsIsBlocked = false;
        UIController.SetAnswersText("Принять звонок");
    }

    void Update()
    {
        if (buttonsIsBlocked || state == CallState.stop) return;
        if (state == CallState.ring)
        {

                UIController.SetAnswersText("Принять звонок");
            if (InputController.GetAnswer(false) == 0)
            {
                state = CallState.listen;
                UIController.RemoveText();
                StartCoroutine(BlockButtons(0.5f));
                return;
            }
 
        }
        if (state == CallState.listen)
        {
            audio.GetComponent<AudioSource>().enabled = false;
            UIController.SetCenterTextWithAnswer(text, "Положить трубку");
            if (InputController.GetAnswer(false) == 0)
            {
                state = CallState.stop;
                UIController.RemoveText();
                StartCoroutine(BlockButtons(0.5f));
                GameController.StartGame();
            }
        }
    }




    private IEnumerator BlockButtons(float wait)
    {
        buttonsIsBlocked = true;
        yield return new WaitForSeconds(wait);
        buttonsIsBlocked = false;
    }
}

enum CallState
{
    ring,
    listen,
    stop
}