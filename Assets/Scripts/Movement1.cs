using UnityEngine;
using UnityEngine.InputSystem;

public class Movement1 : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forwardForce = 2000f;
    [SerializeField] private float sidewaysForce = 200f;

    [SerializeField] private PlayerInput playerInput;
    private InputAction moveAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       moveAction = playerInput.actions["Move"];        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       rb.AddForce(0, 0, forwardForce * Time.deltaTime); 

       Vector2 input = moveAction.ReadValue<Vector2>();

       if (input.x > 0)
       {
           rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
       }

       if (input.x < 0)
       {
           rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
       }
       
    }
}
