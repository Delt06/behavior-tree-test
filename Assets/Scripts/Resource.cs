using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool IsCollected { get; private set; }

    public void Collect()
    {
        if (IsCollected)
            return;
        Destroy(gameObject);
        IsCollected = true;
    }
}