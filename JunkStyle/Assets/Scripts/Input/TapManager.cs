using UnityEngine;

public class TapManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    public void Raycast(Vector2 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit[] hit = Physics.RaycastAll(ray, 10f);

        foreach (var h in hit)
        {
            if (h.collider.GetComponent<Button>()) h.collider.GetComponent<Button>().ChangeState();
            if (h.collider.CompareTag("Computer")) h.collider.GetComponent<LevelManager>().LoadNext();
        }
    }
}
