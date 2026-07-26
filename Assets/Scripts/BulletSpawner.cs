using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRate = 5f;
    
    private float _fireCooldown;
    private bool _canFire = true;
    private float _timer;

    private InputAction _shootAction;
    private bool _shootActionIsPressed;

    

    void Awake()
    {
        _shootAction = InputSystem.actions.FindAction("Attack");
        _fireCooldown = 1f / _fireRate;
    }

    void Update()
    {
        ReadInput();
        FireIfCanFire();
    }

    private void FireIfCanFire()
    {
        if (_canFire)
        {
            InstantiateBullet();
            
            _canFire = false;
            _timer = _fireCooldown;
        }
        else
        {
            if (_timer <= 0f)
            {
                _canFire = true;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
    }

    private void InstantiateBullet()
    {
        if (_shootActionIsPressed)
        {
            Instantiate(
                original: _bulletPrefab,
                position: transform.position,
                rotation: transform.rotation
                );
        }
    }

    private void ReadInput()
    {
        _shootActionIsPressed = _shootAction.IsPressed();
    }
}
