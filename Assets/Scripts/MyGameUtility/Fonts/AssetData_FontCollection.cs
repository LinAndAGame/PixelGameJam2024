using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace MyGameUtility.Fonts {
    [CreateAssetMenu(fileName = "FontAsset", menuName = "纯数据资源/FontAsset", order = 0)]
    public class AssetData_FontCollection : ScriptableObject {
        private static AssetData_FontCollection _I;
        public static AssetData_FontCollection I {
            get {
                if (_I == null) {
                    _I = Resources.Load<AssetData_FontCollection>("FontAsset");
                }

                return _I;
            }
        }
        
        public List<SaveData_FontAsset> AllFontAssets;

        public List<string> AllFontNames => AllFontAssets.Select(data => data.FontName).ToList();

        public TMP_FontAsset GetFontAsset(string fontName) {
            if (string.IsNullOrEmpty(fontName)) {
                return null;
            }
            
            var fontAsset = AllFontAssets.Find(data => data.FontName == fontName);
            if (fontAsset != null) {
                return fontAsset.FontAsset;
            }

            return null;
        }
    }
}