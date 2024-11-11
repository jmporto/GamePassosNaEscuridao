using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class WaitBathWaterObjective : Objective
{
    public float totalWaitTime = 5f; // Tempo total para esperar (5 segundos)
    private float currentWaitTime = 0f; // Tempo que o jogador já esperou
    public TextMeshProUGUI countdownText; // Componente de texto para exibir a contagem regressiva
    private bool isPlayerInArea = false; // Verifica se o jogador está na área de interação

    private void Start()
    {
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(false); // Esconde o texto de contagem regressiva no início
        }
    }

    private void Update()
    {
        // Se o jogador está dentro da área, atualiza o temporizador
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

                // Chame o método para avançar para o próximo objetivo (se necessário)
                // objectiveManager.AdvanceToNextObjective();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInArea = true; // O jogador entrou na área
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
            isPlayerInArea = false; // O jogador saiu da área
            currentWaitTime = 0f; // Reseta o temporizador
            if (countdownText != null)
            {
                countdownText.gameObject.SetActive(false); // Esconde o texto de contagem regressiva
            }
        }
    }
    public override void CheckObjectiveProgress()
    {
        // Não precisa fazer nada aqui, pois a lógica já é controlada pelo Update()
    }

}
