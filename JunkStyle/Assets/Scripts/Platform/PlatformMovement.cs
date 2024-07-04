using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3[] movePoints;

    [SerializeField]
    private float moveTime;

    private int currentPoint, nextPoint = 1;

    private float timePassed;

    private void FixedUpdate()
    {
        timePassed += Time.deltaTime;

        float percentage = timePassed / moveTime;
        transform.position = Vector3.Lerp(movePoints[currentPoint], movePoints[nextPoint], percentage);

        if (transform.position == movePoints[nextPoint])
        {
            timePassed = 0f;

            if (currentPoint < movePoints.Length - 2)
            {
                currentPoint += 1;
                nextPoint += 1;
            }
            else if (currentPoint < movePoints.Length - 1)
            {
                currentPoint += 1;
                nextPoint = 0;
            }
            else
            {
                currentPoint = 0;
                nextPoint += 1;
            }
        }
    }
}
