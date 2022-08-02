using System;

namespace Game.Characters
{
    public class CharacterModel
    {
        private readonly int _resourceCapacity;
        private int _resources;

        public CharacterModel(int resourceCapacity) => _resourceCapacity = resourceCapacity;

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

        public bool IsFull => _resources >= _resourceCapacity;

        public void FreeResources() => Resources = 0;

        public event Action ResourcesChanged;

        public void AddResource()
        {
            if (IsFull) throw new InvalidOperationException("Resource storage is full.");
            Resources++;
        }
    }
}