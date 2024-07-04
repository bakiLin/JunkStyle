using UnityEngine;

public class PlayerMoveWithPlatform : MonoBehaviour
{
    [SerializeField]
    private LayerMask platform;

    private Vector3 overlapBoxSize;

    private void Start()
    {
        overlapBoxSize = new Vector3(0.25f, 0.4f, 0.25f);
    }

    private void FixedUpdate()
    {
        Collider[] colls = Physics.OverlapBox(transform.position + Vector3.down, overlapBoxSize, Quaternion.identity, platform);

        if (colls.Length > 0)
            transform.SetParent(colls[0].transform);
        else
            transform.SetParent(null);
    }
}
