using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Objective : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;  // Texto do objetivo
    public Slider progressBar;  // Refer�ncia ao Slider de progresso
    public string description;  // Descri��o do objetivo

    protected bool isCompleted = false;  // Se o objetivo foi completado

    // M�todo que ser� chamado para iniciar o objetivo
    public virtual void StartObjective()
    {
        // Inicializa o estado do objetivo
        isCompleted = false;
        progressBar.gameObject.SetActive(false);  // Desativa a barra de progresso inicialmente
    }

    // M�todo abstrato que ser� implementado nos objetivos espec�ficos
    public abstract void CheckObjectiveProgress();

    public bool IsCompleted()
    {
        return isCompleted;
    }

    public string GetObjectiveDescription()
    {
        return description;
    }

    // Chama a fun��o de atualiza��o da barra de progresso quando o bot�o � pressionado
    protected void UpdateProgressBar(float progress)
    {
        if (progressBar.gameObject.activeSelf)  // Se o slider est� vis�vel
        {
            progressBar.value = progress;  // Atualiza o valor da barra
        }
    }

    // Fun��o para completar o objetivo
    protected void CompleteObjective()
    {
        isCompleted = true;
        progressBar.gameObject.SetActive(false);  // Desativa a barra de progresso quando conclu�do
    }
}



