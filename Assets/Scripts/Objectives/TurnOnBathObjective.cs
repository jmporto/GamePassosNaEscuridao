using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnBathObjective : Objective
{
    public float requiredHoldTime = 1f; // O tempo necess�rio para completar o objetivo
    private float currentHoldTime = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Ativa a barra de progresso quando o jogador entra na �rea de trigger
            progressBar.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Desativa a barra de progresso quando o jogador sai da �rea de trigger
            progressBar.gameObject.SetActive(false);
        }
    }

    public override void CheckObjectiveProgress()
    {
        if (!isCompleted)
        {
            if (Input.GetButton("VERDE0"))
            {
                // Incrementa o tempo enquanto o jogador segura o bot�o
                currentHoldTime += Time.deltaTime;

                // Atualiza a barra de progresso com base no tempo passado
                UpdateProgressBar(currentHoldTime / requiredHoldTime);

                // Se o jogador segurar o bot�o pelo tempo necess�rio, completa o objetivo
                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();
                }
            }
            else
            {
                // Reseta o progresso se o jogador soltar o bot�o
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
            }
        }
    }
}
