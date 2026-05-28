using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask _remoteLayer;
    [SerializeField] private float _raycastDistance;
    private Camera _camera;
    private RaycastHit[] _hits = new RaycastHit[16];
    private Comparison<RaycastHit> _hitComparison;

    private void Awake()
    {
        _camera = Camera.main;
        _hitComparison = (a, b) => a.distance.CompareTo(b.distance);
    }

    private void Update()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        int hitCount = Physics.RaycastNonAlloc(ray, _hits, _raycastDistance, _remoteLayer);
        Array.Sort(_hits, 0, hitCount, Comparer<RaycastHit>.Create(_hitComparison));

        if (Input.GetKeyDown(KeyCode.E) && hitCount != 0)
        {
            var interactable = _hits[0].collider.GetComponent<IInteractable>();
            interactable.Interact();
        }
    }
}
