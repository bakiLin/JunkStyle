using UnityEngine;

public class PlatformSemisphere : Platform
{
    [SerializeField]
    protected Transform[] points;

    [SerializeField]
    protected Transform topPoint;

    protected int index;

    protected override void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        percent = (fullTime - timeLeft) / fullTime;
        transform.position = Vector3.Lerp(prevPoint, nextPoint, percent);

        if (percent >= 1)
        {
            if (vertical) up = !up;
            else
            {
                if (!left) index++;
                else if (index != 0) index--;
                else left = !left;
                if (index + 1 >= points.Length) left = !left;
            }

            NextPoint();
        }
    }

    protected override void NextPoint()
    {
        if (!vertical)
        {
            if (!left)
            {
                prevPoint = new Vector3(points[index].position.x, transform.position.y, points[index].position.z);

                if (index + 1 < points.Length)
                    nextPoint = new Vector3(points[index + 1].position.x, transform.position.y, points[index + 1].position.z);
                else
                    nextPoint = new Vector3(points[0].position.x, transform.position.y, points[0].position.z);
            }
            else
            {
                if (index + 1 < points.Length)
                    prevPoint = new Vector3(points[index + 1].position.x, transform.position.y, points[index + 1].position.z);
                else
                    prevPoint = new Vector3(points[index - 1].position.x, transform.position.y, points[index - 1].position.z);

                nextPoint = new Vector3(points[index].position.x, transform.position.y, points[index].position.z);
            }
        }
        else
        {
            if (!up)
            {
                prevPoint = new Vector3(transform.position.x, points[index].position.y, transform.position.z);
                nextPoint = new Vector3(transform.position.x, topPoint.position.y, transform.position.z);
            }
            else
            {
                prevPoint = new Vector3(transform.position.x, topPoint.position.y, transform.position.z);
                nextPoint = new Vector3(transform.position.x, points[index].position.y, transform.position.z);
            }
        }

        fullTime = Vector3.Distance(prevPoint, nextPoint) / speed;
        timeLeft = Vector3.Distance(transform.position, nextPoint) / speed;
    }
}
