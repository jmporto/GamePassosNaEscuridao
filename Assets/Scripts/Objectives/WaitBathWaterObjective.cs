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
    public GameObject[] bathtubPrefabs;
    public GameObject bathtubObject;

    private int currentLevelIndex = 0;

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

            UpdateBathtubLevel();

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

    private void UpdateBathtubLevel()
    {
        // Calcular o índice do prefab com base no progresso
        int totalLevels = bathtubPrefabs.Length;
        float progress = currentWaitTime / totalWaitTime;
        int levelIndex = Mathf.Clamp(Mathf.FloorToInt(progress * totalLevels), 0, totalLevels - 1);

        // Se o nível mudou, substitua o prefab
        if (levelIndex != currentLevelIndex)
        {
            currentLevelIndex = levelIndex;

            // Substituir o prefab
            ReplaceBathtubModel(bathtubPrefabs[currentLevelIndex]);
        }
    }

    private void ReplaceBathtubModel(GameObject newPrefab)
    {
        if (bathtubObject != null)
        {
            Transform bathtubTransform = bathtubObject.transform;
            Vector3 position = bathtubTransform.position;
            Quaternion rotation = bathtubTransform.rotation;
            Transform parent = bathtubTransform.parent;

            // Destruir o modelo atual
            Destroy(bathtubObject);

            // Instanciar o novo modelo
            bathtubObject = Instantiate(newPrefab, position, rotation, parent);
        }
    }

    public override void CheckObjectiveProgress() {}

}
