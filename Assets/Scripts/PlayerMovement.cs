using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forwardSpeed = 2000f;
    [SerializeField] private float sidewaysSpeed = 1000f;

    [SerializeField] private PlayerInput playerInput;
    private InputAction moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       moveAction = playerInput.actions["Move"];
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, forwardSpeed * Time.deltaTime); 
        Vector2 input = moveAction.ReadValue<Vector2>();

        if (input.x > 0)
        {
            rb.AddForce(sidewaysSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (input.x < 0)
        {
            rb.AddForce(-sidewaysSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
