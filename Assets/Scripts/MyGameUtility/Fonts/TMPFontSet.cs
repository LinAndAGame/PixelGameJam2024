using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace MyGameUtility.Fonts {
    [RequireComponent(typeof(TMP_Text))]
    public class TMPFontSet : MonoBehaviour {
        [ValueDropdown(nameof(AllFontNames))]
        public string UsedFontName;

        private List<string> AllFontNames => AssetData_FontCollection.I.AllFontNames;

        private TMP_Text _TMPText;
        private TMP_Text TMPText {
            get {
                if (_TMPText == null) {
                    _TMPText = this.GetComponent<TMP_Text>();
                }
                
                return _TMPText;
            }
        }

        private void OnEnable() {
            RefreshTextMaterial();
        }

        private void OnValidate() {
            RefreshTextMaterial();
        }

        [Button]
        public void RefreshTextMaterial() {
            TMPText.font = AssetData_FontCollection.I.GetFontAsset(UsedFontName);
        }
    }
}