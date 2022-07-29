using UnityEngine;

public class CharacterContext : MonoBehaviour
{
    [SerializeField] private GameObject _root;
    [SerializeField] private Movement _movement;
    [SerializeField] private ResourceRepository _resourceRepository;

    public GameObject Root => _root;

    public Movement Movement => _movement;
    public ResourceRepository ResourceRepository => _resourceRepository;
}