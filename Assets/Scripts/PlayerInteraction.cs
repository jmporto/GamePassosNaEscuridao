using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Objective currentObjective;
    public GameObject interactionPrompt;
    public TextMeshProUGUI objectiveText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Objective"))
        {
            Debug.Log("Entrou no objetivo!");
            currentObjective = collision.GetComponent<Objective>();
            if (currentObjective != null && !currentObjective.IsCompleted())
            {
                if (!(currentObjective is WaitBathWaterObjective))
                {
                    ShowInteractionPrompt();
                }
                objectiveText.text = currentObjective.GetObjectiveDescription();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Objective"))
        {
            HideInteractionPrompt();
        }
    }

    private void Update()
    {
        if (Input.GetButton("VERDE0") && currentObjective != null)
        {
            Debug.Log("Segurando o botão VERDE0, progredindo no objetivo...");
            currentObjective.CheckObjectiveProgress();
        }
    }

    private void ShowInteractionPrompt()
    {
        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(true);
        }
    }

    private void HideInteractionPrompt()
    {
        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(false);
        }
    }
}
