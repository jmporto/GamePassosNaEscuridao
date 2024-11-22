using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTapObjective : Objective
{
    public float requiredHoldTime = 2f;
    private float currentHoldTime = 0f;
    public float activationRange = 1f;
    private GameObject player;
    public AudioSource turnOnFaucetAudio;
    private bool isPlaying = false;

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
                StopAllCoroutines();
                turnOnFaucetAudio.Stop();
                isPlaying = false;
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

                if (!isPlaying)
                    StartCoroutine(PlayAudioLoop());

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();
                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
                progressBar.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator PlayAudioLoop()
    {
        isPlaying = true;

        while (currentHoldTime < requiredHoldTime)
        {
            turnOnFaucetAudio.Play(); // Toca o �udio
            yield return new WaitForSeconds(turnOnFaucetAudio.clip.length); // Espera o fim do clipe
        }

        isPlaying = false;
    }
}