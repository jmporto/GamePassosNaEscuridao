using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMainMenuButton : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetButtonDown("VERDE0"))
        {
            LoadFirstScene();
        }
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
