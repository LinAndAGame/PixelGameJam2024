using System.Collections.Generic;
using System.Linq;
using MyGameExpand;
using UnityEngine;

namespace MyGameUtility {
    public class SaveData_FrameAnimationInfo {
        public List<SaveData_FrameAnimationEvent> AllFrameAnimationEvents = new List<SaveData_FrameAnimationEvent>();
        public List<byte[]>                       AllOverrideSpriteDatas  = new List<byte[]>();

        [SerializeField]
        private string AssetDataPath;

        public AssetData_FrameAnimationInfo AssetData => Resources.Load<AssetData_FrameAnimationInfo>(AssetDataPath);

        public List<Sprite> CurFrameSprites {
            get {
                List<Sprite> result = new List<Sprite>();
                if (AllOverrideSpriteDatas.IsNullOrEmpty()) {
                    result.AddRange(OriginalSprites);
                }
                else {
                    result.AddRange(OverrideSprites);
                }

                return result;
            }
        }

        public List<Sprite> OriginalSprites => AssetData.FrameSprites;
        public List<Sprite> OverrideSprites {
            get {
                List<Sprite> result = new List<Sprite>();
                foreach (var overrideSpriteData in AllOverrideSpriteDatas) {
                    Texture2D texture2D = new Texture2D(0,0);
                    texture2D.LoadImage(overrideSpriteData);
                    result.Add(Sprite.Create(texture2D, new Rect(0,0,texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f)));
                }
                return result;
            }
        }

        public SaveData_FrameAnimationInfo() { }

        public SaveData_FrameAnimationInfo(AssetData_FrameAnimationInfo assetData) {
            AssetDataPath = assetData.ResourcePath;
            foreach (var assetDataFrameAnimationEvent in assetData.AllAnimationEvents) {
                AllFrameAnimationEvents.Add(assetDataFrameAnimationEvent.GetSaveData());
            }
        }
    }
}