using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private PlayerInput input;

    [SerializeField]
    private float speed;

    private Vector3 rotation;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        rotation = transform.rotation.eulerAngles;
        rotation += new Vector3(-input.delta.y, input.delta.x, transform.position.z) * Time.deltaTime * speed;
        if (rotation.x > 50f && rotation.x < 290f) rotation.x = 50f;
        else if (rotation.x < 310f && rotation.x > 50f) rotation.x = 310f;
        rotation.z = 0f;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
