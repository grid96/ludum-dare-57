using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public static IntroManager Instance { get; private set; }
    
    public IntroManager() => Instance = this;
    
    private void Start() => Init();
    
    private async void Init()
    {
        await GridGamesIntroManager.Instance.Play();
        await DialogManager.Instance.TestDialog();
    }
}
