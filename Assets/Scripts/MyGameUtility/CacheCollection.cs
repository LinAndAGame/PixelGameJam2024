namespace MyGameUtility {
    public class CacheCollection {
        public ValueCacheCollection  Value = new ValueCacheCollection();
        public CustomEventCollection Event = new CustomEventCollection();

        public void Clear() {
            Value.Clear();
            Event.Clear();
        }
    }
}