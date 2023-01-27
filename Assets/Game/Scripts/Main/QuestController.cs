using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    private static Dictionary<string, Quest> quests = new Dictionary<string, Quest>() {
        { "Brush", new Quest() },
        { "Glasses", new Quest() },

    };

    public static void CancelAll()
    {
        foreach (var quest in quests)
        {
            quest.Value.Cancel();
        }
    }

    public static Quest GetQuest(string key)
    {
        return quests[key];
    }
}


public enum QuestState
{
    notActive,
    started,
    picked,
    finished
}

public class Quest
{
    public string title { get; set; }
    public QuestState state { get; set; }

    public bool pickingIsActive
    {
        get
        {
            return state == QuestState.started;
        }
    }

    public void Start()
    {
        state = QuestState.started;
    }

    public void Pick()
    {
        state = QuestState.picked;
    }

    public void Finish()
    {
        state = QuestState.finished;
    }

    public void Cancel()
    {
        state = QuestState.notActive;
    }

    public Quest()
    {
        this.state = QuestState.notActive;
    }
}