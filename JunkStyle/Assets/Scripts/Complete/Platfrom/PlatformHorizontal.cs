using UnityEngine;

public class PlatformHorizontal : Platform
{
    protected override void NextPoint()
    {
        if (!vertical)
        {
            if (!left)
            {
                prevPoint = new Vector3(transform.position.x, transform.position.y, pointOne.position.z);
                nextPoint = new Vector3(transform.position.x, transform.position.y, pointTwo.position.z);
            }
            else
            {
                prevPoint = new Vector3(transform.position.x, transform.position.y, pointTwo.position.z);
                nextPoint = new Vector3(transform.position.x, transform.position.y, pointOne.position.z);
            }
        }
        else
        {
            if (!up)
            {
                prevPoint = new Vector3(pointOne.position.x, transform.position.y, transform.position.z);
                nextPoint = new Vector3(pointTwo.position.x, transform.position.y, transform.position.z);
            }
            else
            {
                prevPoint = new Vector3(pointTwo.position.x, transform.position.y, transform.position.z);
                nextPoint = new Vector3(pointOne.position.x, transform.position.y, transform.position.z);
            }
        }

        fullTime = Vector3.Distance(prevPoint, nextPoint) / speed;
        timeLeft = Vector3.Distance(transform.position, nextPoint) / speed;
    }
}
