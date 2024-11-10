using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTapObjective : Objective
{
    public float requiredHoldTime = 2f;  // Tempo necess�rio para segurar o bot�o (em segundos)
    private float currentHoldTime = 0f;  // Tempo atual de hold

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Ativa a barra de progresso quando o jogador entra na zona de intera��o
            progressBar.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Desativa a barra de progresso se o jogador sair da zona de intera��o
            progressBar.gameObject.SetActive(false);
        }
    }

    public override void CheckObjectiveProgress()
    {
        if (!isCompleted)
        {
            // Checa se o jogador est� segurando o bot�o VERDE0
            if (Input.GetButton("VERDE0"))
            {
                // Aumenta o tempo de hold enquanto o bot�o est� pressionado
                currentHoldTime += Time.deltaTime;
                UpdateProgressBar(currentHoldTime / requiredHoldTime);  // Atualiza a barra de progresso

                // Se o tempo de hold for suficiente, o objetivo ser� completado
                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();
                }
            }
            else
            {
                // Se o bot�o n�o estiver pressionado, o tempo � resetado
                currentHoldTime = 0f;
                UpdateProgressBar(0f);  // Reseta a barra de progresso
            }
        }
    }
}