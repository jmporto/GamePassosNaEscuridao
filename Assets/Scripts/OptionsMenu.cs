/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Button backButton;  // Refer�ncia para o bot�o de voltar
    private int selectedIndex = 0;
    private GameObject[] options;
    private Image[] optionBackgrounds;

    public GameObject mainMenuCanvas;  // Refer�ncia para o canvas principal
    public GameObject optionsCanvas;   // Refer�ncia para o canvas de op��es

    private bool isVerticalInputPressed = false;
    private bool isGreenInputPressed = false;

    void Start()
    {
        // Inicializando os bot�es de op��es
        options = new GameObject[] { musicSlider.gameObject, sfxSlider.gameObject, backButton.gameObject };

        // Inicializando os backgrounds dos bot�es
        optionBackgrounds = new Image[]
        {
            musicSlider.transform.parent.GetComponent<Image>(),
            sfxSlider.transform.parent.GetComponent<Image>(),
            backButton.GetComponent<Image>()
        };

        UpdateSelection();

        if (backButton != null)
        {
            // Associando o m�todo OnBackButtonPressed ao onClick
            backButton.onClick.AddListener(OnBackButtonPressed);
        }
    }

    void Update()
    {
        // Recebendo input vertical (W/S ou setas)
        float verticalInput = Input.GetAxisRaw("VERTICAL0");
        float verde0Value = Input.GetAxisRaw("VERDE0");

        // Movendo a sele��o para cima
        if (verticalInput > 0 && !isVerticalInputPressed)
        {
            selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
            UpdateSelection();
            isVerticalInputPressed = true;
        }
        // Movendo a sele��o para baixo
        else if (verticalInput < 0 && !isVerticalInputPressed)
        {
            selectedIndex = (selectedIndex + 1) % options.Length;
            UpdateSelection();
            isVerticalInputPressed = true;
        }
        else if (verticalInput == 0)
        {
            isVerticalInputPressed = false;
        }

        // A��o quando pressionado o bot�o VERDE0
        if (verde0Value > 0 && !isGreenInputPressed)
        {
            // Simula o clique do bot�o de voltar
            backButton.onClick.Invoke();
            isGreenInputPressed = true;
        }
        else if (verde0Value == 0)
        {
            isGreenInputPressed = false;
        }
    }

    // Atualizando a sele��o visual dos bot�es
    void UpdateSelection()
    {
        for (int i = 0; i < optionBackgrounds.Length; i++)
        {
            optionBackgrounds[i].color = (i == selectedIndex) ? Color.gray : Color.white;
        }
    }

    // A��o ao pressionar o bot�o de voltar
    void OnBackButtonPressed()
    {
        // Desativa o OptionsCanvas e ativa o MainMenuCanvas
        optionsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
}*/