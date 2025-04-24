using UnityEngine;

public class ButtonWire : MonoBehaviour
{
    [SerializeField]
    private Material off, on, buttonOn;

    [SerializeField]
    private MeshRenderer[] wire;

    [SerializeField]
    private NotWire notWire;

    [SerializeField]
    private AndWire andWire;

    [SerializeField]
    private int andWireIndex;

    [SerializeField]
    private OrWire orWire;

    [SerializeField]
    private int orWireIndex;

    public void TurnOn()
    {
        Material[] m = GetComponent<MeshRenderer>().materials;
        m[2] = buttonOn;
        GetComponent<MeshRenderer>().materials = m;

        foreach (var r in wire) r.material = on;
        if (notWire != null) notWire.TurnOff();
        if (andWire != null) andWire.TurnOn(andWireIndex);
        if (orWire != null) orWire.TurnOn(orWireIndex);
    }

    public void TurnOff()
    {
        Material[] m = GetComponent<MeshRenderer>().materials;
        m[2] = off;
        GetComponent<MeshRenderer>().materials = m;

        foreach (var r in wire) r.material = off;
        if (notWire != null) notWire.TurnOn();
        if (andWire != null) andWire.TurnOff(andWireIndex);
        if (orWire != null) orWire.TurnOff(orWireIndex);
    }
}
