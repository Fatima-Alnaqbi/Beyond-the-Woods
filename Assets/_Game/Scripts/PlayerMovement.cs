using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D body;
    private Vector2 moveInput;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        body.linearVelocity = moveInput * moveSpeed;
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
