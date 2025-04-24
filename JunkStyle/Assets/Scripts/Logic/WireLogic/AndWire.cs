using UnityEngine;

public class AndWire : MonoBehaviour
{
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

    private bool inputOne, inputTwo;

    public void TurnOn(int index)
    {
        if (index == 0) inputOne = true;
        else inputTwo = true;

        if (inputOne && inputTwo)
        {
            foreach (var w in wire) w.material = on;
            if (notWire != null) notWire.TurnOff();
            if (orWire != null) orWire.TurnOn(orWireIndex);
            if (andWire != null) andWire.TurnOn(andWireIndex);
            if (tvWire != null) tvWire.TurnOn();
        }
    }

    public void TurnOff(int index)
    {
        if (index == 0) inputOne = false;
        else inputTwo = false;

        if (!(inputOne && inputTwo))
        {
            foreach (var w in wire) w.material = off;
            if (notWire != null) notWire.TurnOn();
            if (orWire != null) orWire.TurnOff(orWireIndex);
            if (andWire != null) andWire.TurnOff(andWireIndex);
            if (tvWire != null) tvWire.TurnOff();
        }
    }
}
