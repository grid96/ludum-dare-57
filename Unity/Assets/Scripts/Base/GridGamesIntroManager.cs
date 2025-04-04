using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GridGamesIntroManager : MonoBehaviour
{
    public static GridGamesIntroManager Instance { get; private set; }
    
    [SerializeField] private Animator animator;
    
    private const string animationStateName = "Intro";
    private event EventHandler completed;
    
    public GridGamesIntroManager() => Instance = this;

    public async UniTask Play()
    {
        var tcs = new UniTaskCompletionSource<bool>();
        void Handler(object sender, EventArgs e) => tcs.TrySetResult(true);
        completed += Handler;
        animator.Play(animationStateName);
        await tcs.Task;
        completed -= Handler;
    }
    
    public void Complete()
    {
        completed?.Invoke(this, EventArgs.Empty);
    }
}
