using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ResourceSystem
{
    public class ResourceRepository : MonoBehaviour
    {
        public HashSet<Resource> Resources { get; } = new();

        private void Awake()
        {
            Resources.AddRange(FindObjectsOfType<Resource>());

            foreach (var resource in Resources)
            {
                resource.Init(this);
            }
        }

        public void OnCollected(Resource resource) => Resources.Remove(resource);
    }
}