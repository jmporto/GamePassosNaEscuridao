using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetKettleObjective : Objective
{
    public GameObject kettlePrefab;
    public TextMeshProUGUI interactionText;


    private void Start()
    {
        if (progressBar != null)
        {
            progressBar.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    public override void CheckObjectiveProgress()
    {
        if (!isCompleted && Input.GetButtonDown("VERDE0"))
        {
            Destroy(kettlePrefab);

            CompleteObjective();
        }
    }
}
