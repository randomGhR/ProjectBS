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
    [SerializeField] float _overLapOffset = 0f;
    [SerializeField] float _colliderThickness = 4f;

    Camera _camera;

    void Awake()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        SetColliders();
    }

    void SetColliders()
    {
        Vector2 topEdgeCenter = GetCameraEdgeCenter(ScreenEdge.Top);
        Vector2 bottomEdgeCenter = GetCameraEdgeCenter(ScreenEdge.Bottom);
        Vector2 rightEdgeCenter = GetCameraEdgeCenter(ScreenEdge.Right);
        Vector2 leftEdgeCenter = GetCameraEdgeCenter(ScreenEdge.Left);

        Vector2 cameraDimensions = 
            new Vector2(
                GetCameraHalfDimensions().x * 2,
                GetCameraHalfDimensions().y * 2
                );
        
        //these should be a single helper method that can take one collider and one edge and set the size and position for that but that's for later.
        _topCollider.size = 
            new Vector2(
                cameraDimensions.x + _overLapOffset,
                _colliderThickness
                );
        _topCollider.transform.position =
            new Vector2(
                topEdgeCenter.x,
                topEdgeCenter.y + (_colliderThickness / 2) + _boundaryOffset
                );

        _bottomCollider.size = 
            new Vector2(
                cameraDimensions.x + _overLapOffset,
                _colliderThickness
                );
        _bottomCollider.transform.position =
            new Vector2(
                bottomEdgeCenter.x,
                bottomEdgeCenter.y - (_colliderThickness / 2) - _boundaryOffset
                );
        
        _rightCollider.size = 
            new Vector2(
                _colliderThickness,
                cameraDimensions.y + _overLapOffset
                );
        _rightCollider.transform.position =
            new Vector2 (
                rightEdgeCenter.x  + (_colliderThickness / 2) + _boundaryOffset,
                rightEdgeCenter.y
                );
        
        _leftCollider.size = 
            new Vector2(
                _colliderThickness,
                cameraDimensions.y + _overLapOffset
                );
        _leftCollider.transform.position =
            new Vector2 (
                leftEdgeCenter.x  - (_colliderThickness / 2) - _boundaryOffset,
                leftEdgeCenter.y
                );
    }

    Vector2 GetCameraEdgeCenter(ScreenEdge edge)
    {
        Vector2 cameraHalfDim = GetCameraHalfDimensions();
        Vector2 center = _camera.transform.position;

        return edge switch
        {
            ScreenEdge.Top => center + Vector2.up * cameraHalfDim.y,
            ScreenEdge.Right => center + Vector2.right * cameraHalfDim.x,
            ScreenEdge.Bottom => center + Vector2.down * cameraHalfDim.y,
            ScreenEdge.Left => center + Vector2.left * cameraHalfDim.x,
            _ => center
        };
    }
    Vector2 GetCameraHalfDimensions()
    {
        float halfHeight = _camera.orthographicSize;
        float halfWidth = _camera.aspect * halfHeight;
        return new Vector2 (halfWidth, halfHeight);
    }

}
