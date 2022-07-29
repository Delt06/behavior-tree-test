using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private CharacterContext _context;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Resource resource))
            _context.ResourceRepository.Collect(resource);
    }
}