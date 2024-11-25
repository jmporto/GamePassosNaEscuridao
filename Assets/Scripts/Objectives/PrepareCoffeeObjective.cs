using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareCoffeeObjective : Objective
{
    public float requiredHoldTime = 2f;
    private float currentHoldTime = 0f;
    public float activationRange = 1f;
    private GameObject player;
    public GameObject kettlePrefab;
    public Transform spawnLocation;
    public static GameObject instantiatedKettle;
    private Vector3 scaleAdjustment = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 positionAdjustment = new Vector3(14.8f, 10.2f, 0f);
    public AudioSource waterBolling;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance <= activationRange)
            {
                CheckObjectiveProgress();
            }
            else
            {
                progressBar.gameObject.SetActive(false);
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
            }
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
                progressBar.gameObject.SetActive(true);

                if (!waterBolling.isPlaying)
                    waterBolling.Play();

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();

                    if (waterBolling.isPlaying)
                        waterBolling.Stop();

                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
                progressBar.gameObject.SetActive(false);
                waterBolling.Stop();
            }
        }
    }
}
