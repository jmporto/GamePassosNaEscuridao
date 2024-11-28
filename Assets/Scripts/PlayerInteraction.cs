using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Objective currentObjective;
    public GameObject interactionPrompt;
    public TextMeshProUGUI objectiveText;
    private bool isInCollider = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Objective"))
        {
            currentObjective = collision.GetComponent<Objective>();

            if (currentObjective != null && !currentObjective.IsCompleted())
            {
                ShowInteractionPrompt();
                objectiveText.text = "Pressione VERDE0 para " + currentObjective.GetType().Name;
                isInCollider = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Objective"))
        {
            HideInteractionPrompt();
            isInCollider = false;
        }
    }

    private void Update()
    {
        if (isInCollider && currentObjective != null && !currentObjective.IsCompleted())
        {
            if (currentObjective is WaitBathWaterObjective)
            {
                HideInteractionPrompt();
            }

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
