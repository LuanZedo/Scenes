using UnityEngine;

public class ModelController : MonoBehaviour
{
    [Header("Configurações do Modelo 3D")]
    [Tooltip("Selecione o Transform do seu modelo 3D.")]
    [SerializeField] private Transform modelTransform;

    [Tooltip("Selecione o MeshRenderer do seu modelo 3D.")]
    [SerializeField] private MeshRenderer modelRenderer;

    public void SetScale(float value)
    {
        Debug.Log($"[ModelController] Método SetScale chamado. Valor: {value}");
    }

    public void ToggleVisibility(bool isVisible)
    {
        Debug.Log($"[ModelController] Método ToggleVisibility chamado. Visível: {isVisible}");
    }

    public void ResetModel()
    {
        Debug.Log("[ModelController] Método ResetModel chamado.");
    }
}