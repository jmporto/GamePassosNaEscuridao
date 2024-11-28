using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    public float timeBeforeChange = 5.0f;
    public string sceneToLoad = "NomeDaCena";

    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(timeBeforeChange);

        SceneManager.LoadScene(sceneToLoad);
    }
}
