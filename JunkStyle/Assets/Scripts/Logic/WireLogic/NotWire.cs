using UnityEngine;

public class NotWire : WireLogic
{
    [Space]
    [SerializeField]
    private MeshRenderer prevWire;

    private void Start()
    {
        if (prevWire != null)
        {
            if (prevWire.material.name == "Off (Instance)") TurnOn();
            else TurnOff();
        }
    }
}
