using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    [SerializeField]
    private LayerMask platform;

    private MovePlatform movePlatform;
    private bool onPlatform;

    private void Update()
    {
        Collider[] colls = Physics.OverlapBox(transform.position + Vector3.down, new Vector3(0.25f, 0.15f, 0.25f), Quaternion.identity, platform);

        if (colls.Length > 0) onPlatform = true;
        else onPlatform = false;

        foreach (var coll in colls)
            movePlatform = coll.GetComponent<MovePlatform>();

        if (colls.Length > 0)
            onPlatform = true;
        else
        {
            onPlatform = false;
            movePlatform = null;
        }
    }

    public Vector3 GetPlatformSpeed()
    {
        if (onPlatform && movePlatform != null)
            return movePlatform.GetDirectionSpeed();
        else 
            return Vector3.zero;
    }
}
