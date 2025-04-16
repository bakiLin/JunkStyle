using UnityEngine;

public class TapManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    public void Raycast(Vector2 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f))
        {
            Button button = hit.collider.GetComponent<Button>();
            if (button) button.ChangeState();
        }
    }
}
