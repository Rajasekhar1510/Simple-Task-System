using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class QuestController : MonoBehaviour
{
    public static QuestController Instance { get; private set; }
    public List<TaskProgress> activeQuests = new();
    private TaskUI questUI;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        questUI = FindObjectOfType<TaskUI>();
    }

    public void AcceptQuest(Tasks task)
    {
        if (IsQuestActive(task.taskID)) return;

        activeQuests.Add(new TaskProgress(task));

        questUI.UpdateTaskUI();
    }

    public bool IsQuestActive(string questID) => activeQuests.Exists(q => q.TaskID == questID);
}
