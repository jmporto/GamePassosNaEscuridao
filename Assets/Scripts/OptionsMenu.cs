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
        options = new GameObject[] { musicSlider.gameObject, sfxSlider.gameObject, backButton.gameObject };

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
        if (Input.GetKeyDown(KeyCode.W))
        {
            selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
            UpdateSelection();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            selectedIndex = (selectedIndex + 1) % options.Length;
            UpdateSelection();
        }

        if (selectedIndex < options.Length - 1)
        {
            Slider slider = options[selectedIndex].GetComponent<Slider>();
            if (slider != null)
            {
                float sliderInput = Input.GetAxis("Horizontal");

                if (sliderInput != 0)
                {
                    slider.value += sliderInput * Time.deltaTime * slider.maxValue;
                    slider.value = Mathf.Clamp(slider.value, slider.minValue, slider.maxValue);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (selectedIndex == options.Length - 1)
            {
                gameObject.SetActive(false);
                mainMenuCanvas.SetActive(true);
            }
        }
    }

    void UpdateSelection()
    {
        for (int i = 0; i < optionBackgrounds.Length; i++)
        {
            optionBackgrounds[i].color = (i == selectedIndex) ? Color.gray : Color.white;
        }
    }
}