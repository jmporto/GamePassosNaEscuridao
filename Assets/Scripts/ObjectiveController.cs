using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ObjectiveController : MonoBehaviour
{
    public GameObject[] objectives;
    public string[] objectiveMessages;
    public float interactionDistance = 2f;
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI interactionText;
    private int currentObjective = 0;
    private float verde0;

    void Start()
    {
        interactionText.gameObject.SetActive(false);
        UpdateObjectiveText();
    }

    void Update()
    {
        verde0 = Input.GetAxis("VERDE0");

        if (currentObjective >= objectives.Length) return; // Se nao houver mais objetivos, sai do Update

        GameObject objective = objectives[currentObjective];
        float distanceToObjective = Vector2.Distance(transform.position, objective.transform.position);

        // Checa se o player esta dentro do range do objetivo
        if (distanceToObjective <= interactionDistance)
        {
            interactionText.gameObject.SetActive(true);
            interactionText.text = "Pressione Verde/R";

            if (verde0 > 0.0f)
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
            // Ativa o pr�ximo objetivo e atualiza o texto
            objectives[currentObjective].SetActive(true);
            UpdateObjectiveText();
        }
        else
        {
            objectiveText.text = "Todos os objetivos concluidos!";
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
