using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PrepareCoffeeObjective : Objective
{
    public GameObject kettlePrefab;
    public Transform spawnLocation;
    private GameObject instantiatedKettle;

    public float requiredHoldTime = 5f;
    private float currentHoldTime = 0f;

    private Vector3 scaleAdjustment = new Vector3(0.5f, 0.5f, 0.5f);

    private Vector3 positionAdjustment = new Vector3(14.8f, 10.2f, 0f);

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
                if (instantiatedKettle == null)
                {
                    instantiatedKettle = Instantiate(kettlePrefab, spawnLocation.position, Quaternion.identity);

                    instantiatedKettle.transform.localScale = scaleAdjustment;

                    instantiatedKettle.transform.position = positionAdjustment;
                }

                currentHoldTime += Time.deltaTime;

                UpdateProgressBar(currentHoldTime / requiredHoldTime);

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();
                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
            }
        }
    }
}