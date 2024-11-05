using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuNav : MonoBehaviour
{
    public Button[] buttons;
    private int selectedIndex = 0;
    public GameObject optionsCanvas;

    void Start()
    {
        UpdateButtonSelection();
        Debug.Log("MenuManager iniciado");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExecuteButtonAction();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeSelection(-1);
            Debug.Log("Movendo para cima");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeSelection(1);
            Debug.Log("Movendo para baixo");
        }
    }

    private void ChangeSelection(int direction)
    {
        selectedIndex += direction;

        if (selectedIndex < 0) selectedIndex = buttons.Length - 1; // Volta para o último botão
        if (selectedIndex >= buttons.Length) selectedIndex = 0; // Volta para o primeiro botão

        UpdateButtonSelection();
    }

    void UpdateButtonSelection()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            ColorBlock colors = buttons[i].colors;
            colors.normalColor = (i == selectedIndex) ? Color.gray : Color.white;
            buttons[i].colors = colors;
        }
    }

    void ExecuteButtonAction()
    {
        switch (selectedIndex)
        {
            case 0:
                SceneManager.LoadScene("Scene1_House");
                break;
            case 1:
                gameObject.SetActive(false);
                optionsCanvas.SetActive(true);
                break;
            case 2:
                Application.Quit();
                break;
        }
    }
}