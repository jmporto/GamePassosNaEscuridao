using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkCoffeeLivingRoomObjective : Objective
{
    public float requiredHoldTime = 3f;
    private float currentHoldTime = 0f;

    public GameObject cupPrefab;
    public GameObject kettlePrefab;

    public Transform spawnPoint;

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
                    InstantiatePrefabs();
                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
            }
        }
    }

    private void InstantiatePrefabs()
    {
        if (cupPrefab != null && spawnPoint != null)
        {
            GameObject instantiatedCup = Instantiate(cupPrefab, spawnPoint.position, Quaternion.identity);
            instantiatedCup.transform.position = new Vector3(-6.99f, 9.05f, instantiatedCup.transform.position.z);
            instantiatedCup.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        if (kettlePrefab != null && spawnPoint != null)
        {
            GameObject instantiatedKettle = Instantiate(kettlePrefab, spawnPoint.position, Quaternion.identity);
            instantiatedKettle.transform.position = new Vector3(-6.63f, 9.33f, instantiatedKettle.transform.position.z);
            instantiatedKettle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
