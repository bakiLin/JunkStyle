using UnityEngine;
using Zenject;

public class WireManager : MonoBehaviour
{
    [Inject]
    private MaterialManager materialManager;

    [SerializeField]
    private MeshRenderer connectedWire;

    [SerializeField]
    private WireManager orWireManager, andWireManager, notWireManager, tvWireManager;

    [SerializeField]
    private int orIndex, andIndex;

    private enum Type {Button, NOT, OR, AND, TV}

    [SerializeField]
    private Type type;

    private bool isOn, leftInput, rightInput;

    private void Start()
    {
        if (notWireManager != null && type != Type.NOT)
        {
            if (isOn) notWireManager.TurnOff(0);
            else notWireManager.TurnOn(0);
        }
    }

    public void TurnOn(int index)
    {
        isOn = true;

        ButtonCheck(true);
        TvCheck(true);

        if (type == Type.OR || type == Type.AND)
        {
            if (index == 1) leftInput = true;
            else if (index == 2) rightInput = true;

            if (type == Type.OR) if (!(leftInput || rightInput)) return;
            if (type == Type.AND) if (!(leftInput && rightInput)) return;
        }

        if (connectedWire != null) connectedWire.material = materialManager.wireOn;
        if (notWireManager != null) notWireManager.TurnOff(0);
        if (orWireManager != null) orWireManager.TurnOn(orIndex);
        if (andWireManager != null) andWireManager.TurnOn(andIndex);
        if (tvWireManager != null) tvWireManager.TurnOn(0);
    }

    public void TurnOff(int index)
    {
        isOn = false;

        ButtonCheck(false);
        TvCheck(false);

        if (type == Type.OR || type == Type.AND)
        {
            if (index == 1) leftInput = false;
            else if (index == 2) rightInput = false;

            if (type == Type.OR) if (leftInput || rightInput) return;
            if (type == Type.AND) if (leftInput && rightInput) return;
        }

        if (connectedWire != null) connectedWire.material = materialManager.off;
        if (notWireManager != null) notWireManager.TurnOn(0);
        if (orWireManager != null) orWireManager.TurnOff(orIndex);
        if (andWireManager != null) andWireManager.TurnOff(andIndex);
        if (tvWireManager != null) tvWireManager.TurnOff(0);
    }

    private void ButtonCheck(bool state)
    {
        if (type == Type.Button)
        {
            Material[] material = GetComponent<MeshRenderer>().materials;
            if (state) material[2] = materialManager.buttonOn;
            else material[2] = materialManager.buttonOff;
            GetComponent<MeshRenderer>().materials = material;
        }
    }

    private void TvCheck(bool state)
    {
        if (type == Type.TV)
        {
            Material[] m = GetComponent<MeshRenderer>().materials;
            if (state) m[1] = materialManager.tvOn;
            else m[1] = materialManager.off;
            GetComponent<MeshRenderer>().materials = m;
        }
    }
}