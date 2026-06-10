using UnityEngine;
using UnityEngine.InputSystem;

public class PRACTPlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forwardSpeed = 2000f;
    [SerializeField] private float sidewaysSpeed = 1000f;

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private InputAction moveAction;

    void Start()
    {
        moveAction = playerInput.actions["Move"];
    }

    void Update()
    {
        rb.AddForce(0, 0, forwardSpeed * Time.deltaTime);
        Vector2 input = moveAction.ReadValue<Vector2>();

        if (input.x > 0)
        {
            rb.AddForce(sidewaysSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(input.x < 0)
        {
            rb.AddForce(-sidewaysSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}