using UnityEngine;
using Zenject;

public class Button : MonoBehaviour
{
    [Inject]
    private AudioManager audioManager;

    [SerializeField]
    private int index;

    [SerializeField]
    private PlatformLogic platformLogic;

    private Vector3 falseRotation = new Vector3(0f, 180f, 0f);

    private Vector3 trueRotation = new Vector3(0f, 180f, 340f);

    private WireManager wireManager;

    private Transform button;

    private bool state;

    private void Awake()
    {
        button = transform.GetChild(0);
        wireManager = GetComponent<WireManager>();
    }

    private void Start()
    {
        button.rotation = Quaternion.Euler(falseRotation);
    }

    public void ChangeState()
    {
        audioManager.Play("button", .3f);
        state = !state;

        if (!state)
        {
            button.rotation = Quaternion.Euler(falseRotation);
            wireManager.TurnOff(0);
        }
        else
        {
            button.rotation = Quaternion.Euler(trueRotation);
            wireManager.TurnOn(0);
        }

        platformLogic.ChangeState(index);
    }
}
