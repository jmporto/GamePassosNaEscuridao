using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteIntensityController : MonoBehaviour
{
    public PostProcessProfile postProcessProfile;
    private Vignette vignette;
    private float duration = 240f; // 4 minutos
    private float startTime;
    private float initialIntensity = 0.5f;
    private float targetIntensity = 1.0f;

    void Start()
    {
        // Tenta obter a configuração de Vignette do perfil
        vignette = postProcessProfile.GetSetting<Vignette>();

        if (vignette != null)
        {
            vignette.intensity.value = initialIntensity;
        }
        startTime = Time.time;
    }

    void Update()
    {
        if (vignette != null)
        {
            float elapsedTime = Time.time - startTime;

            // Calcula a nova intensidade usando interpolação linear
            float t = Mathf.Clamp01(elapsedTime / duration);
            vignette.intensity.value = Mathf.Lerp(initialIntensity, targetIntensity, t);
        }
    }
}
