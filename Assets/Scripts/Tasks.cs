using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

[CreateAssetMenu(menuName = "Task/Tasks")]
public class Tasks : ScriptableObject
{
    [Header("Task Info")]
    public string taskID;
    public string taskName;
    public string taskDescription;
    public List<TaskObjective> objectives;

    public void OnValidate()
    {
        if (string.IsNullOrEmpty(taskID))
        {
            taskID = taskName + Guid.NewGuid().ToString(); 
        }
    }

}

[System.Serializable]
public class TaskObjective
{
    [Header("Objective Description")]
    public string objectiveID;
    public string descripton;
    public ObjectiveType type;

    [Header("Amounts")]
    public int requiredAmount;
    public int currentAmount;

    public bool isCompleted => currentAmount >= requiredAmount;
}

[System.Serializable]
public enum ObjectiveType
{
    CollectItem,
    ReachLocation,
    TalkNPC,
    Custom
}

[System.Serializable]
public class TaskProgress
{
    public Tasks task;
    public List<TaskObjective> objectives;

    public TaskProgress(Tasks task)
    {
        this.task = task;
        objectives = new List<TaskObjective>();

        foreach (var obj in task.objectives)
        {
            objectives.Add(new TaskObjective
            {
                objectiveID = obj.objectiveID,
                descripton = obj.descripton,
                type = obj.type,
                requiredAmount = obj.requiredAmount,
                currentAmount = 0
            });
      
        }

    }

    public bool isCompleted => objectives.TrueForAll(o => o.isCompleted);
    public string TaskID => task.taskID;


}