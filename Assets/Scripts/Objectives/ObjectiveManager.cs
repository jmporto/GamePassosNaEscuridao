using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;
    public Objective[] objectives;
    private int currentObjectiveIndex = 0;

    void Start()
    {
        StartObjective();
    }

    void Update()
    {
        if (currentObjectiveIndex < objectives.Length)
        {
            if (objectives[currentObjectiveIndex].IsCompleted())
            {
                objectives[currentObjectiveIndex].gameObject.SetActive(false);
                currentObjectiveIndex++;
                if (currentObjectiveIndex < objectives.Length)
                {
                    StartObjective();
                }
            }
            else
            {
                objectiveText.text = objectives[currentObjectiveIndex].GetObjectiveDescription();
            }
        }
    }

    private void StartObjective()
    {
        if (currentObjectiveIndex < objectives.Length)
        {
            objectives[currentObjectiveIndex].gameObject.SetActive(true);
        }
    }
}
