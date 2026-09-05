using System;
using Pathfinding.Util;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserSight : MonoBehaviour
{

    [SerializeField] float _reflectionLength = 2f;

    private LineRenderer _lineRenderer;
    private LayerMask _collisionLayerMask;

    private void Awake()
    {
        _collisionLayerMask = LayerMask.GetMask("Wall", "Obstacle");
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.useWorldSpace = true;
    }

    private void Update()
    {
        _lineRenderer.positionCount = GetLinePositions().Length;
        _lineRenderer.SetPositions(GetLinePositions());
    }


    private Vector3[] GetLinePositions()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            origin: transform.position, 
            direction: transform.right, 
            distance: Mathf.Infinity, 
            layerMask: _collisionLayerMask);

        Vector3 collisionPosition = hit.point;
        Vector3 startPosition = transform.position;
        
        //Vector2.Reflect gives the transform.right position reflected relative to collsion surface's normal
        //So adding it to the position of the collision point gives the reflection resault position
        Vector3 reflectionVector = 
            Vector3.Reflect(transform.right, hit.normal).normalized * _reflectionLength;
        Vector3 endPosition = collisionPosition + reflectionVector;

            
        return new Vector3[3] {startPosition, collisionPosition, endPosition};
    }
}
