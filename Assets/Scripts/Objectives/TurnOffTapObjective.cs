using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffTapObjective : Objective
{
    public float requiredHoldTime = 2f;
    private float currentHoldTime = 0f;
    public float activationRange = 1f;
    private GameObject player;
    public AudioSource waterRunningAudio;  // Áudio tocado antes de pressionar o botão
    public AudioSource turnOffFaucetAudio;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (!waterRunningAudio.isPlaying)
        {
            waterRunningAudio.loop = true;
            waterRunningAudio.Play();
        }
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
                currentHoldTime += Time.deltaTime;
                UpdateProgressBar(currentHoldTime / requiredHoldTime);
                progressBar.gameObject.SetActive(true);

                if (!turnOffFaucetAudio.isPlaying)
                    turnOffFaucetAudio.Play();

                if (waterRunningAudio.isPlaying)
                    waterRunningAudio.Stop();

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();

                    if (waterRunningAudio.isPlaying)
                        waterRunningAudio.Stop();

                    if (turnOffFaucetAudio.isPlaying)
                        turnOffFaucetAudio.Stop();
                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
                progressBar.gameObject.SetActive(false);
                turnOffFaucetAudio.Stop();

                if (!waterRunningAudio.isPlaying)
                    waterRunningAudio.Play();
            }
        }
    }
}
