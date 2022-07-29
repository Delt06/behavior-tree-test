using UnityEngine;

public class CharacterContext : MonoBehaviour
{
    [SerializeField] private Movement _movement;

    public Movement Movement => _movement;
}