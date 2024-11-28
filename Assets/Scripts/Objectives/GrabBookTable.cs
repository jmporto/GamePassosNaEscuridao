using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBookTable : Objective
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
                if (PlaceBookTable.instantiatedBook != null)
                {
                    Destroy(PlaceBookTable.instantiatedBook);
                    PlaceBookTable.instantiatedBook = null;
                }

                CompleteObjective();

                if (!ObjectiveAudioManager.Instance.IsPlaying("Book1second"))
                {
                    ObjectiveAudioManager.Instance.PlayObjectiveAudio("Book1second", 0);
                }
            }
        }
    }
}
