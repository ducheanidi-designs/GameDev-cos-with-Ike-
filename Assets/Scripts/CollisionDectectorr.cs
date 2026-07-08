using UnityEngine;
using UnityEngine.UI;

public class CollisionDectectorr : MonoBehaviour
{
    [SerializeField] private PRACTPlayerMovement playerMovement;
    [SerializeField] private int points;
    [SerializeField] private Text pointText;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private float radius;
    [SerializeField] private float force;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Obstacle")
        {
            playerMovement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();

            FindObjectOfType<AudioManager>().Play("CrashLose");

            explosion.transform.position = other.transform.position;
            explosion.Play();
            Explode();
        }
    }

  
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, points);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
    }
}
