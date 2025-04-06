using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public enum Interaction
    {
        Bird,
        Man,
        Door,
        Window,
        Dog,
        Sniper,
        Antenna,
        Sheet,
        Clouds,
        Target
    }

    public static InteractionManager Instance { get; private set; }

    public bool ManLeft { get; set; }
    public bool Clouded { get; set; }
    public bool DoorOpen { get; set; }
    public bool HasTennisBall { get; set; }
    public bool HasUsedTennisBall { get; set; }
    public bool SheetRemoved { get; set; }
    public bool Raining { get; set; }
    public bool SniperMoved { get; set; }
    public bool SniperDead { get; set; }
    public bool OnTarget { get; set; }
    public bool TargetEliminated { get; set; }

    [SerializeField] private Animator skyAnimator;
    [SerializeField] private Animator birdAnimator;
    [SerializeField] private Animator poopAnimator;
    [SerializeField] private Animator manAnimator;
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private Animator tennisStuffAnimator;
    [SerializeField] private Animator[] cloudAnimators;
    [SerializeField] private Animator[] rainAnimators;
    [SerializeField] private Animator sheetAnimator;
    [SerializeField] private Animator womanAnimator;
    [SerializeField] private Animator ballAnimator;
    [SerializeField] private Animator dogAnimator;
    [SerializeField] private Animator[] sniperAnimators;
    [SerializeField] private Animator[] lightningAnimators;
    [SerializeField] private Animator deadSniperAnimator;
    [SerializeField] private Animator targetAnimator;
    [SerializeField] private Animator bodyAnimator;
    [SerializeField] private Animator missionCompleteAnimator;
    [SerializeField] private CanvasGroup manCollisionBox;
    [SerializeField] private CanvasGroup sheetCollisionBox;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform poopAnchor;
    [SerializeField] private Transform bird;

    private int poopCount;
    private int lightningCount;
    private bool ballFlying;
    private bool poopFlying;

    private void Awake() => Instance = this;

    public async void OnInteraction(Interaction interaction, int index)
    {
        if (OnTarget)
            return;

        Debug.Log($"Interaction: {interaction}");
        switch (interaction)
        {
            case Interaction.Bird:
                poopCount++;
                if (poopCount % 3 == 0)
                    await DialogManager.Instance.BirdDialogue();
                manCollisionBox.blocksRaycasts = false;
                break;
            case Interaction.Man:
                if (!ManLeft)
                    await DialogManager.Instance.ManDialogue();
                break;
            case Interaction.Door:
                if (!DoorOpen)
                {
                    // doorAnimator.Play("Open");
                    // DoorOpen = true;
                    await DialogManager.Instance.ClosedDoorDialogue();
                }
                else if (!HasTennisBall)
                {
                    tennisStuffAnimator.gameObject.SetActive(false);
                    HasTennisBall = true;
                    await DialogManager.Instance.TennisDialogue();
                }

                break;
            case Interaction.Window:
                if (HasTennisBall && !HasUsedTennisBall && !ballFlying)
                {
                    ballFlying = true;
                    ballAnchor.transform.localPosition = index switch
                    {
                        0 => new Vector2(-25, 0),
                        1 => new Vector2(-25, -22),
                        2 => new Vector2(0, -22),
                        _ => Vector2.zero
                    };
                    ballAnimator.Play("Throw");
                    await WaitForSeconds(4);
                    ballFlying = false;
                    await DialogManager.Instance.BallDialogue();
                }

                break;
            case Interaction.Dog:
                if (!HasUsedTennisBall && !ballFlying)
                    if (HasTennisBall)
                    {
                        ballFlying = true;
                        HasUsedTennisBall = true;
                        ballAnchor.transform.localPosition = Vector3.zero;
                        ballAnimator.Play("Throw");
                        await WaitForSeconds(2.5f);
                        dogAnimator.Play("Bark");
                        await WaitForSeconds(2.5f);
                        ballFlying = false;
                        Array.ForEach(sniperAnimators, animator => animator.Play("Move"));
                        await WaitForSeconds(4);
                        SniperMoved = true;
                        await DialogManager.Instance.EnemySniperMovedDialogue();
                    }
                    else
                        await DialogManager.Instance.DogDialogue();

                break;
            case Interaction.Sniper:
                if (index == 1 == SniperMoved)
                    if (SniperDead)
                        await DialogManager.Instance.EnemySniperDeadDialogue();
                    else
                        await DialogManager.Instance.EnemySniperDialogue();
                break;
            case Interaction.Antenna:
                if (Raining)
                {
                    Array.ForEach(lightningAnimators, animator => animator.gameObject.SetActive(true));
                    await WaitForSeconds(0.2f);
                    Array.ForEach(lightningAnimators, animator => animator.gameObject.SetActive(false));
                    if (SniperMoved && !SniperDead)
                    {
                        SniperDead = true;
                        deadSniperAnimator.gameObject.SetActive(true);
                        await DialogManager.Instance.EnemySniperStruckDialogue();
                    }
                    else
                    {
                        lightningCount++;
                        if (lightningCount % 3 == 0)
                            await DialogManager.Instance.LightningStruckDialogue();
                    }
                }

                break;
            case Interaction.Sheet:
                if (!SheetRemoved)
                    await DialogManager.Instance.SheetDialogue();
                break;
            case Interaction.Clouds:
                if (!Raining)
                    if (Clouded)
                    {
                        Raining = true;
                        Array.ForEach(rainAnimators, animator => animator.Play("StartRaining"));
                        womanAnimator.Play("Walk");
                        await WaitForSeconds(3.5f);
                        sheetAnimator.gameObject.SetActive(false);
                        sheetCollisionBox.blocksRaycasts = false;
                        SheetRemoved = true;
                        await DialogManager.Instance.SheetRainDialogue();
                    }
                    else if (!ManLeft && !poopFlying)
                    {
                        poopFlying = true;
                        bool hit = Mathf.Abs(bird.localPosition.x - 4) <= 0.1f;
                        poopAnchor.localPosition = new Vector2(bird.localPosition.x, poopAnchor.localPosition.y);
                        poopAnimator.Play(hit ? "Hit" : "Poop");
                        await WaitForSeconds(1.5f);
                        if (hit)
                            OnPoopHit();
                        await WaitForSeconds(0.5f);
                        poopFlying = false;
                    }

                break;
            case Interaction.Target:
                if (SheetRemoved)
                    if (!SniperDead)
                        await DialogManager.Instance.TargetWithEnemySniperDialogue();
                    else
                    {
                        OnTarget = true;
                        targetAnimator.Play("Aim");
                        await DialogManager.Instance.TargetDialogue();
                        bodyAnimator.Play("Die");
                        missionCompleteAnimator.Play("Success");
                    }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(interaction), interaction, null);
        }
    }

    private async UniTask WaitForSeconds(float seconds)
    {
        var tcs = new UniTaskCompletionSource<bool>();
        await UniTask.Delay((int)(seconds * 1000));
        tcs.TrySetResult(true);
    }

    public async void OnPoopHit()
    {
        manAnimator.Play("ManLeaving");
        skyAnimator.Play("Clouded");
        birdAnimator.SetBool("Loop", false);
        ManLeft = true;
        Clouded = true;
        await WaitForSeconds(4.75f);
        doorAnimator.Play("Open");
        DoorOpen = true;
    }
}