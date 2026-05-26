using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private PlatformRegular _platform;

    public float speed = 5;
    [Header("Running")] public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    public List<System.Func<float>> speedOverrides = new();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlatformRegular platform))
            _platform = platform;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlatformRegular platform))
            _platform = null;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        _rb.velocity = transform.rotation * new Vector3(targetVelocity.x, _rb.velocity.y, targetVelocity.y);

        if (_platform != null)
            _rb.position += _platform.Delta;
    }
}