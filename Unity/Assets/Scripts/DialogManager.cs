    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public partial class DialogManager
    {
        [SerializeField] private RuntimeAnimatorController avatar;
        
        public async UniTask TestDialog()
        {
            await ShowMessage(avatar, "Hello World!");
            await ClickToContinue();
            await ShowMessage(avatar, "This is a test dialog.");
            await ClickToContinue();
            await ShowMessage(avatar, "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.");
            await ClickToContinue();
            await ShowMessage(avatar, "At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.");
            await ClickToContinue();
            await ShowMessage(avatar, "This is the last message.");
            await ClickToContinue();
            await ShowMessage(avatar, "Goodbye!");
            await ClickToContinue();
            await Hide();
        }
    }