using UnityEngine;
using UnityEngine.EventSystems;

namespace MyGameUtility.UI {
    public class DragUI : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler {
        public CustomAction<PointerEventData> CE_OnBeginDrag = new CustomAction<PointerEventData>();
        public CustomAction<PointerEventData> CE_OnDrag      = new CustomAction<PointerEventData>();
        public CustomAction<PointerEventData> CE_OnEndDrag   = new CustomAction<PointerEventData>();
        
        public void OnBeginDrag(PointerEventData eventData) {
            CE_OnBeginDrag.Invoke(eventData);
        }

        public void OnDrag(PointerEventData eventData) {
            CE_OnDrag.Invoke(eventData);
        }

        public void OnEndDrag(PointerEventData eventData) {
            CE_OnEndDrag.Invoke(eventData);
        }
    }
}