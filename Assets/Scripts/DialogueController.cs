using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextSentences();
        }
    }

    void NextSentences()
    {
        if (Index <= Sentences.Length - 1)
        {
            DialogueText.text = "";
            StartCoroutine(WriteSentence());
        }

        IEnumerator WriteSentence()
        {
            foreach (char character in Sentences[Index].ToCharArray())
            {
                DialogueText.text += character;
                yield return new WaitForSeconds(DialogueSpeed);
            }
            Index++;
        }

    }
}

