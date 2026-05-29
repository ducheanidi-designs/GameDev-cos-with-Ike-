using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private InputAction moveAction;
    [SerializeField] private InputAction lookAction;

    [SerializeField] private Transform canTarget;
    [SerializeField] private Vector2 pitchClampValue;

    [SerializeField] private Animator anim;
    private float xRotation = 0f;

    void Start()
    {
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
    }

    void Update()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        Vector3 movDir = transform.right * inputVector.x + transform.forward * inputVector.y;
        transform.position += movDir * moveSpeed* Time.deltaTime;

        // transform.forward = Vector3.Slerp(transform.forward, movDir, rotateSpeed * Time.deltaTime);

       Vector2 lookInput = lookAction.ReadValue<Vector2>();
       Debug.Log(lookInput);

       HandleRotation();

    }

    void HandleRotation()
    {
        Vector2 lookInput = lookAction.ReadValue<Vector2>();

        // LEFT/RIGHT - Rotate camera target (and player follows)
        transform.Rotate(Vector3.up * lookInput.x);

        // player faces camera direction
        float camYaw = transform.eulerAngles. y;
        transform.rotation = Quaternion.Euler(0, camYaw, 0);

        //UP/DOWN
        xRotation -= lookInput.y;
        xRotation = Mathf. Clamp(xRotation, -pitchClampValue.x, pitchClampValue.y);
        canTarget.rotation = Quaternion.Euler(xRotation, camYaw, 0f);
    }
}
