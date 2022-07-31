using System;
using Modules.Mvvm.Lifecycle;
using UnityEngine;

namespace Modules.Mvvm.Views
{
    public abstract class ViewBase : MonoBehaviour { }

    public abstract class ViewBase<TViewModel> : ViewBase
    {
        public void Init(TViewModel viewModel)
        {
            if (viewModel is IDisposable disposableViewModel)
                disposableViewModel.BindLifecycleTo(gameObject);

            Bind(viewModel);
        }

        protected abstract void Bind(TViewModel viewModel);
    }
}