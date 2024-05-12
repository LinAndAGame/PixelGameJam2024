using UnityEngine;
using UnityEngine.EventSystems;

namespace MyGameUtility.UI {
    public class DropUISlot : MonoBehaviour,IDropHandler {
        public CustomAction<PointerEventData> CE_OnDrop = new CustomAction<PointerEventData>();
        
        public void OnDrop(PointerEventData eventData) {
            if (eventData.pointerDrag == null) {
                return;
            }

            CE_OnDrop.Invoke(eventData);
        }
    }
}