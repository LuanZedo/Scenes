using UnityEngine;

public class ModelController : MonoBehaviour
{
    [Header("Configurações do Modelo 3D")]
    [Tooltip("Selecione o Transform do seu modelo 3D.")]
    [SerializeField] private Transform modelTransform;

    [Tooltip("Selecione o MeshRenderer do seu modelo 3D.")]
    [SerializeField] private MeshRenderer modelRenderer;

    [Header("Configurações de Escala (UI Slider)")]
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 2.0f;

    [Header("Configurações de Cor (UI Toggle)")]
    [SerializeField] private Color alternativeColor = Color.red;

    private Vector3 initialScale;
    private Quaternion initialRotation;
    private Material runtimeMaterial;
    private Color initialColor;
    
    private void Awake()
    {
        if (modelTransform != null)
        {
            initialScale = modelTransform.localScale;
            initialRotation = modelTransform.localRotation;
        }

        if (modelRenderer != null)
        {
            runtimeMaterial = modelRenderer.material;

            if (runtimeMaterial.HasProperty("_BaseColor"))
            {
                initialColor = runtimeMaterial.GetColor("_BaseColor");
            }
        }
    }

    public void SetScale(float sliderValue)
    {
        if (modelTransform == null) return;

        float clampedValue = Mathf.Clamp01(sliderValue);
        float targetScaleFactor = Mathf.Lerp(minScale, maxScale, clampedValue);

        modelTransform.localScale = Vector3.one * targetScaleFactor;

        Debug.Log($"[ModelController] Método SetScale chamado. Escala ajustada: {targetScaleFactor}");
    }

        public void ToggleVisibility(bool isVisible)
    {
        if (modelRenderer == null) return;
        
        modelRenderer.enabled = isVisible;

        Debug.Log($"[ModelController] Método ToggleVisibility chamado. Visível: {isVisible}");
    }

    public void RotateModel(float angle)
    {
        if (modelTransform == null) return;
        
        modelTransform.localRotation = Quaternion.Euler(0f, angle, 0f);

        Debug.Log($"[ModelController] Método RotateModel chamado. Ângulo de rotação: {Quaternion.Euler(0f, angle, 0f)}°");
    }

    public void ToggleColor(bool useAlternativeColor)
    {
        if (runtimeMaterial == null) return;

        Color targetColor = useAlternativeColor ? alternativeColor : initialColor;
        runtimeMaterial.SetColor("_BaseColor", targetColor);

        Debug.Log($"[ModelController] Método ToggleColor chamado. Cor aplicada: {targetColor}");
    }

    public void ResetModel()
        {
            if (modelTransform != null)
            {
                modelTransform.localScale = initialScale;
                modelTransform.localRotation = initialRotation;
            }

            if (modelRenderer != null)
            {
                modelRenderer.enabled = true;
            }

            if (runtimeMaterial != null)
            {
                runtimeMaterial.SetColor("_BaseColor", initialColor);
            }

            Debug.Log("[ModelController] Método ResetModel chamado.");
        }

    [ContextMenu("Teste: Escala Máxima (Slider = 1)")]
    private void TestMaxScale() => SetScale(1f);

    [ContextMenu("Teste: Ativar Cor Alternativa")]
    private void TestColorActive() => ToggleColor(true);

    [ContextMenu("Teste: Deixar invisível")]
    private void TestVisibilityInactive() => ToggleVisibility(false);

    [ContextMenu("Teste: Rotacionar 45°")]
    private void TestRotateModel() => RotateModel(45f);

    [ContextMenu("Teste: Resetar Tudo")]
    private void TestReset() => ResetModel();
}