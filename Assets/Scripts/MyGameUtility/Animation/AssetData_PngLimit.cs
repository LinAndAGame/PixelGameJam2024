using UnityEngine;

namespace MyGameUtility {
    [CreateAssetMenu(fileName = "PngLimit", menuName = "纯数据资源/FrameAnimation/PngLimit")]
    public class AssetData_PngLimit : ScriptableObject {
        public Vector2Int Size = new Vector2Int(64, 64);
    }
}