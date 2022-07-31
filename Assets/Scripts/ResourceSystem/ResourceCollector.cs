using Characters;
using UnityEngine;
using UnityEngine.Scripting;

namespace ResourceSystem
{
    public class ResourceCollector : MonoBehaviour
    {
        private CharacterContext _characterContext;

        [Preserve]
        public void Construct(CharacterContext characterContext)
        {
            _characterContext = characterContext;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Resource resource)) return;
            resource.Collect();
            _characterContext.Model.AddResource();
        }
    }
}