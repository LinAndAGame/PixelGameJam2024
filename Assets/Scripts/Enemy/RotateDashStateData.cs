using System;
using UnityEngine;

namespace Enemy {
    [Serializable]
    public class RotateDashStateData {
        public Transform      TransformTarget;
        public Rigidbody2D    Rigidbody2DRef;
        public float          MinRotateZ;
        public float          MaxRotateZ;
        public float          RotateDuration;
        public AnimationCurve RotateCurve;
        public SpriteRenderer SpriteRendererRef;
        public float          FlashDuration = 0.3f;
        public int            FlashTimes    = 10;
        public AnimationCurve FlashCurve;
        public float          DashDuration;
        public float          DashDistance;
        public AnimationCurve DashCurve;
    }
}