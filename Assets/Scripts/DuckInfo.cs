using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckInfo : MonoBehaviour
{
    // para pular uma linha dentro da string basta usar \n
    // Exemplo: "Pato 1: Eu sou um pato.\nQue legal!"

    // O texto ficaria assim:

    // Pato 1: Eu sou um pato
    // Que Legal!

    private string[] duckMessages = new string[]
    {
        "Pato 1: Caro amigo",
        "Pato 2: Alterar",
        "Pato 3: Esses",
        "Pato 4: Textos",
        "Pato 5: Para",
        "Pato 6: O",
        "Pato 7: Texto",
        "Pato 8: Correto",
    };

    public int duckIndex;

    public string GetInfoMessage()
    {
        if (duckIndex >= 0 && duckIndex < duckMessages.Length)
        {
            return duckMessages[duckIndex];
        }
        Debug.Log($"Índice inválido ou fora do limite: {duckIndex}");
        return "Mensagem padrão de coleta de pato!";
    }
}
