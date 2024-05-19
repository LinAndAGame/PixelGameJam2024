using System;
using UnityEngine;

namespace Enemy {
    [Serializable]
    public class BossDashStateData {
        public Transform      Trans_DashTarget;
        public Transform      TransTarget;
        public Rigidbody2D    Rigidbody2DRef;
        public float          DashDuration;
        public float          DashDistance;
        public AnimationCurve DashCurve;
        public float          RotateLockDuration = 1;
    }
}