    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public partial class DialogManager
    {
        [SerializeField] private RuntimeAnimatorController avatar;
        
        public async UniTask MissionDialogue()
        {
            await ShowMessage(avatar, "The mission is clear:\nEliminate the target and then get out of here! Understood?");
            await ClickToContinue();
            await Hide();
        }
        
        public async UniTask ClosedDoorDialogue()
        {
            await ShowMessage(avatar, "There could be something useful behind that door. Maybe someone can open it for us...");
            await ClickToContinue();
            await Hide();
        }
        
        // on the third missed poop
        public async UniTask BirdDialogue()
        {
            await ShowMessage(avatar, "Man, these birds really don't like that building.");
            await ClickToContinue();
            await ShowMessage(avatar, "Is there a chance of them hitting that guy over there?\nNah, no way...");
            await ClickToContinue();
            await Hide();
        }
        
        public async UniTask BirdHitDialogue()
        {
            await ShowMessage(avatar, "Oh shit!\n...\nQuite literally...");
            await ClickToContinue();
            await Hide();
        }
        
        public async UniTask TennisDialogue()
        {
            await ShowMessage(avatar, "I'm always up for a game of tennis!\n...\nNot right now though...");
            await ClickToContinue();
            await Hide();
        }
        
        public async UniTask BallDialogue()
        {
            await ShowMessage(avatar, "Good throw! I don't think that did anything though...");
            await ClickToContinue();
            await Hide();
        }
        
        public async UniTask EnemySniperDialogue()
        {
            await ShowMessage(avatar, "There is an enemy sniper on the roof. Dang!");
            await ClickToContinue();
            await ShowMessage(avatar, "We need to eliminate him before we can approach the target.");
            await ClickToContinue();
            await Hide();
        }
        
        public async UniTask EnemySniperMovedDialogue()
        {
            await ShowMessage(avatar, "Seems like that got the snipers attention.");
            await ClickToContinue();
            await Hide();
        }
        
        public async UniTask SheetDialogue()
        {
            await ShowMessage(avatar, "Those damn sheets are blocking the view.");
            await ClickToContinue();
            await ShowMessage(avatar, "If it just wasn't such good weather today...");
            await ClickToContinue();
            await Hide();
        }
        
        public async UniTask LaundryDialogue()
        {
            await ShowMessage(avatar, "Guess she pushed her luck too far. Those sheets aren't going on any bed soon.");
            await ClickToContinue();
            await Hide();
        }
        
        public async UniTask TargetWithEnemySniperDialogue()
        {
            await ShowMessage(avatar, "I have a clear view on the target, but I can't blow up our cover with that enemy sniper in the area.");
            await ClickToContinue();
            await Hide();
        }
        
        // on the third uneffective strike
        public async UniTask LightningStruckDialogue()
        {
            await ShowMessage(avatar, "I guess lightning really likes to strike the highest.");
            await ClickToContinue();
            await ShowMessage(avatar, "I wonder if we can use that to our advantage somehow...");
            await ClickToContinue();
            await Hide();
        }
        
        public async UniTask EnemySniperStruckDialogue()
        {
            await ShowMessage(avatar, "Holy moly! That dude is fried for good!");
            await ClickToContinue();
            await Hide();
        }
        
        public async UniTask TargetDialogue()
        {
            await ShowMessage(avatar, "Ready to fire on your mark!");
            await ClickToContinue();
            await Hide();
        }
    }