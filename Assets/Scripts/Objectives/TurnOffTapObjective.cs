using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffTapObjective : Objective
{
    public float requiredHoldTime = 2f;
    private float currentHoldTime = 0f;
    public float activationRange = 1f;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (!ObjectiveAudioManager.Instance.IsPlaying("WaterRunning"))
        {
            ObjectiveAudioManager.Instance.PlayObjectiveAudio("WaterRunning", 0);
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
                ObjectiveAudioManager.Instance.Stop("TurnOffFaucet");
                ObjectiveAudioManager.Instance.Stop("WaterRunning");
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

                if (!ObjectiveAudioManager.Instance.IsPlaying("TurnOffFaucet"))
                {
                    ObjectiveAudioManager.Instance.PlayObjectiveAudio("TurnOffFaucet", 0);
                }

                if (ObjectiveAudioManager.Instance.IsPlaying("WaterRunning"))
                {
                    ObjectiveAudioManager.Instance.Stop("WaterRunning");
                }

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();

                    ObjectiveAudioManager.Instance.Stop("WaterRunning");

                    ObjectiveAudioManager.Instance.Stop("TurnOffFaucet");
                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
                progressBar.gameObject.SetActive(false);

                ObjectiveAudioManager.Instance.Stop("TurnOffFaucet");

                if (!ObjectiveAudioManager.Instance.IsPlaying("WaterRunning"))
                {
                    ObjectiveAudioManager.Instance.PlayObjectiveAudio("WaterRunning", 0);
                }
            }
        }
    }
}
