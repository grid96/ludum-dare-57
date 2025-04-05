using UnityEngine;
using UnityEngine.UI;

public class DepthLayer : MonoBehaviour
{
    private static readonly int BlurSize = Shader.PropertyToID("_BlurSize");

    public int Depth => depth;

    [SerializeField] private int depth;
    [SerializeField] private Material material;
    [SerializeField] private Image bar;

    private void Update()
    {
        material.SetFloat(BlurSize, Mathf.Abs(DepthManager.Instance.CurrentDepth - depth) * 2);
        bar.raycastTarget = DepthManager.Instance.TargetDepth != depth;
        bar.transform.localScale = Vector3.one * (1.5f - 0.5f * Mathf.Clamp01(Mathf.Abs(DepthManager.Instance.CurrentDepth - depth)));
    }

    public void OnButtonClick()
    {
        DepthManager.Instance.GoToDepth(depth);
    }
}