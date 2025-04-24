using UnityEngine;

public class TvWire : MonoBehaviour
{
    [SerializeField]
    private Material off, tvOn;

    public void TurnOn()
    {
        Material[] m = GetComponent<MeshRenderer>().materials;
        m[1] = tvOn;
        GetComponent<MeshRenderer>().materials = m;
    }

    public void TurnOff()
    {
        Material[] m = GetComponent<MeshRenderer>().materials;
        m[1] = off;
        GetComponent<MeshRenderer>().materials = m;
    }
}
