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

    private ButtonWire buttonWire;

    private Transform button;

    private void Awake()
    {
        button = transform.GetChild(0);
        buttonWire = GetComponent<ButtonWire>();
    }

    private void Start()
    {
        if (!state) button.rotation = Quaternion.Euler(falseRotation);
        else button.rotation = Quaternion.Euler(trueRotation);
    }

    public void ChangeState()
    {
        state = !state;
        if (!state)
        {
            button.rotation = Quaternion.Euler(falseRotation);
            buttonWire.TurnOff();
        }
        else
        {
            button.rotation = Quaternion.Euler(trueRotation);
            buttonWire.TurnOn();
        }
        platformLogic.ChangeState(index);
    }
}
