/*
 *  不完善，当前只有X轴Layout
 */

using System;
using UnityEngine;

namespace MyGameUtility.Layout {
    [ExecuteInEditMode]
    public class Layout3D : MonoBehaviour {
        public Vector3 ChildSize = Vector3.one;
        public Vector3 Interval;
        public bool    Reverse;

        private void Update() {
            int   childCount         = this.transform.childCount;
            float childTotalWidth    = childCount * ChildSize.x;
            float intervalTotalWidth = (childCount - 1) * Interval.x;
            float totalWidth         = childTotalWidth + intervalTotalWidth;
            float startX             = -totalWidth / 2 + ChildSize.x / 2;

            if (Reverse) {
                for (int i = childCount - 1; i >= 0; i--) {
                    Transform childTrans = this.transform.GetChild(i);
                    childTrans.localPosition = new Vector3(startX + i * (ChildSize.x + Interval.x), 0, 0);
                }
            }
            else {
                for (int i = 0; i < childCount; i++) {
                    Transform childTrans = this.transform.GetChild(i);
                    childTrans.localPosition = new Vector3(startX + i * (ChildSize.x + Interval.x), 0, 0);
                }
            }
        }
    }
}