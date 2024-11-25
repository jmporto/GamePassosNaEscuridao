using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnBathObjective : Objective
{
    public float requiredHoldTime = 1f;
    private float currentHoldTime = 0f;
    public float activationRange = 1f;
    private GameObject player;
    public AudioSource turnBathOn;

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
                turnBathOn.Stop();
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

                if (!turnBathOn.isPlaying)
                    turnBathOn.Play();

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();
                    if (turnBathOn.isPlaying)
                        turnBathOn.Stop();
                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
                progressBar.gameObject.SetActive(false);
                turnBathOn.Stop();
            }
        }
    }
}
