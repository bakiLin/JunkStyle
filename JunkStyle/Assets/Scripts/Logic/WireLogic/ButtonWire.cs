using UnityEngine;

public class ButtonWire : WireLogic
{
    public override void TurnOn()
    {
        Material[] material = GetComponent<MeshRenderer>().materials;
        material[2] = materialManager.buttonOn;
        GetComponent<MeshRenderer>().materials = material;

        base.TurnOn();
    }

    public override void TurnOff()
    {
        Material[] material = GetComponent<MeshRenderer>().materials;
        material[2] = materialManager.wireOff;
        GetComponent<MeshRenderer>().materials = material;

        base.TurnOff();
    }
}
