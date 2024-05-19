using System;
using UnityEngine;

namespace Enemy {
    [Serializable]
    public class BeCollisionStateData {
        public Transform      TransTarget;
        public Rigidbody2D    Rigidbody2DRef;
        public float          ReflectDashDuration = 0.5f;
        public AnimationCurve ReflectDashAnimationCurve;
        public float          ReflectDashDistance = 1f;
        public ContactPoint2D ContactPoint2DRef;
    }
}