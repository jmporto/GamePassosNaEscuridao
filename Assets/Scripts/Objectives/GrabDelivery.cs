using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrabDelivery : Objective
{
    public GameObject deliveryPrefab;
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
                if (deliveryPrefab != null)
                {
                    Destroy(deliveryPrefab);
                }

                CompleteObjective();
            }
        }
    }
}
