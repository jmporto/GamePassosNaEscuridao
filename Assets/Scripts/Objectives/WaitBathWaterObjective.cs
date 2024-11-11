using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class WaitBathWaterObjective : Objective
{
    public float totalWaitTime = 5f;
    private float currentWaitTime = 0f;
    public TextMeshProUGUI countdownText;
    private bool isPlayerInArea = false;

    private void Start()
    {
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(false);
        }

        if (progressBar != null)
        {
            progressBar.gameObject.SetActive(false); // Esconde a barra de progresso
        }
    }

    private void Update()
    {
        if (isPlayerInArea)
        {
            currentWaitTime += Time.deltaTime;
            int timeRemaining = Mathf.CeilToInt(totalWaitTime - currentWaitTime);

            if (countdownText != null)
            {
                countdownText.text = "Tempo restante: " + timeRemaining + " segundos";
            }

            if (currentWaitTime >= totalWaitTime)
            {
                CompleteObjective();
                if (countdownText != null)
                {
                    countdownText.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInArea = true;
            currentWaitTime = 0f;
            if (countdownText != null)
            {
                countdownText.gameObject.SetActive(true);
            }
            if (progressBar != null)
            {
                progressBar.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInArea = false;
            currentWaitTime = 0f;
            if (countdownText != null)
            {
                countdownText.gameObject.SetActive(false);
            }
            if (progressBar != null)
            {
                progressBar.gameObject.SetActive(false);
            }
        }
    }
    public override void CheckObjectiveProgress() {}

}
