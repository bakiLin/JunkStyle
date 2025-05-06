using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PlayerRotation : MonoBehaviour
{
    [Inject]
    private PlayerInput input;

    [Inject]
    private CursorManager cursorManager;

    [SerializeField]
    private float speed;

    private Vector3 rotation;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            cursorManager.Lock();
        }
    }

    private void Update() => Rotate();

    private void Rotate()
    {
        rotation = transform.localRotation.eulerAngles;
        rotation += new Vector3(-input.delta.y, input.delta.x) * Time.deltaTime * speed;
        if (rotation.x > 50f && rotation.x < 290f) rotation.x = 50f;
        else if (rotation.x < 310f && rotation.x > 50f) rotation.x = 310f;
        transform.localRotation = Quaternion.Euler(rotation);
    }
}
