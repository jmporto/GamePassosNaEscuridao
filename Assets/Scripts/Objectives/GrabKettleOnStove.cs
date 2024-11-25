using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GrabKettleOnStove : Objective
{
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
                if (PrepareCoffeeObjective.instantiatedKettle != null)
                {
                    Destroy(PrepareCoffeeObjective.instantiatedKettle);
                    PrepareCoffeeObjective.instantiatedKettle = null;
                }

                CompleteObjective();
            }
        }
    }
}
