using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Obstacle")
        {
            playerMovement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }   
}
