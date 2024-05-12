using System.Collections.Generic;

namespace MyGameUtility.UI {
    public class PopUpPanelProcess {
        private Stack<BaseUiPanel> _PanelQueue = new Stack<BaseUiPanel>();

        public void DisplayPanel(BaseUiPanel uiPanel) {
            _PanelQueue.Push(uiPanel);
            uiPanel.Display();
        }

        public void HideTopPanel() {
            if (_PanelQueue.Count == 0) {
                return;
            }
            
            var uiPanel = _PanelQueue.Pop();
            uiPanel.Hide();
        }
    }
}