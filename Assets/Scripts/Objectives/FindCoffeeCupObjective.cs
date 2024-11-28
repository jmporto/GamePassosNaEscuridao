using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCoffeeCupObjective : Objective
{
    public GameObject coffeeCup;

    private void Start()
    {
        if (progressBar != null)
        {
            progressBar.gameObject.SetActive(false);
        }
    }

    public override void CheckObjectiveProgress()
    {
        if (!isCompleted && Input.GetButtonDown("VERDE0"))
        {
            Destroy(coffeeCup);

            CompleteObjective();

            if (!ObjectiveAudioManager.Instance.IsPlaying("CeramicClank"))
            {
                ObjectiveAudioManager.Instance.PlayObjectiveAudio("CeramicClank", 0);
            }
        }
    }
}
