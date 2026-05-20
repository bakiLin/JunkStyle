using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) collision.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) collision.transform.SetParent(null);
    }
}
