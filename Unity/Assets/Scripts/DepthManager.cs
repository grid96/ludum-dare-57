using DG.Tweening;
using UnityEngine;

[ExecuteInEditMode]
public class DepthManager : MonoBehaviour
{
    public static DepthManager Instance { get; private set; }

    public float CurrentDepth => depth;
    public int TargetDepth { get; private set; }
    public bool IsOnTarget => Mathf.Approximately(depth, TargetDepth);

    [SerializeField] private float depth;

    private Tween tween;
    
    private DepthManager() => Instance = this;

    private void Awake()
    {
        Instance = this;
        TargetDepth = (int)depth;
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y == 0)
            return;
        GoToDepth(Mathf.Clamp(TargetDepth + (int)Mathf.Sign(Input.mouseScrollDelta.y), 0, 9));
    }

    public void GoToDepth(int targetDepth)
    {
        TargetDepth = targetDepth;
        if (tween != null && tween.IsActive())
            tween.Kill();
        tween = DOTween.To(() => depth, x => depth = x, targetDepth, 0.5f);
    }
}