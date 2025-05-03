using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private int index;

    [SerializeField]
    private PlatformLogic platformLogic;

    private bool state;

    private Vector3 falseRotation = new Vector3(0f, 180f, 0f);

    private Vector3 trueRotation = new Vector3(0f, 180f, 340f);

    private ButtonWire buttonWire;

    private Transform button;

    private void Awake()
    {
        button = transform.GetChild(0);
        buttonWire = GetComponent<ButtonWire>();
    }

    private void Start()
    {
        button.rotation = Quaternion.Euler(falseRotation);
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
