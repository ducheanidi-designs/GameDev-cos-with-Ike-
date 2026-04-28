using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private int points;
    [SerializeField] private Text pointText;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Obstacle")
        {
            playerMovement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();

            //Instantiate(CrashLose, transform.position, transform.rotation);
            //GameManager.instance.EndGame();

            FindObjectOfType<AudioManager>().Play("CrashLose");

            //Destory(gameObject);
            
        }
    }   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            points++;
            pointText.text = points.ToString();
            other.gameObject.SetActive(false);

            //Instantiate(GameBonus, transform.position, transform.rotation);
            //GameManager.instance.EndGame();

            FindObjectOfType<AudioManager>().Play("GameBonus");

            //Destory(gameObject);
        }
    }
}
