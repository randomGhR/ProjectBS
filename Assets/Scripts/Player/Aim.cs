using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    Vector2 _aimInputValue;

    InputAction _aimInputAction;

    void Awake()
    {
        _aimInputAction = InputSystem.actions.FindAction("Aim");
    }

    void Update()
    {
        ReadInput();
    }

    void FixedUpdate()
    {
        RotateAim();
    }

    void RotateAim()
    {
        float angle = CalculateRotation(CalculateRotationTarget());

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    float CalculateRotation(Vector3 target)
    {
        Vector2 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return angle;
    }
    Vector3 CalculateRotationTarget()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(_aimInputValue);
        return mouseWorldPos;
    }

    void ReadInput()
    {
        _aimInputValue = _aimInputAction.ReadValue<Vector2>();
    }
}
