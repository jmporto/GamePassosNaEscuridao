using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneOptionsMenu : MonoBehaviour
{
    public Canvas optionsCanvas;
    public Canvas[] otherCanvases;
    private bool isOptionsCanvasActive = false;

    void Update()
    {
        if (Input.GetButtonDown("MENU"))
        {
            ToggleOptionsCanvas();
        }
    }

    void ToggleOptionsCanvas()
    {
        isOptionsCanvasActive = !isOptionsCanvasActive;
        optionsCanvas.gameObject.SetActive(isOptionsCanvasActive);

        foreach (Canvas canvas in otherCanvases)
        {
            canvas.gameObject.SetActive(!isOptionsCanvasActive);
        }
    }
}
