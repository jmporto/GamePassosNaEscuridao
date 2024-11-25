using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBathObjective : Objective
{
    public float requiredHoldTime = 2f;
    private float currentHoldTime = 0f;
    public float activationRange = 1f;
    private GameObject player;
    public AudioSource bathTubWaterSplashing;

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
                bathTubWaterSplashing.Stop();
            }
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
                progressBar.gameObject.SetActive(true);

                if (!bathTubWaterSplashing.isPlaying)
                    bathTubWaterSplashing.Play();

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();

                    if (bathTubWaterSplashing.isPlaying)
                        bathTubWaterSplashing.Stop();
                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
                progressBar.gameObject.SetActive(false);
                bathTubWaterSplashing.Stop();
            }
        }
    }
}
