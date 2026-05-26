using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private InputAction moveAction;

    void Start()
    {
        moveAction = playerInput.actions["Move"];
    }

    void Update()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        Vector3 movDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += movDir * moveSpeed* Time.deltaTime;
        
        transform.forward = Vector3.Slerp(transform.forward, movDir, rotateSpeed * Time.deltaTime);
    }
}
