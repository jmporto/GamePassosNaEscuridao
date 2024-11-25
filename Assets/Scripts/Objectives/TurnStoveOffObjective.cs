using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStoveOffObjective : Objective
{
    public float requiredHoldTime = 5f;
    private float currentHoldTime = 0f;
    public float activationRange = 1f;
    private GameObject player;
    public GameObject stoveOffPrefab;   
    public AudioSource turnOffStove;


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
                turnOffStove.Stop();
            }
        }
    }

    private void ReplaceStoveWithOffVersion()
    {
        GameObject stoveObject = GameObject.FindWithTag("LitStove");

        if (stoveObject != null && stoveOffPrefab != null)
        {
            Transform stoveTransform = stoveObject.transform;
            Vector3 position = stoveTransform.position;
            Quaternion rotation = stoveTransform.rotation;
            Transform parent = stoveTransform.parent;

            Destroy(stoveObject);

            Instantiate(stoveOffPrefab, position, rotation, parent);
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

                if (!turnOffStove.isPlaying)
                    turnOffStove.Play();

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();
                    ReplaceStoveWithOffVersion();

                    if (turnOffStove.isPlaying)
                        turnOffStove.Stop();

                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
                progressBar.gameObject.SetActive(false);
                turnOffStove.Stop();
            }
        }
    }
}
