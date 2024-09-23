using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectiveController : MonoBehaviour
{
    public GameObject[] objectives;
    public string[] objectiveMessages;
    public float interactionDistance = 2f;
    public Text objectiveText;
    public Text interactionText;
    private int currentObjective = 0;

    void Start()
    {
        interactionText.gameObject.SetActive(false);
        UpdateObjectiveText();
    }

    void Update()
    {
        if (currentObjective >= objectives.Length) return; // Se não houver mais objetivos, sai do Update

        GameObject objective = objectives[currentObjective];
        float distanceToObjective = Vector2.Distance(transform.position, objective.transform.position);

        // Checa se o player está dentro do range do objetivo
        if (distanceToObjective <= interactionDistance)
        {
            interactionText.gameObject.SetActive(true);
            interactionText.text = "Pressione F";

            if (Input.GetKeyDown(KeyCode.F))
            {
                InteractWithObjective();
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    void InteractWithObjective()
    {
        objectives[currentObjective].SetActive(false);

        currentObjective++;

        if (currentObjective < objectives.Length)
        {
            // Ativa o próximo objetivo e atualiza o texto
            objectives[currentObjective].SetActive(true);
            UpdateObjectiveText();
        }
        else
        {
            objectiveText.text = "Todos os objetivos concluídos!";
            interactionText.gameObject.SetActive(false);
        }
    }

    void UpdateObjectiveText()
    {
        // Atualiza msg de objetivo atual
        if (currentObjective < objectiveMessages.Length)
        {
            objectiveText.text = "Objetivo: " + objectiveMessages[currentObjective];
        }
    }
}
