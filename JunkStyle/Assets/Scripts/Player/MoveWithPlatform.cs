using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    [SerializeField]
    private LayerMask platform;

    private Rigidbody rb;
    private MovePlatform movePlatform;
    private MovementPlayer movementPlayer;
    private bool onPlatform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        movementPlayer = GetComponent<MovementPlayer>();
    }

    private void Update()
    {
        Collider[] colls = Physics.OverlapBox(transform.position + Vector3.down, new Vector3(0.25f, 0.1f, 0.25f), Quaternion.identity, platform);

        if (colls.Length > 0) onPlatform = true;
        else onPlatform = false;

        foreach (var coll in colls)
        {
            movePlatform = coll.GetComponent<MovePlatform>();
        }

        if (colls.Length > 0) onPlatform = true;
        else onPlatform = false;
    }

    private void FixedUpdate()
    {
        if (onPlatform)
        {
            //transform.parent = movePlatform.transform;
            movementPlayer.movement += movePlatform.GetDirectionSpeed();
            //rb.MovePosition(transform.position + Time.fixedDeltaTime * movePlatform.GetDirectionSpeed());
        }
    }
}
