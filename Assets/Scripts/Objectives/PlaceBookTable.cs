using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBookTable : Objective
{
    public float requiredHoldTime = 3f;
    private float currentHoldTime = 0f;

    public GameObject boxPrefab;
    public GameObject bookPrefab;

    public Transform spawnPoint;
    public float activationRange = 1f;
    private GameObject player;
    public AudioSource bookDown;
    public static GameObject instantiatedBook;

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
                bookDown.Stop();
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

                if (!bookDown.isPlaying)
                    bookDown.Play();

                if (currentHoldTime >= requiredHoldTime)
                {
                    CompleteObjective();
                    InstantiatePrefabs();

                    if (bookDown.isPlaying)
                        bookDown.Stop();
                }
            }
            else
            {
                currentHoldTime = 0f;
                UpdateProgressBar(0f);
                progressBar.gameObject.SetActive(false);
                bookDown.Stop();
            }
        }
    }

    private void InstantiatePrefabs()
    {
        if (boxPrefab != null && spawnPoint != null)
        {
            GameObject instantiatedBox = Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);
            instantiatedBox.transform.position = new Vector3(-9.62f,  1.0f, 0f);
            instantiatedBox.transform.localScale = new Vector3(0.72f, 0.72f, 0.72f);
        }

        if (bookPrefab != null && spawnPoint != null)
        {
            instantiatedBook = Instantiate(bookPrefab, spawnPoint.position, Quaternion.identity);
            instantiatedBook.transform.position = new Vector3(-9.29f, 1.38f, 0f);
            instantiatedBook.transform.localScale = new Vector3(0.72f, 0.72f, 0.72f);
        }
    }
}
