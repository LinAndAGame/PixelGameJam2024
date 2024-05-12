namespace MyGameUtility {
    public interface IGetSaveData<TAssetData, TSaveData>
        where TAssetData : BaseAssetData 
    where TSaveData : BaseSaveData<TAssetData> {
        TSaveData GetSaveData(TAssetData assetData);
    }
}