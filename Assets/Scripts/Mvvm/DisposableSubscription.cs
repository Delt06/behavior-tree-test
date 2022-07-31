using System;

namespace Mvvm
{
    public class DisposableSubscription<T> : IDisposable
    {
        private readonly Action _callback;
        private readonly IReactiveProperty<T> _reactiveProperty;

        public DisposableSubscription(IReactiveProperty<T> reactiveProperty, Action<T> onValueChange)
        {
            _reactiveProperty = reactiveProperty;
            _callback = () => onValueChange(reactiveProperty.Value);
            _reactiveProperty.ValueChanged += _callback;
        }

        public void Dispose()
        {
            _reactiveProperty.ValueChanged -= _callback;
        }
    }
}