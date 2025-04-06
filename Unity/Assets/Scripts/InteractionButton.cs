using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InteractionButton : MonoBehaviour
{
    [SerializeField] private InteractionManager.Interaction interaction;
    [SerializeField] private int layer;
    [SerializeField] private int index;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        if (interaction != InteractionManager.Interaction.Clouds && Mathf.Abs(layer - DepthManager.Instance.CurrentDepth) > 1.25f)
            return;
        InteractionManager.Instance.OnInteraction(interaction, index);
    }
}