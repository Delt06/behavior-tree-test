using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceRepository : MonoBehaviour
{
    public HashSet<Resource> Resources { get; } = new();

    private void Awake()
    {
        Resources.AddRange(FindObjectsOfType<Resource>());
    }

    public void Collect(Resource resource)
    {
        resource.Collect();
        Resources.Remove(resource);
    }
}