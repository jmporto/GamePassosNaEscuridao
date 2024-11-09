using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    // Tempo em segundos antes de trocar de cena
    public float timeBeforeChange = 5.0f;
    // Nome da cena para a qual você deseja mudar
    public string sceneToLoad = "NomeDaCena";

    void Start()
    {
        // Inicia a corrotina para trocar de cena
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        // Espera o tempo especificado
        yield return new WaitForSeconds(timeBeforeChange);

        // Troca para a nova cena
        SceneManager.LoadScene(sceneToLoad);
    }
}
