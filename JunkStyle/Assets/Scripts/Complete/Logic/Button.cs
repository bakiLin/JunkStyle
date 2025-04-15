using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private bool state;

    [SerializeField]
    private int index;

    [SerializeField]
    private Vector3 falseRotation, trueRotation;

    [SerializeField]
    private PlatformLogic platformLogic;

    private Transform button;

    private void Awake()
    {
        button = transform.GetChild(0);
    }

    private void Start()
    {
        if (!state) button.rotation = Quaternion.Euler(falseRotation);
        else button.rotation = Quaternion.Euler(trueRotation);
    }

    public void ChangeState()
    {
        state = !state;
        if (!state) button.rotation = Quaternion.Euler(falseRotation);
        else button.rotation = Quaternion.Euler(trueRotation);
        platformLogic.ChangeState(index);
    }
}
