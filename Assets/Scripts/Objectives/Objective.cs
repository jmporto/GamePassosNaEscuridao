using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Objective : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;  // Texto do objetivo
    public Slider progressBar;  // Referência ao Slider de progresso
    public string description;  // Descrição do objetivo

    protected bool isCompleted = false;  // Se o objetivo foi completado

    // Método que será chamado para iniciar o objetivo
    public virtual void StartObjective()
    {
        // Inicializa o estado do objetivo
        isCompleted = false;
        progressBar.gameObject.SetActive(false);  // Desativa a barra de progresso inicialmente
    }

    // Método abstrato que será implementado nos objetivos específicos
    public abstract void CheckObjectiveProgress();

    public bool IsCompleted()
    {
        return isCompleted;
    }

    public string GetObjectiveDescription()
    {
        return description;
    }

    // Chama a função de atualização da barra de progresso quando o botão é pressionado
    protected void UpdateProgressBar(float progress)
    {
        if (progressBar.gameObject.activeSelf)  // Se o slider está visível
        {
            progressBar.value = progress;  // Atualiza o valor da barra
        }
    }

    // Função para completar o objetivo
    protected void CompleteObjective()
    {
        isCompleted = true;
        progressBar.gameObject.SetActive(false);  // Desativa a barra de progresso quando concluído
    }
}



