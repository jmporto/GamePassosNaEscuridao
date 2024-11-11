using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class WaitBathWaterObjective : Objective
{
    public float totalWaitTime = 5f; // Tempo total para esperar (5 segundos)
    private float currentWaitTime = 0f; // Tempo que o jogador j� esperou
    public TextMeshProUGUI countdownText; // Componente de texto para exibir a contagem regressiva
    private bool isPlayerInArea = false; // Verifica se o jogador est� na �rea de intera��o

    private void Start()
    {
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(false); // Esconde o texto de contagem regressiva no in�cio
        }
    }

    private void Update()
    {
        // Se o jogador est� dentro da �rea, atualiza o temporizador
        if (isPlayerInArea)
        {
            currentWaitTime += Time.deltaTime; // Acumula o tempo de espera
            int timeRemaining = Mathf.CeilToInt(totalWaitTime - currentWaitTime); // Tempo restante arredondado para cima

            // Atualiza o texto de contagem regressiva
            if (countdownText != null)
            {
                countdownText.text = "Tempo restante: " + timeRemaining + " segundos";
            }

            // Quando o tempo acabar, completa o objetivo
            if (currentWaitTime >= totalWaitTime)
            {
                CompleteObjective(); // Completa o objetivo
                if (countdownText != null)
                {
                    countdownText.gameObject.SetActive(false); // Esconde o texto
                }

                // Chame o m�todo para avan�ar para o pr�ximo objetivo (se necess�rio)
                // objectiveManager.AdvanceToNextObjective();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInArea = true; // O jogador entrou na �rea
            currentWaitTime = 0f; // Reseta o temporizador
            if (countdownText != null)
            {
                countdownText.gameObject.SetActive(true); // Mostra o texto de contagem regressiva
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInArea = false; // O jogador saiu da �rea
            currentWaitTime = 0f; // Reseta o temporizador
            if (countdownText != null)
            {
                countdownText.gameObject.SetActive(false); // Esconde o texto de contagem regressiva
            }
        }
    }
    public override void CheckObjectiveProgress()
    {
        // N�o precisa fazer nada aqui, pois a l�gica j� � controlada pelo Update()
    }

}
