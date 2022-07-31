using System;
using Modules.Mvvm;

namespace Game.Characters
{
    public class CharacterResourceViewModel : IDisposable
    {
        private readonly CharacterModel _model;
        private readonly ReactiveProperty<int> _resources;

        public CharacterResourceViewModel(CharacterModel model)
        {
            _model = model;
            _resources = new ReactiveProperty<int>(model.Resources);
            model.ResourcesChanged += OnResourcesChanged;
        }

        public IReactiveProperty<int> Resources => _resources;

        public void Dispose()
        {
            _model.ResourcesChanged -= OnResourcesChanged;
        }

        private void OnResourcesChanged() => _resources.Value = _model.Resources;
    }
}