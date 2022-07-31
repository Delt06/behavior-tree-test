using System;

namespace Characters
{
    public class CharacterModel
    {
        private int _resources;

        public int Resources
        {
            get => _resources;
            private set
            {
                if (_resources == value) return;
                _resources = value;
                ResourcesChanged?.Invoke();
            }
        }

        public event Action ResourcesChanged;

        public void AddResource() => Resources++;
    }
}