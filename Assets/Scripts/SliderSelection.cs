using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSelection : MonoBehaviour
{
    public Slider[] sliders;
    public Canvas optionsCanvas;
    public GameObject player;
    private int currentSliderIndex = 0;
    private float horizontalInputCooldown = 0.1f;
    private float horizontalInputTimer = 0f;
    private bool isCanvasActive = false;

    void Update()
    {
        CheckCanvasState();

        if (isCanvasActive)
        {
            HandleVerticalInput();
            HandleHorizontalInput();
        }
    }

    void CheckCanvasState()
    {
        isCanvasActive = optionsCanvas.gameObject.activeSelf;

        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.enabled = !isCanvasActive;
        }
    }

    void HandleVerticalInput()
    {
        float verticalInput = Input.GetAxisRaw("VERTICAL0");

        if (verticalInput > 0.5f)
        {
            MoveSelection(-1);
        }
        else if (verticalInput < -0.5f)
        {
            MoveSelection(1);
        }
    }

    void HandleHorizontalInput()
    {
        float horizontalInput = Input.GetAxis("HORIZONTAL0");

        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            horizontalInputTimer -= Time.deltaTime;

            if (horizontalInputTimer <= 0f)
            {
                AdjustSlider(horizontalInput);
                horizontalInputTimer = horizontalInputCooldown;
            }
        }
        else
        {
            horizontalInputTimer = 0f;
        }
    }

    void MoveSelection(int direction)
    {
        int previousIndex = currentSliderIndex;
        currentSliderIndex = Mathf.Clamp(currentSliderIndex + direction, 0, sliders.Length - 1);

        if (previousIndex != currentSliderIndex)
        {
            HighlightSlider(currentSliderIndex);
        }
    }

    void AdjustSlider(float horizontalInput)
    {
        Slider currentSlider = sliders[currentSliderIndex];
        currentSlider.value += horizontalInput * Time.deltaTime * 3f;
    }

    void HighlightSlider(int index)
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            ColorBlock colors = sliders[i].colors;

            if (i == index)
            {
                colors.normalColor = Color.yellow;
            }
            else
            {
                colors.normalColor = Color.white;
            }

            sliders[i].colors = colors;
        }
    }
}
