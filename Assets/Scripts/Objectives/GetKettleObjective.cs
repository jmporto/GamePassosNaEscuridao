using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetKettleObjective : Objective
{
    public GameObject kettlePrefab;
    public TextMeshProUGUI interactionText;


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
            Destroy(kettlePrefab);

            CompleteObjective();
        }
    }
}
