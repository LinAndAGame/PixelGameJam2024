using UnityEngine;

namespace MyGameUtility.UI {
    public abstract class BaseUiPanel : MonoBehaviour {
        public virtual void Display() {
            this.gameObject.SetActive(true);
        }

        public virtual void Hide() {
            this.gameObject.SetActive(false);
        }

        public virtual void DestroySelf() {
            
        }
    }
}