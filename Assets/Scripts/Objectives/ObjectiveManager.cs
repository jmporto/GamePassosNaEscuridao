using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;  // Refer�ncia ao texto do objetivo
    public Objective[] objectives;  // Lista de objetivos
    private int currentObjectiveIndex = 0;  // �ndice do objetivo atual

    void Start()
    {
        // Inicia o primeiro objetivo
        StartObjective();
    }

    void Update()
    {
        // Verifica se o objetivo atual foi completado
        if (currentObjectiveIndex < objectives.Length)
        {
            if (objectives[currentObjectiveIndex].IsCompleted())
            {
                // Quando o objetivo for completado, passa para o pr�ximo
                objectives[currentObjectiveIndex].gameObject.SetActive(false);  // Desativa o objetivo atual
                currentObjectiveIndex++;  // Avan�a para o pr�ximo objetivo
                if (currentObjectiveIndex < objectives.Length)
                {
                    StartObjective();  // Inicia o pr�ximo objetivo
                }
            }
            else
            {
                // Atualiza o texto com a descri��o do objetivo atual
                objectiveText.text = objectives[currentObjectiveIndex].GetObjectiveDescription();
            }
        }
    }

    private void StartObjective()
    {
        // Ativa o objetivo atual
        if (currentObjectiveIndex < objectives.Length)
        {
            objectives[currentObjectiveIndex].gameObject.SetActive(true);
        }
    }
}
