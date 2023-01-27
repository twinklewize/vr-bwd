using UnityEngine;

[System.Serializable]
public class QuestItemController : MonoBehaviour
{
    public string key;

    private void OnTriggerStay(Collider other)
    {
        if (DialogueController.state != DialogueState.none)
        {
            return;
        }

        Quest quest = QuestController.GetQuest(key);
        if (quest.pickingIsActive && other.CompareTag("Player"))
        {
            UIController.SetPickItemText();
            if (InputController.PickItem())
            {
                quest.Pick();
                DialogueController.GetDialogueByQuestKey(key).SetQuestSucceeded();
                Destroy(gameObject);
                UIController.RemoveText();
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (DialogueController.state != DialogueState.none || GameController.state == GameState.call)
        {
            return;
        }
        UIController.RemoveText();
    }
}
