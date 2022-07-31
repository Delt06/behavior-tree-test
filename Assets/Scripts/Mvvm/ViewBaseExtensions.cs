using Mvvm.Lifecycle;
using TMPro;

namespace Mvvm
{
    public static class ViewBaseExtensions
    {
        public static void BindText(this ViewBase view, TMP_Text text, IReactiveProperty<int> reactiveProperty)
        {
            void OnValueChange(int value) => text.SetText("{0:0}", value);
            var subscription = new DisposableSubscription<int>(reactiveProperty, OnValueChange);
            subscription.BindLifecycleTo(view.gameObject);
            OnValueChange(reactiveProperty.Value);
        }
    }
}