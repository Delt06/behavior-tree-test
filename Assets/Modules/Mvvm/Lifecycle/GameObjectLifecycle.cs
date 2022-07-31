using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Mvvm.Lifecycle
{
    public sealed class GameObjectLifecycle : MonoBehaviour
    {
        private readonly List<IDisposable> _disposableObjects = new();

        private void OnDestroy()
        {
            foreach (var disposable in _disposableObjects)
            {
                disposable.Dispose();
            }

            _disposableObjects.Clear();
        }

        public void AddDisposable(IDisposable disposable) =>
            _disposableObjects.Add(disposable);
    }
}