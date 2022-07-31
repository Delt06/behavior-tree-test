using System;
using UnityEngine;

namespace Mvvm.Lifecycle
{
    public static class DisposableExtensions
    {
        public static void BindLifecycleTo(this IDisposable disposable, GameObject gameObject)
        {
            if (!gameObject.TryGetComponent(out GameObjectLifecycle lifecycle))
                lifecycle = gameObject.AddComponent<GameObjectLifecycle>();

            lifecycle.AddDisposable(disposable);
        }
    }
}