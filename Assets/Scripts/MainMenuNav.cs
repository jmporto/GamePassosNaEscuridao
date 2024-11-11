using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuNav : MonoBehaviour
{
    public Button[] buttons;
    private int selectedIndex = 0;
/*    public GameObject optionsCanvas;*/
    private bool isVerticalInputPressed = false;
    private bool isGreenInputPressed = false;


    void Start()
    {
        UpdateButtonSelection();
        Debug.Log("MenuManager iniciado");
    }

    void Update()
    {
        float verde0Value = Input.GetAxisRaw("VERDE0");
        float verticalInput = Input.GetAxisRaw("VERTICAL0");

        // Detectar transição para cima
        if (verticalInput > 0 && !isVerticalInputPressed)
        {
            ChangeSelection(-1);
            Debug.Log("Movendo para cima");
            isVerticalInputPressed = true;
        }
        // Detectar transição para baixo
        else if (verticalInput < 0 && !isVerticalInputPressed)
        {
            ChangeSelection(1);
            Debug.Log("Movendo para baixo");
            isVerticalInputPressed = true;
        }
        // Resetar a flag quando não há input
        else if (verticalInput == 0)
        {
            isVerticalInputPressed = false;
        }

        if (verde0Value > 0 && !isGreenInputPressed)
        {
            ExecuteButtonAction();
            Debug.Log("Clicado");
            isVerticalInputPressed = true; 
        }
        else if (verde0Value == 0)
        {
            isGreenInputPressed = false;
        }
    }

    private void ChangeSelection(int direction)
    {
        selectedIndex += direction;

        if (selectedIndex < 0) selectedIndex = buttons.Length - 1;
        if (selectedIndex >= buttons.Length) selectedIndex = 0;

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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
/*            case 1:
                gameObject.SetActive(false);
                optionsCanvas.SetActive(true);
                break;*/
            case 1:
                Application.Quit();
                break;
        }
    }
}