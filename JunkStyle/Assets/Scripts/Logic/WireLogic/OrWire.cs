using UnityEngine;

public class OrWire : MonoBehaviour
{
    [SerializeField]
    private Material off, on;

    [SerializeField]
    private MeshRenderer[] wire;

    [SerializeField]
    private AndWire andWire;

    [SerializeField]
    private int andWireIndex;

    [SerializeField]
    private NotWire notWire;

    [SerializeField]
    private TvWire tvWire;

    [SerializeField]
    private OrWire orWire;

    [SerializeField]
    private int orWireIndex;

    private bool inputOne, inputTwo;

    public void TurnOn(int index)
    {
        if (index == 0) inputOne = true;
        else inputTwo = true;

        if (inputOne || inputTwo)
        {
            foreach (var w in wire) w.material = on;
            if (andWire != null) andWire.TurnOn(andWireIndex);
            if (notWire != null) notWire.TurnOff();
            if (tvWire != null) tvWire.TurnOn();
            if (orWire != null) orWire.TurnOn(orWireIndex);
        }
    }

    public void TurnOff(int index)
    {
        if (index == 0) inputOne = false;
        else inputTwo = false;

        if (!(inputOne || inputTwo))
        {
            foreach (var w in wire) w.material = off;
            if (andWire != null) andWire.TurnOff(andWireIndex);
            if (notWire != null) notWire.TurnOn();
            if (tvWire != null) tvWire.TurnOff();
            if (orWire != null) orWire.TurnOff(orWireIndex);
        }
    }
}
