using UnityEngine;
using Zenject;

public class TvWire : MonoBehaviour
{
    [Inject]
    private MaterialManager materialManager;

    public void TurnOn()
    {
        Material[] m = GetComponent<MeshRenderer>().materials;
        m[1] = materialManager.tvOn;
        GetComponent<MeshRenderer>().materials = m;
    }

    public void TurnOff()
    {
        Material[] m = GetComponent<MeshRenderer>().materials;
        m[1] = materialManager.wireOff;
        GetComponent<MeshRenderer>().materials = m;
    }
}
