using UnityEngine;

public class firstCollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.collider.name);
    }
}

