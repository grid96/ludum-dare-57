using UnityEngine;

public static class TransformExtensions
{
    public static RectTransform ToRect(this Transform transform) => (RectTransform)transform;
}
