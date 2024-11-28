using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBookShelf : Objective
{
    public float requiredHoldTime = 2f;
    private float currentHoldTime = 0f;
    public float activationRange = 1f;
    private GameObject player;
    public GameObject bookPrefab;
    public Transform spawnLocation;
    public static GameObject instantiatedBookShelf;
    private Vector3 scaleAdjustment = new Vector3(0.72f, 0.72f, 0.5f);
    private Vector3 positionAdjustment = new Vector3(-11.35f, 3f, 0f);

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
                ObjectiveAudioManager.Instance.Stop("Book2seconds");
            }
        }
    }

    public override void CheckObjectiveProgress()
    {
        if (!isCompleted)
        {
            if (Input.GetButton("VERDE0"))
            {
                if (instantiatedBookShelf == null)
                {
                    instantiatedBookShelf = Instantiate(bookPrefab, spawnLocation.position, Quaternion.identity);

                    instantiatedBookShelf.transform.localScale = scaleAdjustment;

                    instantiatedBookShelf.transform.position = positionAdjustment;
                }

                currentHoldTime += Time.deltaTime;
                UpdateProgressBar(currentHoldTime / requiredHoldTime);
                progressBar.gameObject.SetActive(true);

                if (!ObjectiveAudioManager.Instance.IsPlaying("Book2seconds"))
                {
                    ObjectiveAudioManager.Instance.PlayObjectiveAudio("Book2seconds", 0);
                }

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();
                    ObjectiveAudioManager.Instance.Stop("Book2seconds");
                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
                progressBar.gameObject.SetActive(false);
                ObjectiveAudioManager.Instance.Stop("Book2seconds");
            }
        }
    }
}
