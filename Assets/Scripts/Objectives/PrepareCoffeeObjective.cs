using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PrepareCoffeeObjective : Objective
{
    public GameObject kettlePrefab; // Prefab da chaleira
    public Transform spawnLocation; // Local onde a chaleira ser� instanciada
    private GameObject instantiatedKettle; // Refer�ncia ao objeto instanciado

    public float requiredHoldTime = 5f; // O tempo necess�rio para completar o objetivo
    private float currentHoldTime = 0f;

    // Ajuste da escala da chaleira
    private Vector3 scaleAdjustment = new Vector3(0.5f, 0.5f, 0.5f); // Escala 50% do tamanho original

    // Ajuste da posi��o da chaleira
    private Vector3 positionAdjustment = new Vector3(14.8f, 10.2f, 0f); // Nova posi��o x = 14.8, y = 10.2

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Ativa o texto de intera��o e a barra de progresso quando o jogador entra na �rea
            progressBar.gameObject.SetActive(true); // Exibir a barra de progresso
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Desativa o texto de intera��o e a barra de progresso quando o jogador sai da �rea
            progressBar.gameObject.SetActive(false); // Esconder a barra de progresso
        }
    }

    public override void CheckObjectiveProgress()
    {
        if (!isCompleted)
        {
            if (Input.GetButton("VERDE0"))
            {
                // Instancia a chaleira quando o jogador come�ar a intera��o
                if (instantiatedKettle == null)
                {
                    // Instanciando a chaleira apenas quando o jogador come�ar a intera��o
                    instantiatedKettle = Instantiate(kettlePrefab, spawnLocation.position, Quaternion.identity);

                    // Ajustando a escala da chaleira
                    instantiatedKettle.transform.localScale = scaleAdjustment;

                    // Ajustando a posi��o da chaleira para 14.8x e 10.2y
                    instantiatedKettle.transform.position = positionAdjustment;
                }

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
