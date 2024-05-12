using System;
using System.Collections.Generic;

namespace MyGameUtility {
    public abstract class BaseValueCache<T> {
        public event Action OnValueChanged;
        public CustomAction OnCustomValueChanged = new CustomAction();
        
        protected List<ValueCacheElement<T>> ElementCaches = new List<ValueCacheElement<T>>();

        public void RemoveElement(ValueCacheElement<T> element) {
            ElementCaches.Remove(element);
        }

        public List<ValueCacheElement<T>> AllElementCachesCopy => new List<ValueCacheElement<T>>(ElementCaches);

        public abstract T GetValue();

        protected void OnValueChangedInvoke() {
            OnValueChanged?.Invoke();
            OnCustomValueChanged.Invoke();
        }
    }
}