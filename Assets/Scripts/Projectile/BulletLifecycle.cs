using UnityEngine;

public class BulletLifecycle : MonoBehaviour
{
    [SerializeField] private float _lifeLengthInSeconds = 10f;

    private float _timeStamp;

    private void Awake()
    {
        _timeStamp = _lifeLengthInSeconds + Time.time;
    }

    private void Update()
    {
        if (_timeStamp <= Time.time)
        {
            Destroy(gameObject);
        }
    }

}
