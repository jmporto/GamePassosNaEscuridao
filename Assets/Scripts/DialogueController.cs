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
    // Nome da cena para a qual você deseja mudar
    public string sceneToLoad = "NomeDaCena";

    private bool isTyping = false; // Para controlar se a frase está sendo digitada

    void Start()
    {
        // Começa a exibir a primeira frase
        NextSentences();
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Usar GetButtonDown para detectar o pressionamento da tecla (a tecla "R" no seu caso)
        if (Input.GetButtonDown("VERDE0"))
        {
            if (isTyping)
            {
                // Se estiver digitando, terminar a digitação imediatamente
                StopAllCoroutines();
                DialogueText.text = Sentences[Index]; // Exibe a frase completa
                isTyping = false; // Finaliza a digitação da frase atual
            }
            else
            {
                // Avança para a próxima frase
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
            // Se todas as frases já foram exibidas, mudar a cena
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    IEnumerator WriteSentence()
    {
        isTyping = true; // Marcar que a frase está sendo digitada

        foreach (char character in Sentences[Index].ToCharArray())
        {
            DialogueText.text += character;
            yield return new WaitForSeconds(DialogueSpeed);
        }

        isTyping = false; // Libera para a próxima frase
    }
}
