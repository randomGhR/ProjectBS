using UnityEngine;

public class BulletHitManager : MonoBehaviour
{
    [HideInInspector] public bool IsSafe {get; private set;}
    
    [SerializeField] private float _safeTime = 1f;

    private void Awake()
    {
        IsSafe = true;
    }

    private void Update()
    {
        if (_safeTime <= 0)
        {
            IsSafe = false;
        }
        else
        {
            _safeTime -= Time.deltaTime;
        }
    }
}
