using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DuckCollector : MonoBehaviour
{
    public TextMeshProUGUI collectedDucksText;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI interactionText;
    public TextMeshProUGUI continueText;
    private int collectedDucks = 0;
    private GameObject currentDuck;
    private bool isNearDuck = false;
    public bool canMove = true;

    private void Start()
    {
        collectedDucksText.text = "Patos Coletados: 0/8";
        infoText.gameObject.SetActive(false);
        interactionText.gameObject.SetActive(false);
        continueText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isNearDuck && Input.GetButtonDown("VERDE0") && canMove)
        {
            CollectDuck();
        }

        if (!canMove && infoText.gameObject.activeSelf && Input.GetButtonDown("VERDE0"))
        {
            CloseMessage();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Duck"))
        {
            isNearDuck = true;
            currentDuck = other.gameObject;
            interactionText.text = "Aperte Verde para interagir";
            interactionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Duck"))
        {
            isNearDuck = false;
            currentDuck = null;
            interactionText.gameObject.SetActive(false);
        }
    }

    private void CollectDuck()
    {
        if (currentDuck != null)
        {
            collectedDucks++;
            collectedDucksText.text = "Patos Coletados: " + collectedDucks + "/8";

            DuckInfo duckInfo = currentDuck.GetComponent<DuckInfo>();
            if (duckInfo != null)
            {
                infoText.text = duckInfo.GetInfoMessage();
            }
            else
            {
                infoText.text = "Você coletou um pato!";
            }

            canMove = false;

            currentDuck.SetActive(false);

            isNearDuck = false;
            currentDuck = null;

            StartCoroutine(ActivateInfoTextWithDelay());
        }
    }

    // Codigo nao funciona corretamente sem esse delay, nao alterar!!!!!!!!!!!!!!!
    private IEnumerator ActivateInfoTextWithDelay()
    {
        yield return null;

        infoText.gameObject.SetActive(true);
        continueText.text = "Aperte R ou Verde para continuar";
        continueText.gameObject.SetActive(true);
    }

    private void CloseMessage()
    {
        infoText.gameObject.SetActive(false);
        continueText.gameObject.SetActive(false);

        canMove = true;
    }
}
