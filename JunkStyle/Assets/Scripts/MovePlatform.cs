using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour
{
    [SerializeField]
    private float moveTime;

    [SerializeField]
    private Vector3[] vectorSpeed;

    private Rigidbody rb;
    private int pointCounter;

    private void Awake() => rb = GetComponent<Rigidbody>();

    private void Start() => StartCoroutine(MoveCoroutine());

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveTime);

            if (pointCounter == vectorSpeed.Length - 1) pointCounter = 0;
            else pointCounter++;
        }
    }

    private void FixedUpdate() => rb.MovePosition(transform.position + Time.fixedDeltaTime * GetDirectionSpeed());

    public Vector3 GetDirectionSpeed() => vectorSpeed[pointCounter];
}
