using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PrepareCoffeeObjective : Objective
{
    public GameObject kettlePrefab; // Prefab da chaleira
    public Transform spawnLocation; // Local onde a chaleira será instanciada
    private GameObject instantiatedKettle; // Referência ao objeto instanciado

    public float requiredHoldTime = 5f; // O tempo necessário para completar o objetivo
    private float currentHoldTime = 0f;

    // Ajuste da escala da chaleira
    private Vector3 scaleAdjustment = new Vector3(0.5f, 0.5f, 0.5f); // Escala 50% do tamanho original

    // Ajuste da posição da chaleira
    private Vector3 positionAdjustment = new Vector3(14.8f, 10.2f, 0f); // Nova posição x = 14.8, y = 10.2

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Ativa o texto de interação e a barra de progresso quando o jogador entra na área
            progressBar.gameObject.SetActive(true); // Exibir a barra de progresso
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Desativa o texto de interação e a barra de progresso quando o jogador sai da área
            progressBar.gameObject.SetActive(false); // Esconder a barra de progresso
        }
    }

    public override void CheckObjectiveProgress()
    {
        if (!isCompleted)
        {
            if (Input.GetButton("VERDE0"))
            {
                // Instancia a chaleira quando o jogador começar a interação
                if (instantiatedKettle == null)
                {
                    // Instanciando a chaleira apenas quando o jogador começar a interação
                    instantiatedKettle = Instantiate(kettlePrefab, spawnLocation.position, Quaternion.identity);

                    // Ajustando a escala da chaleira
                    instantiatedKettle.transform.localScale = scaleAdjustment;

                    // Ajustando a posição da chaleira para 14.8x e 10.2y
                    instantiatedKettle.transform.position = positionAdjustment;
                }

                // Incrementa o tempo enquanto o jogador segura o botão
                currentHoldTime += Time.deltaTime;

                // Atualiza a barra de progresso com base no tempo passado
                UpdateProgressBar(currentHoldTime / requiredHoldTime);

                // Se o jogador segurar o botão pelo tempo necessário, completa o objetivo
                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();
                }
            }
            else
            {
                // Reseta o progresso se o jogador soltar o botão
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
            }
        }
    }
}
