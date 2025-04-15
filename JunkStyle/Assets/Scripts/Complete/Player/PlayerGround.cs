using UnityEngine;

public class PlayerGround : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayer;

    private int collisions;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == Mathf.Log(groundLayer, 2))
        {
            collisions++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == Mathf.Log(groundLayer, 2))
        {
            collisions--;
        }
    }

    public bool IsGrounded()
    {
        return collisions > 0;
    }
}
