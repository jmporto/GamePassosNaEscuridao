using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStoveOnObjective : Objective
{
    public float requiredHoldTime = 2f;
    private float currentHoldTime = 0f;
    public float activationRange = 1f;
    private GameObject player;
    public GameObject stoveLitPrefab;
    public GameObject stoveObject;

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
                ObjectiveAudioManager.Instance.Stop("StoveOn");
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

                if (!ObjectiveAudioManager.Instance.IsPlaying("StoveOn"))
                {
                    ObjectiveAudioManager.Instance.PlayObjectiveAudio("StoveOn", 0);
                }

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();
                    ReplaceStove();

                    ObjectiveAudioManager.Instance.Stop("StoveOn");
                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
                progressBar.gameObject.SetActive(false);
                ObjectiveAudioManager.Instance.Stop("StoveOn");
            }
        }
    }

    private void ReplaceStove()
    {
        if (stoveObject != null && stoveLitPrefab != null)
        {
            Transform stoveTransform = stoveObject.transform;
            Vector3 position = stoveTransform.position;
            Quaternion rotation = stoveTransform.rotation;
            Transform parent = stoveTransform.parent;

            Destroy(stoveObject);

            stoveObject = Instantiate(stoveLitPrefab, position, rotation, parent);
        }
    }
}
