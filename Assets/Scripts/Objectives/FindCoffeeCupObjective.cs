using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCoffeeCupObjective : Objective
{
    public GameObject coffeeCup;
    public AudioSource ceramicClank;

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

            if (!ceramicClank.isPlaying)
                    ceramicClank.Play();
        }
    }
}
