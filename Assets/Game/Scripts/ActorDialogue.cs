using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActorDialogue : MonoBehaviour
{
    public string actor;
    public GameObject actorText;
    public GameObject actorCanvas;
    private Dialogue dialogue;

    private void OnTriggerStay(Collider other)
    {
        SuggestStartDialogue(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (DialogueController.isSuggesting(actor))
        {
            DialogueController.Stop();
            UIController.RemoveText();
        }
    }

    void SuggestStartDialogue(Collider other)
    {
        if (!DialogueController.Suggest() || !other.CompareTag("Player"))
        {
            return;
        }
 
            DialogueController.SuggestStart(actor);
            UIController.SetStartDialogueText();
    }

    void StartDialogue()
    {
        actorCanvas.GetComponent<Canvas>().enabled = true;
        dialogue.Start();
        UpdateUI();
    }

    void StopDialogue()
    {
        UIController.RemoveText();
        actorCanvas.GetComponent<Canvas>().enabled = false;
    }


    void UpdateUI()
    {
        DialogueStep step = dialogue.GetCurrentStep();
        if (step == null)
        {
            StopDialogue();
            return;
        }

        bool severalOptions = step.answers.Length == 2;

        UIController.SetAnswersText(step.answers[0].text, severalOptions ? step.answers[1].text : "");
        actorText.GetComponent<TextMeshProUGUI>().text = step.text;
    }

    void ListenAnswer()
    {
        DialogueStep step = dialogue.GetCurrentStep();
        bool withSecond = step.answers.Length == 2;
        
        int answerIndex = InputController.GetAnswer(withSecond);
        if (answerIndex == -1)
        {
            return;
        }
        StartCoroutine(BlockButtons());


        DialogueAnswer answer = step.answers[answerIndex];
        if (answer.action == DialogueAnswerAction.startQuest)
        {
            QuestController.GetQuest(answer.quest).Start();
        }
        else if (answer.action == DialogueAnswerAction.finishQuest)
        {
            QuestController.GetQuest(answer.quest).Finish();
            if (answer.quest == "Glasses") GlassesController.SetActive();
        }
        else if (answer.action == DialogueAnswerAction.win)
        {
            GameController.Win();
        }
        else if (answer.action == DialogueAnswerAction.lose)
        {
            GameController.Lose();
        }

        dialogue.Next(answer.nextSequence, answer.nextStep);
        UpdateUI();
    }


    void Start()
    {
        actorCanvas.GetComponent<Canvas>().enabled = false;
        dialogue = DialogueController.GetDialogue(actor);
    }

    private void Update()
    {
        if (buttonsIsBlocked)
        {
            return;
        }
        if (DialogueController.isSuggesting(actor) )
        {
            if (InputController.StartDialogue())
            {
                StartCoroutine(BlockButtons());
                StartDialogue();
            }
         
        } else if (DialogueController.isActive(actor))
        {
            ListenAnswer();
        }
    }

    private static bool buttonsIsBlocked = false;

    private IEnumerator BlockButtons()
    {
        buttonsIsBlocked = true;
        yield return new WaitForSeconds(1.0F);
        buttonsIsBlocked = false;
    }
}
