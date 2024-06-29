using UnityEngine;

public class RotationPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform anchor;

    [SerializeField]
    private Vector2 sensitivity;

    [SerializeField]
    private float yLimitMin, yLimitMax;

    private void Update()
    {
        RotationX();
        RotationY();
    }

    private void RotationX()
    {
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.y += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity.x;
        transform.rotation = Quaternion.Euler(rotation);
    }

    private void RotationY()
    {
        Vector3 rotation = anchor.rotation.eulerAngles;
        rotation.x -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity.y;

        if (rotation.x > 300) rotation.x -= 360f;
        rotation.x = Mathf.Clamp(rotation.x, yLimitMin, yLimitMax);

        anchor.rotation = Quaternion.Euler(rotation);
    }
}
