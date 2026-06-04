using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public void Lock()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Unlock()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
