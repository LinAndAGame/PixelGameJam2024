namespace MyGameUtility {
    public class BaseSystemData<TSaveData, TAssetData> 
        where TSaveData : BaseSaveData<TAssetData>
        where TAssetData : BaseAssetData {
        public TSaveData SaveData;
        
        public BaseSystemData(TSaveData saveData) {
            SaveData = saveData;
        }
    }
}