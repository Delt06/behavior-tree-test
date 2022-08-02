using System.Collections.Generic;
using Game.Characters;
using UnityEngine;
using UnityEngine.Scripting;

namespace Game.ResourceSystem
{
    public class ResourceCollector : MonoBehaviour
    {
        private readonly List<Resource> _contacts = new();
        private CharacterContext _characterContext;

        [Preserve]
        public void Construct(CharacterContext characterContext)
        {
            _characterContext = characterContext;
        }

        private void FixedUpdate()
        {
            for (var index = _contacts.Count - 1; index >= 0 && !_characterContext.Model.IsFull;)
            {
                var resource = _contacts[index];
                if (!resource.Collect(Time.deltaTime)) break;

                _characterContext.Model.AddResource();
                break;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Resource resource)) return;
            _contacts.Add(resource);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Resource resource)) return;
            _contacts.Remove(resource);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_characterContext.Model.IsFull) return;
            if (!other.TryGetComponent(out Resource resource)) return;
            if (!resource.Collect(Time.deltaTime)) return;

            _characterContext.Model.AddResource();
        }
    }
}