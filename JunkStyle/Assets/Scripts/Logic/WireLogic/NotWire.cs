using UnityEngine;

public class NotWire : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer prevWire;

    [SerializeField]
    private Material off, on;

    [SerializeField]
    private MeshRenderer[] wire;

    [SerializeField]
    private OrWire orWire;

    [SerializeField]
    private int orWireIndex;

    [SerializeField]
    private AndWire andWire;

    [SerializeField]
    private int andWireIndex;

    [SerializeField]
    private NotWire notWire;

    [SerializeField]
    private TvWire tvWire;

    private void Start()
    {
        if (prevWire != null)
        {
            if (prevWire.material.name == "Off (Instance)") TurnOn();
            else TurnOff();
        }
    }

    public void TurnOn()
    {
        foreach (var r in wire) r.material = on;
        if (orWire != null) orWire.TurnOn(orWireIndex);
        if (notWire != null) notWire.TurnOff();
        if (andWire != null) andWire.TurnOn(andWireIndex);
        if (tvWire != null) tvWire.TurnOn();
    }

    public void TurnOff()
    {
        foreach (var r in wire) r.material = off;
        if (orWire != null) orWire.TurnOff(orWireIndex);
        if (notWire != null) notWire.TurnOn();
        if (andWire != null) andWire.TurnOff(andWireIndex);
        if (tvWire != null) tvWire.TurnOff();
    }
}
