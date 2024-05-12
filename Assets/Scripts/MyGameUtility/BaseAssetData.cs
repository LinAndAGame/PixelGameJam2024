using System;
using UnityEngine;

namespace MyGameUtility {
    public abstract class BaseAssetData : ScriptableObject {
        [SerializeField]
        private string _ResourcePath;
        public string ResourcePath => _ResourcePath;

        private void OnValidate() {
            RefreshResourcePath();
        }

        public void RefreshResourcePath() {
            _ResourcePath = OtherUtility.GetResourcePath(this);
        }
    }
}