using UnityEngine;

public class TapManager : MonoBehaviour
{    
    private RaycastHit hit;

    private bool isPaused;

    public void Raycast()
    {
        if (!isPaused)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            if (Physics.Raycast(ray, out hit, 10f))
            {
                if (hit.collider.CompareTag("Button"))
                    hit.collider.GetComponent<Button>().ChangeState();
                else if (hit.collider.CompareTag("Computer"))
                    hit.collider.GetComponent<Computer>().LoadLevel();
            }
        }
    }

    public void StopRaycast(bool state)
    {
        isPaused = state;
    }
}
