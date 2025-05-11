using UnityEngine;
using Zenject;

public class TapManager : MonoBehaviour
{
    [Inject]
    private LevelManager levelManager;

    [Inject]
    private AudioManager audioManager;
    
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
                {
                    audioManager.Play("button", .3f);
                    hit.collider.GetComponent<Button>().ChangeState();
                }
                else if (hit.collider.CompareTag("Computer"))
                {
                    audioManager.Play("revive", .1f);
                    levelManager.NextLevel();
                }
            }
        }
    }

    public void StopRaycast(bool state) => isPaused = state;
}
