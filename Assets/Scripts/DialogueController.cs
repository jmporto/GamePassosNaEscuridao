using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    public string sceneToLoad = "NomeDaCena";

    private bool isTyping = false;

    void Start()
    {
        NextSentences();
    }

    void Update()
    {
        if (Input.GetButtonDown("VERDE0"))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                DialogueText.text = Sentences[Index];
                isTyping = false;
            }
            else
            {
                Index++;
                NextSentences();
            }
        }
    }

    void NextSentences()
    {
        if (Index < Sentences.Length)
        {
            DialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    IEnumerator WriteSentence()
    {
        isTyping = true;

        foreach (char character in Sentences[Index].ToCharArray())
        {
            DialogueText.text += character;
            yield return new WaitForSeconds(DialogueSpeed);
        }

        isTyping = false;
    }
}
