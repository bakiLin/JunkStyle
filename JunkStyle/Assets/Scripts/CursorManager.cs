using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField]
    private RotationPlayer rotationInput;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotationInput.enabled = true;
            Destroy(this);
        }
    }
}
