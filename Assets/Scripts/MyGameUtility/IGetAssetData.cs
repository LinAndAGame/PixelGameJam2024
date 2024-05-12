namespace MyGameUtility {
    public interface IGetAssetData<T> where T : BaseAssetData {
        T GetAssetData();
    }
}