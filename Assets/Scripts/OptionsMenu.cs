using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Button backButton;

    private int selectedIndex = 0;
    private GameObject[] options;
    private Image[] optionBackgrounds;

    public GameObject mainMenuCanvas;

    void Start()
    {
        // Inicializar opções para navegação
        options = new GameObject[] { musicSlider.gameObject, sfxSlider.gameObject, backButton.gameObject };

        // Procurar os backgrounds (containers) dos sliders e botão para alteração de cor
        optionBackgrounds = new Image[]
        {
            musicSlider.transform.parent.GetComponent<Image>(),
            sfxSlider.transform.parent.GetComponent<Image>(),
            backButton.GetComponent<Image>()
        };

        UpdateSelection();
    }

    void Update()
    {
        // Navegação Vertical com W e S
        if (Input.GetKeyDown(KeyCode.W)) // Para cima
        {
            selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
            UpdateSelection();
        }
        else if (Input.GetKeyDown(KeyCode.S)) // Para baixo
        {
            selectedIndex = (selectedIndex + 1) % options.Length;
            UpdateSelection();
        }

        // Controle dos Sliders
        if (selectedIndex < options.Length - 1) // Apenas se um dos sliders estiver selecionado
        {
            Slider slider = options[selectedIndex].GetComponent<Slider>();
            if (slider != null) // Verifica se é um slider
            {
                float sliderInput = Input.GetAxis("Horizontal");

                // Ajuste do valor do slider
                if (sliderInput != 0)
                {
                    slider.value += sliderInput * Time.deltaTime * slider.maxValue; // Ajuste a velocidade aqui
                    slider.value = Mathf.Clamp(slider.value, slider.minValue, slider.maxValue); // Garante que o valor fique dentro dos limites
                }
            }
        }

        // Ação para voltar ao menu
        if (Input.GetKeyDown(KeyCode.Space)) // Ou outra tecla para voltar
        {
            if (selectedIndex == options.Length - 1) // Se for o botão de voltar
            {
                // Ativar menu principal e desativar opções
                gameObject.SetActive(false);
                mainMenuCanvas.SetActive(true);
            }
        }
    }

    void UpdateSelection()
    {
        // Alterar cor de fundo para a opção selecionada
        for (int i = 0; i < optionBackgrounds.Length; i++)
        {
            optionBackgrounds[i].color = (i == selectedIndex) ? Color.gray : Color.white; // Muda a cor para cinza se estiver selecionado
        }
    }
}