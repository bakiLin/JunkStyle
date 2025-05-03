using UnityEngine;
using Zenject;

public class WireLogic : MonoBehaviour
{
    [Inject] protected MaterialManager materialManager;

    [SerializeField] protected MeshRenderer[] wire;
    [Space]
    [SerializeField] protected OrWire or;
    [SerializeField] protected int orIndex;
    [Space]
    [SerializeField] protected AndWire and;
    [SerializeField] protected int andIndex;
    [Space]
    [SerializeField] protected NotWire not;
    [Space]
    [SerializeField] protected TvWire tv;

    public virtual void TurnOn()
    {
        foreach (var r in wire) r.material = materialManager.wireOn;
        if (not != null) not.TurnOff();
        if (and != null) and.TurnOn(andIndex);
        if (or != null) or.TurnOn(orIndex);
        if (tv != null) tv.TurnOn();
    }

    public virtual void TurnOff()
    {
        foreach (var r in wire) r.material = materialManager.wireOff;
        if (not != null) not.TurnOn();
        if (and != null) and.TurnOff(andIndex);
        if (or != null) or.TurnOff(orIndex);
        if (tv != null) tv.TurnOff();
    }
}