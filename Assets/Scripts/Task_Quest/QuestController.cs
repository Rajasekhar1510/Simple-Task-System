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
        InventoryController.Instance.OnInventoryChanged += CheckInventoryForQuests;
    }

    public void AcceptQuest(Tasks task)
    {
        if (IsQuestActive(task.taskID)) return;

        activeQuests.Add(new TaskProgress(task));

        questUI.UpdateTaskUI();
    }

    public bool IsQuestActive(string questID) => activeQuests.Exists(q => q.TaskID == questID);

    public void CheckInventoryForQuests()
    {
        Dictionary<int, int> itemCounts = InventoryController.Instance.GetItemCounts();

        foreach (TaskProgress task in activeQuests)
        {
            foreach (TaskObjective taskObjective in task.objectives)
            {
                if(taskObjective.type != ObjectiveType.CollectItem) continue;
                if(!int.TryParse(taskObjective.objectiveID, out int itemId)) continue;

                int newAmount = itemCounts.TryGetValue(itemId, out int count ) ? Mathf.Min(count, taskObjective.requiredAmount) : 0;

                if (taskObjective.currentAmount != newAmount)
                {
                    taskObjective.currentAmount = newAmount;
                }
            }
        }

        questUI.UpdateTaskUI() ;
    }
}
