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
    private float speed, limitAngle;

    private Vector3 rotation;

    private float angle;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
            cursorManager.Lock();

        angle = 360f - limitAngle;
    }

    private void Update()
    {
        rotation = transform.localRotation.eulerAngles;
        rotation += new Vector3(-input.delta.y, input.delta.x) * Time.deltaTime * speed;

        if (rotation.x > limitAngle && rotation.x < angle - 20f) 
            rotation.x = limitAngle;
        else if (rotation.x < angle && rotation.x > limitAngle) 
            rotation.x = angle;

        transform.localRotation = Quaternion.Euler(rotation);
    }
}
