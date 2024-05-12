using System;
using MyGameExpand;
using UnityEngine;

namespace MyGameUtility.Layout {
    [ExecuteAlways]
    public class VerticalLayout3D : MonoBehaviour {
        public Layout3DAxisEnum Layout3DAxis = Layout3DAxisEnum.Y;
        public float            Interval;

        public float ChildHeight = 1;
        
        [Range(0, 1)]
        public float Align = 0.5f;

        private void Update() {
            float childCount  = this.transform.childCount;
            float totalHeight =  childCount * ChildHeight + (childCount - 1 ) *Interval;
            float startHeight = totalHeight * Align;
            for (int i = 0; i < childCount; i++) {
                var   childTrans = this.transform.GetChild(i);
                float curHeight  = startHeight - (Interval + ChildHeight) * i - ChildHeight / 2f;
                switch (Layout3DAxis) {
                    case Layout3DAxisEnum.X:
                        break;
                    case Layout3DAxisEnum.Y:
                        childTrans.transform.localPosition = new Vector3(0, curHeight, 0);
                        break;
                    case Layout3DAxisEnum.Z:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}