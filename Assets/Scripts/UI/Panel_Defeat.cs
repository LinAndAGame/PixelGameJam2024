using MyGameUtility.UI;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI {
    public class Panel_Defeat : BaseUiPanel {
        public Button Btn_Restart;
        public Button Btn_Exit;

        public void Init() {
            Btn_Exit.onClick.AddListener(() => {
                Application.Quit();
            });
            Btn_Restart.onClick.AddListener(() => {
                GameManager.I.Restart();
            });
        }
    }
}