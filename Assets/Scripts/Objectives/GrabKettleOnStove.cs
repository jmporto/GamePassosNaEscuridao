using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKettleOnStove : Objective
{
    private bool hasInteracted = false;
    public AudioSource metalClank;

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
                if (PrepareCoffeeObjective.instantiatedKettle != null)
                {
                    Destroy(PrepareCoffeeObjective.instantiatedKettle);
                    PrepareCoffeeObjective.instantiatedKettle = null;
                }

                CompleteObjective();

                if (!metalClank.isPlaying)
                    metalClank.Play();
            }
        }
    }
}
