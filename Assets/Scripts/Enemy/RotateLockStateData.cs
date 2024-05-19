using System;
using UnityEngine;

namespace Enemy {
    [Serializable]
    public class RotateLockStateData {
        public Transform Trans_Self;
        public Transform Trans_Target;
        public float     RotateLockDuration = 1f;
    }
}