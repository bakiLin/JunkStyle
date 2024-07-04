using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField]
    private PlayerRotation rotationInput;

    private void Start()
    {
        rotationInput.enabled = false;
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