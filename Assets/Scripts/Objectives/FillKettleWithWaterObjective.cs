using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FillKettleWithWaterObjective : Objective
{
    public float requiredHoldTime = 2f;
    private float currentHoldTime = 0f;

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
            if (progressBar != null)
            {
                progressBar.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (progressBar != null)
            {
                progressBar.gameObject.SetActive(false);
            }
        }
    }

    public override void CheckObjectiveProgress()
    {
        if (!isCompleted)
        {
            if (Input.GetButton("VERDE0"))
            {
                currentHoldTime += Time.deltaTime;

                if (progressBar != null)
                {
                    UpdateProgressBar(currentHoldTime / requiredHoldTime);
                }

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();
                }
            }
            else
            {
                currentHoldTime = 0f;
                if (progressBar != null)
                {
                    UpdateProgressBar(0f);
                }
            }
        }
    }
}
