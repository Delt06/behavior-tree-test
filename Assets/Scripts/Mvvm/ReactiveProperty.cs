using System;
using System.Collections.Generic;

namespace Mvvm
{
    public class ReactiveProperty<T> : IReactiveProperty<T>
    {
        private T _value;

        public ReactiveProperty(T value = default) => _value = value;

        public T Value
        {
            get => _value;
            set
            {
                if (EqualityComparer<T>.Default.Equals(_value, value)) return;
                _value = value;
                ValueChanged?.Invoke();
            }
        }

        public event Action ValueChanged;
    }
}