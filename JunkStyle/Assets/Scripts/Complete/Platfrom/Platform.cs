using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    protected bool vertical;

    [SerializeField]
    protected Transform pointOne, pointTwo;

    [SerializeField]
    protected float speed;

    protected Vector3 prevPoint, nextPoint;

    protected float timeLeft, fullTime, percent;

    protected bool left, up;

    protected void Start()
    {
        NextPoint();
    }

    protected virtual void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        percent = (fullTime - timeLeft) / fullTime;
        transform.position = Vector3.Lerp(prevPoint, nextPoint, percent);

        if (percent >= 1)
        {
            if (!vertical) left = !left;
            else up = !up;
            NextPoint();
        }
    }

    protected virtual void NextPoint()
    {
        if (!vertical)
        {
            if (!left)
            {
                prevPoint = new Vector3(pointOne.position.x, transform.position.y, pointOne.position.z);
                nextPoint = new Vector3(pointTwo.position.x, transform.position.y, pointTwo.position.z);
            }
            else
            {
                prevPoint = new Vector3(pointTwo.position.x, transform.position.y, pointTwo.position.z);
                nextPoint = new Vector3(pointOne.position.x, transform.position.y, pointOne.position.z);
            }
        }
        else
        {
            if (!up)
            {
                prevPoint = new Vector3(transform.position.x, pointOne.position.y, transform.position.z);
                nextPoint = new Vector3(transform.position.x, pointTwo.position.y, transform.position.z);
            }
            else
            {
                prevPoint = new Vector3(transform.position.x, pointTwo.position.y, transform.position.z);
                nextPoint = new Vector3(transform.position.x, pointOne.position.y, transform.position.z);
            }
        }

        fullTime = Vector3.Distance(prevPoint, nextPoint) / speed;
        timeLeft = Vector3.Distance(transform.position, nextPoint) / speed;
    }

    public void Horizontal()
    {
        if (vertical)
        {
            vertical = !vertical;
            NextPoint();
        }
    }

    public void Vertical()
    {
        if (!vertical)
        {
            vertical = !vertical;
            NextPoint();
        }
    }
}
