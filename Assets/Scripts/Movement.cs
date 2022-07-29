using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Rigidbody2D _rigidbody;

    public Vector2 Direction { get; set; }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Direction * _speed;
    }
}