using UnityEngine;

public class TapManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    private RaycastHit hit;

    private bool isPaused;

    public void Raycast()
    {
        if (!isPaused)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            if (Physics.Raycast(ray, out hit, 10f))
            {
                if (hit.collider.GetComponent<Button>() != null)
                    hit.collider.GetComponent<Button>().ChangeState();
                else if (hit.collider.GetComponent<LevelManager>() != null)
                    hit.collider.GetComponent<LevelManager>().LoadNext();
            }
        }
    }

    public void StopRaycast(bool state)
    {
        isPaused = state;
    }
}
