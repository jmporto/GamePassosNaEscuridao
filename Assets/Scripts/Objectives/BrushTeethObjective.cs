using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushTeethObjective : Objective
{
    public float requiredHoldTime = 5f;
    private float currentHoldTime = 0f;
    public float activationRange = 1f;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        ObjectiveAudioManager.Instance.PlayObjectiveAudio("WaterRunning", 0);
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
                ObjectiveAudioManager.Instance.Stop("BrushingTeeth");

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

                if (!ObjectiveAudioManager.Instance.IsPlaying("BrushingTeeth"))
                {
                    ObjectiveAudioManager.Instance.PlayObjectiveAudio("BrushingTeeth", 0);
                }

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();

                    ObjectiveAudioManager.Instance.Stop("WaterRunning");
                    ObjectiveAudioManager.Instance.Stop("BrushingTeeth");
                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
                progressBar.gameObject.SetActive(false);
                ObjectiveAudioManager.Instance.Stop("BrushingTeeth");
            }
        }
    }
}