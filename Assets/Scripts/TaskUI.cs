using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class TaskUI : MonoBehaviour
{
    public Transform taskListContent;
    public GameObject taskEntryPrefab;
    public GameObject objectiveTextPrefab;

    public Tasks testTask;
    public int testTaskAmount;
    private List<TaskProgress> testTasksList = new();


    void Start()
    {
        for (int i = 0; i < testTaskAmount; i++)
        {
            testTasksList.Add(new TaskProgress(testTask));
        }

        UpdateTaskUI();
    }

    public void UpdateTaskUI()
    {
        foreach (Transform child in taskListContent)
        {
            Destroy(child.gameObject);
        }

        foreach (var task in testTasksList)
        {
            GameObject entry = Instantiate(taskEntryPrefab, taskListContent);
            TMP_Text taskNameText = entry.transform.Find("TaskName").GetComponent<TMP_Text>();
            Transform objectiveList = entry.transform.Find("ObjectiveList");

            taskNameText.text = task.task.name;    

            foreach (var objective in task.objectives)
            {
                GameObject objTextGO = Instantiate(objectiveTextPrefab, objectiveList);
                TMP_Text objText = objTextGO.GetComponent<TMP_Text>();

                objText.text = $"{objective.descripton} ({objective.currentAmount}/{objective.requiredAmount})";
            }
        }
    }


}
