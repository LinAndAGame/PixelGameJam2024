using System;
using TMPro;
using UnityEngine;

namespace MyGameUtility.Fonts {
    [Serializable]
    public class SaveData_FontAsset {
        public string        FontName;
        [SerializeField]
        private TMP_FontAsset OriginalFontAsset;

        public SaveData_FontAsset() { }
        
        [SerializeField, Sirenix.OdinInspector.ReadOnly]
        private TMP_FontAsset _OverrideFontAsset;
        public TMP_FontAsset OverrideFontAsset {
            get => _OverrideFontAsset;
            set => _OverrideFontAsset = value;
        }

        public TMP_FontAsset FontAsset => OverrideFontAsset == null ? OriginalFontAsset : OverrideFontAsset;
    }
}