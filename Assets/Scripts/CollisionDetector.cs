using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
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

    private void update()
    {

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            points++;
            pointText.text = points.ToString();
            other.gameObject.SetActive(false);
          
            FindObjectOfType<AudioManager>().Play("GameBonus");

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
