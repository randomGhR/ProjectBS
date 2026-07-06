using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{
    private enum ScreenEdge
    {
        Top,
        Right,
        Bottom,
        Left
    }

    [Header("Box Colliders")]
    [SerializeField] BoxCollider2D _topCollider;
    [SerializeField] BoxCollider2D _rightCollider;
    [SerializeField] BoxCollider2D _bottomCollider;
    [SerializeField] BoxCollider2D _leftCollider;

    [Header("Parameters")]
    [SerializeField] float _boundaryOffset = 0f;
    [SerializeField] float _colliderThikness = 1f;

    Camera _camera;

    void Awake()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Debug.Log(GetCameraEdgeCenter(ScreenEdge.Left));
    }


    Vector2 GetCameraEdgeCenter(ScreenEdge edge)
    {
        float halfHeight = _camera.orthographicSize;
        float halfWidth = _camera.aspect * halfHeight;
        Vector2 center = _camera.transform.position;

        return edge switch
        {
            ScreenEdge.Top => center + Vector2.up * halfHeight,
            ScreenEdge.Right => center + Vector2.right * halfWidth,
            ScreenEdge.Bottom => center + Vector2.down * halfHeight,
            ScreenEdge.Left => center + Vector2.left * halfWidth,
            _ => center
        };
    }
}
