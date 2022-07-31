using UnityEngine;

namespace ResourceSystem
{
    public class Resource : MonoBehaviour
    {
        private ResourceRepository _repository;
        public bool IsCollected { get; private set; }

        public void Init(ResourceRepository repository)
        {
            _repository = repository;
        }

        public void Collect()
        {
            if (IsCollected)
                return;
            Destroy(gameObject);
            IsCollected = true;
            _repository.OnCollected(this);
        }
    }
}