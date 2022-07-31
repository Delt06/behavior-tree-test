using Characters;
using UnityEngine;

namespace ResourceSystem
{
    public class ResourceCollector : MonoBehaviour
    {
        [SerializeField] private CharacterModelRef _characterModel;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Resource resource)) return;
            resource.Collect();
            _characterModel.Model.AddResource();
        }
    }
}