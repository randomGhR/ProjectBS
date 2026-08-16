using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 20f;
    
    Vector2 _moveInputValue;

    InputAction _moveAction;
    Rigidbody2D rb;

    void Awake()
    {
        _moveAction = InputSystem.actions.FindAction("Move");

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
        Vector2 moveAmount = _moveInputValue.normalized * _moveSpeed;
        rb.linearVelocity = moveAmount;
    }

    void ReadInput()
    {
        _moveInputValue = _moveAction.ReadValue<Vector2>();
    }
}
