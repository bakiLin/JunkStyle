using UnityEngine;
using DG.Tweening;

public class MovePlatform : MonoBehaviour
{
    [SerializeField]
    private Vector3[] movePoints;

    [SerializeField]
    private float speed;

    private Tween tween;
    private int pointCounter = 1;

    private void Start()
    {
        Move();
    }

    private void Move()
    {
        //if (pointCounter >= movePoints.Length) pointCounter = 0;
        //else pointCounter++;

        tween.Kill();
        tween = transform.DOMove(movePoints[pointCounter], speed)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                if (pointCounter >= movePoints.Length) pointCounter = 0;
                else pointCounter++;
            })
            .SetLoops(-1);
    }
}
