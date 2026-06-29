using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 20f;
    [SerializeField] float _maxDistanceDelta = 20f;
    
    Vector2 moveInputValue;

    InputAction moveAction;
    Rigidbody2D rb;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ReadInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {  
        Vector2 moveAmount = moveInputValue * _moveSpeed;
        rb.linearVelocity = moveAmount;
    }

    void ReadInput()
    {
        moveInputValue = moveAction.ReadValue<Vector2>();
        moveInputValue = Vector2.ClampMagnitude(moveInputValue, 1f);
    }
}
