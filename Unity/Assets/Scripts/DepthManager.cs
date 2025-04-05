using DG.Tweening;
using UnityEngine;

public class DepthManager : MonoBehaviour
{
    public static DepthManager Instance { get; private set; }

    public float CurrentDepth { get; private set; }
    public int TargetDepth { get; private set; }
    public bool IsOnTarget => Mathf.Approximately(CurrentDepth, TargetDepth);
    
    private Tween tween;

    private void Awake() => Instance = this;

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
        tween = DOTween.To(() => CurrentDepth, x => CurrentDepth = x, targetDepth, 0.5f);
    }
}
