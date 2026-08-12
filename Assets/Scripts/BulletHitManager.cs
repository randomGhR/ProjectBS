using UnityEngine;

public class BulletHitManager : MonoBehaviour
{
    [HideInInspector] public bool isSafe;
    
    [SerializeField] private float _safeTime = 1f;

    private void Awake()
    {
        isSafe = true;

    }

    private void Update()
    {
        if (_safeTime <= 0)
        {
            isSafe = false;
        }
        else
        {
            _safeTime -= Time.deltaTime;
        }
    }
}
