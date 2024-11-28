using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCatFoodObjective : Objective
{
    public GameObject foodPrefab;
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

                if (foodPrefab != null)
                {
                    Destroy(foodPrefab);
                }

                CompleteObjective();

                if (!ObjectiveAudioManager.Instance.IsPlaying("FoodPickUp"))
                {
                    ObjectiveAudioManager.Instance.PlayObjectiveAudio("FoodPickUp", 0);
                }
            }
        }
    }
}
