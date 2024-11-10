using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Objective currentObjective;  // Referência ao objetivo atual
    public GameObject interactionPrompt;  // Referência ao texto de interação na UI
    public TextMeshProUGUI objectiveText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Objective"))
        {
            Debug.Log("Entrou no objetivo!");
            currentObjective = collision.GetComponent<Objective>();
            if (currentObjective != null && !currentObjective.IsCompleted())
            {
                ShowInteractionPrompt();  // Mostra a mensagem de interação
                objectiveText.text = currentObjective.GetObjectiveDescription();  // Atualiza com o texto correto
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Objective"))
        {
            HideInteractionPrompt();  // Esconde a mensagem de interação
        }
    }

    private void Update()
    {
        if (Input.GetButton("VERDE0") && currentObjective != null)
        {
            Debug.Log("Segurando o botão VERDE0, progredindo no objetivo...");
            currentObjective.CheckObjectiveProgress();  // Chamará a lógica de progresso do objetivo
        }
    }

    private void ShowInteractionPrompt()
    {
        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(true);  // Ativa o texto de interação
        }
    }

    private void HideInteractionPrompt()
    {
        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(false);  // Desativa o texto de interação
        }
    }
}
