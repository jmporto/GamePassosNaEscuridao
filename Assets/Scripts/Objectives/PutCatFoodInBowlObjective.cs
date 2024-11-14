using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PutCatFoodInBowlObjective : Objective
{
    public GameObject emptyBowlPrefab;
    public GameObject fullBowlPrefab;
    public TextMeshProUGUI interactionText;

    private bool hasInteracted = false;

    private void Start()
    {
        if (progressBar != null)
        {
            progressBar.gameObject.SetActive(false);
        }
    }

    public override void CheckObjectiveProgress()
    {
        if (!isCompleted)
        {
            if (Input.GetButtonDown("VERDE0") && !hasInteracted)
            {
                hasInteracted = true;

                if (emptyBowlPrefab != null && fullBowlPrefab != null)
                {
                    Destroy(emptyBowlPrefab);
                    Instantiate(fullBowlPrefab, emptyBowlPrefab.transform.position, Quaternion.identity);
                }

                CompleteObjective();
            }
        }
    }
}
