using UnityEngine;

[ExecuteInEditMode]
public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float _distanceThreshold = .15f;
    private float _originOffset = .001f;
    private Vector3 _raycastOrigin => transform.position + Vector3.up * _originOffset;

    public bool IsGrounded { get; private set; } = true;

    private void Update()
    {
        IsGrounded = Physics.Raycast(_raycastOrigin, Vector3.down, _distanceThreshold);
    }
}
