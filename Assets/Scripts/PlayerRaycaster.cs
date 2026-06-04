using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask _remoteLayer;
    [SerializeField] private float _raycastDistance;
    private Camera _camera;
    private RaycastHit[] _hits = new RaycastHit[16];
    private IInteractable _currentTarget;
    private Vector2 _screenCenter = new(0.5f, 0.5f);
    private Comparer<RaycastHit> _hitComparer = 
        Comparer<RaycastHit>.Create((a, b) => a.distance.CompareTo(b.distance));
    
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Array.Clear(_hits, 0, _hits.Length);
        Ray ray = _camera.ViewportPointToRay(_screenCenter);
        int hitCount = Physics.RaycastNonAlloc(ray, _hits, _raycastDistance, _remoteLayer);

        if (hitCount > 0)
        {
            Array.Sort(_hits, 0, hitCount, _hitComparer); 
            HandleHit(_hits[0]);
        }
        else
        {
            ClearCurrentTarget();
        }
    }

    private void HandleHit(RaycastHit hit)
    {
        if (!hit.collider.TryGetComponent(out IInteractable interactable))
        {
            ClearCurrentTarget();
            return;
        }

        if (_currentTarget != interactable)
        {
            _currentTarget?.Outline(false);
            _currentTarget = interactable;
        }

        _currentTarget.Outline(true);

        if (Input.GetMouseButtonDown(0))
            _currentTarget.Interact();
    }

    private void ClearCurrentTarget()
    {
        _currentTarget?.Outline(false);
        _currentTarget = null;
    }
}
