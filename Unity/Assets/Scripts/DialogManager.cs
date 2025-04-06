using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public partial class DialogManager
{
    [SerializeField] private RuntimeAnimatorController avatar;

    public async UniTask MissionDialogue()
    {
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "The mission is clear:\nEliminate the target and then get out of here! Understood?");
        await WaitForSeconds(3);
        if (currentMessageId == id)
            await Hide();
    }

    private bool closedDoorDialogueShown;

    public async UniTask ClosedDoorDialogue()
    {
        if (closedDoorDialogueShown)
            return;
        closedDoorDialogueShown = true;
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "There could be something useful behind that door. Maybe someone can open it for us...");
        await WaitForSeconds(3);
        if (currentMessageId == id)
            await Hide();
        closedDoorDialogueShown = false;
    }

    private bool manDialogueShown;

    public async UniTask ManDialogue()
    {
        if (manDialogueShown)
            return;
        manDialogueShown = true;
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "Nope, that's not our target.");
        await WaitForSeconds(3);
        if (currentMessageId == id)
            await Hide();
        manDialogueShown = false;
    }

    // on the third missed poop
    private bool birdDialogueShown;

    public async UniTask BirdDialogue()
    {
        if (birdDialogueShown)
            return;
        birdDialogueShown = true;
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "Man, these birds really don't like that building.");
        await WaitForSeconds(2);
        if (currentMessageId == id)
        {
            await ShowMessage(avatar, "Is there a chance of them hitting that guy over there?");
            await WaitForSeconds(2);
            if (currentMessageId == id)
            {
                await ShowMessage(avatar, "Nah, no way...");
                await WaitForSeconds(3);
            }
        }

        if (currentMessageId == id)
            await Hide();
        birdDialogueShown = false;
    }

    public async UniTask BirdHitDialogue()
    {
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "Oh shit!\n...\nQuite literally...");
        await WaitForSeconds(3);
        if (currentMessageId == id)
            await Hide();
    }

    public async UniTask TennisDialogue()
    {
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "I'm always up for a game of tennis!");
        await WaitForSeconds(2);
        if (currentMessageId == id)
        {
            await ShowMessage(avatar, "Just not right now though...");
            await WaitForSeconds(3);
        }

        if (currentMessageId == id)
            await Hide();
    }

    private bool dogDialogueShown;

    public async UniTask DogDialogue()
    {
        if (dogDialogueShown)
            return;
        dogDialogueShown = true;
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "Aww, cute doggy. I wonder what he's dreaming of...");
        await WaitForSeconds(3);
        if (currentMessageId == id)
            await Hide();
        dogDialogueShown = false;
    }

    private bool barDialogueShown;

    public async UniTask BallDialogue()
    {
        if (barDialogueShown)
            return;
        barDialogueShown = true;
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "Good throw! I don't think that did anything though...");
        await WaitForSeconds(3);
        if (currentMessageId == id)
            await Hide();
        barDialogueShown = false;
    }

    private bool enemySniperDialogueShown;

    public async UniTask EnemySniperDialogue()
    {
        if (enemySniperDialogueShown)
            return;
        enemySniperDialogueShown = true;
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "There is an enemy sniper on the roof. Dang!");
        await WaitForSeconds(2);
        if (currentMessageId == id)
        {
            await ShowMessage(avatar, "We need to eliminate him before we can approach the target.");
            await WaitForSeconds(3);
        }

        if (currentMessageId == id)
            await Hide();
        enemySniperDialogueShown = false;
    }

    public async UniTask EnemySniperMovedDialogue()
    {
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "Seems like that got the snipers attention.");
        await WaitForSeconds(3);
        if (currentMessageId == id)
            await Hide();
    }

    private bool sheetDialogueShown;

    public async UniTask SheetDialogue()
    {
        if (sheetDialogueShown)
            return;
        sheetDialogueShown = true;
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "Those damn sheets are blocking the view.");
        await WaitForSeconds(2);
        if (currentMessageId == id)
        {
            await ShowMessage(avatar, "If it just wasn't such good weather today...");
            await WaitForSeconds(3);
        }

        if (currentMessageId == id)
            await Hide();
        sheetDialogueShown = false;
    }

    public async UniTask SheetRainDialogue()
    {
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "Guess she pushed her luck too far. Those sheets aren't going on a bed any time soon.");
        await WaitForSeconds(3);
        if (currentMessageId == id)
            await Hide();
    }

    private bool targetWithEnemySniperDialogueShown;

    public async UniTask TargetWithEnemySniperDialogue()
    {
        if (targetWithEnemySniperDialogueShown)
            return;
        targetWithEnemySniperDialogueShown = true;
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "I have a clear view on the target, but I can't blow up our cover with that enemy sniper in the area.");
        await WaitForSeconds(3);
        if (currentMessageId == id)
            await Hide();
        targetWithEnemySniperDialogueShown = false;
    }

    // on the third uneffective strike
    private bool lightningDialogueShown;

    public async UniTask LightningStruckDialogue()
    {
        if (lightningDialogueShown)
            return;
        lightningDialogueShown = true;
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "I guess lightning really likes to strike the highest point.");
        await WaitForSeconds(2);
        if (currentMessageId == id)
        {
            await ShowMessage(avatar, "I wonder if we can use that to our advantage somehow...");
            await WaitForSeconds(3);
        }

        if (currentMessageId == id)
            await Hide();
        lightningDialogueShown = false;
    }

    public async UniTask EnemySniperStruckDialogue()
    {
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "Holy moly! That dude is fried for good!");
        await WaitForSeconds(3);
        if (currentMessageId == id)
            await Hide();
    }

    private bool sniperDeadDialogueShown;

    public async UniTask EnemySniperDeadDialogue()
    {
        if (sniperDeadDialogueShown)
            return;
        sniperDeadDialogueShown = true;
        var id = currentMessageId = Guid.NewGuid();
        await ShowMessage(avatar, "I think he's toast.");
        await WaitForSeconds(3);
        if (currentMessageId == id)
            await Hide();
        sniperDeadDialogueShown = false;
    }

    public async UniTask TargetDialogue()
    {
        _ = BreathDialogue();
        await ShowMessage(avatar, "Ready to fire on your mark!");
        await WaitForSeconds(0.5f);
        await ClickToContinue();
        currentMessageId = Guid.NewGuid();
        await Hide();
    }

    private async UniTask BreathDialogue()
    {
        var id = currentMessageId = Guid.NewGuid();
        await WaitForSeconds(10);
        if (currentMessageId == id)
            await ShowMessage(avatar, "Come on, I can't hold my breath that long.");
    }
}