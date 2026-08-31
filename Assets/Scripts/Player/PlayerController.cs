using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 20f;
    
    Vector2 _moveInputValue;

    InputAction _moveAction;
    Rigidbody2D rb;

    InputAction _quitAction;

    void Awake()
    {
        _moveAction = InputSystem.actions.FindAction("Move");

        _quitAction = InputSystem.actions.FindAction("Quit");
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ReadInput();
        
        if (_quitAction.WasPressedThisFrame())
        {
            SceneManager.LoadScene("MainMenu");
        }   
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
