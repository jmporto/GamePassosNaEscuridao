using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnBathObjective : Objective
{
    public float requiredHoldTime = 1f;
    private float currentHoldTime = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            progressBar.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            progressBar.gameObject.SetActive(false);
        }
    }

    public override void CheckObjectiveProgress()
    {
        if (!isCompleted)
        {
            if (Input.GetButton("VERDE0"))
            {
                currentHoldTime += Time.deltaTime;

                UpdateProgressBar(currentHoldTime / requiredHoldTime);

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();
                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
            }
        }
    }
}