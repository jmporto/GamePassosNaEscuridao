using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Objective : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;
    public Slider progressBar;
    public string description;
    protected bool isCompleted = false;
    public AudioSource sucessAudio;

    void Start()
    {
        // (Opcional) Se o AudioSource estiver no mesmo GameObject
        if (sucessAudio == null)
            sucessAudio = GetComponent<AudioSource>();
    }

    public virtual void StartObjective()
    {
        isCompleted = false;
        progressBar.gameObject.SetActive(false);
    }

    public abstract void CheckObjectiveProgress();

    public bool IsCompleted()
    {
        return isCompleted;
    }

    public string GetObjectiveDescription()
    {
        return description;
    }

    protected void UpdateProgressBar(float progress)
    {
        if (progressBar.gameObject.activeSelf)
        {
            progressBar.value = progress;
        }
    }

    protected void CompleteObjective()
    {
        isCompleted = true;
        progressBar.gameObject.SetActive(false);
        if (sucessAudio != null)
            sucessAudio.Play();
    }
}