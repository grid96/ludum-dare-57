using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PixelPerfectHitDetector : MonoBehaviour
{
    private Image _image;
    protected Image Image { get { if (_image == null) _image = GetComponent<Image>(); return _image; } }

    [SerializeField]
    private float threshold = 0.5f;

    private void Start()
    {
        Image.alphaHitTestMinimumThreshold = threshold;
    }
}