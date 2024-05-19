
    using MyGameUtility.UI;
    using UnityEngine;
    using UnityEngine.UI;

    public class Panel_Win : BaseUiPanel {
        public Button Btn_Exit;

        public void Init() {
            Btn_Exit.onClick.AddListener(() => {
                Application.Quit();
            });
        }
    }