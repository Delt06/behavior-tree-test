using UnityEngine;

namespace Game.ResourceSystem
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private Vector2 _collectionTimeRange = new(1f, 2f);
        private float _collectionProgress;

        private float _collectionTime;

        private ResourceRepository _repository;
        public bool IsCollected { get; private set; }

        private void Awake()
        {
            _collectionTime = Random.Range(_collectionTimeRange.x, _collectionTimeRange.y);
        }

        public void Init(ResourceRepository repository)
        {
            _repository = repository;
        }

        public bool Collect(float deltaTime)
        {
            if (IsCollected)
                return false;

            _collectionProgress += deltaTime / _collectionTime;
            if (_collectionProgress < 1f) return false;

            Destroy(gameObject);
            IsCollected = true;
            _repository.OnCollected(this);
            return true;
        }
    }
}