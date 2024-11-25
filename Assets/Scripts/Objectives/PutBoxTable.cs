using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBoxTable : Objective
{
    public float requiredHoldTime = 2f;
    private float currentHoldTime = 0f;
    public float activationRange = 1f;
    private GameObject player;
    public GameObject openBox;
    public Transform spawnLocation;
    public static GameObject instantiatedBox;
    public AudioSource placeBox;


    private Vector3 scaleAdjustment = new Vector3(0.72f, 0.72f, 0.72f);

    private Vector3 positionAdjustment = new Vector3(-9.62f, 1.0f, 0f);

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
                placeBox.Stop();
            }
        }
    }

    public override void CheckObjectiveProgress()
    {
        if (!isCompleted)
        {
            if (Input.GetButton("VERDE0"))
            {
                if (instantiatedBox == null)
                {
                    instantiatedBox = Instantiate(openBox, spawnLocation.position, Quaternion.identity);

                    instantiatedBox.transform.localScale = scaleAdjustment;

                    instantiatedBox.transform.position = positionAdjustment;
                }

                currentHoldTime += Time.deltaTime;
                UpdateProgressBar(currentHoldTime / requiredHoldTime);
                progressBar.gameObject.SetActive(true);

                if (!placeBox.isPlaying)
                    placeBox.Play();

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();
                    if (placeBox.isPlaying)
                        placeBox.Stop();
                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
                progressBar.gameObject.SetActive(false);
                placeBox.Stop();
            }
        }
    }
}