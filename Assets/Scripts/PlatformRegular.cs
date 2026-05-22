using UnityEngine;

public class PlatformRegular : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _moveHorizontal;
    [SerializeField] private bool _moveRight;
    [SerializeField] private bool _moveUp;
    [SerializeField] private Transform[] _horizontalPoints;
    [SerializeField] private Transform[] _verticalPoints;

    private int _horizontalIndex;
    private int _verticalIndex;
    private Vector3 _oldPosition;
    private Vector3 _newPosition;
    private float _timeLeft;
    private float _fullTime;

    private void Start()
    {
        NextPoint();
    }

    private void FixedUpdate()
    {
        _timeLeft -= Time.deltaTime;
        float percent = (_fullTime - _timeLeft) / _fullTime;
        transform.position = Vector3.Lerp(_oldPosition, _newPosition, percent);
        if (percent >= 1) NextPoint();
    }

    private void NextPoint()
    {
        if (_moveHorizontal) UpdateHorizontalMovement();
        else UpdateVerticalMovement();

        transform.position = _oldPosition;

        _fullTime = Vector3.Distance(_oldPosition, _newPosition) / _speed;
        _timeLeft = _fullTime;
    }

    private void UpdateHorizontalMovement()
    {
        _oldPosition = _horizontalPoints[_horizontalIndex].position;
        _oldPosition.y = transform.position.y;

        _horizontalIndex = GetNextIndex(_horizontalIndex, _horizontalPoints.Length, ref _moveRight);

        _newPosition = _horizontalPoints[_horizontalIndex].position;
        _newPosition.y = transform.position.y;
    }

    private void UpdateVerticalMovement()
    {
        _oldPosition = transform.position;
        _oldPosition.y = _verticalPoints[_verticalIndex].position.y;

        _verticalIndex = GetNextIndex(_verticalIndex, _verticalPoints.Length, ref _moveUp);

        _newPosition = transform.position;
        _newPosition.y = _verticalPoints[_verticalIndex].position.y;
    }

    private int GetNextIndex(int currentIndex, int length, ref bool direction)
    {
        if (direction)
        {
            if (currentIndex == length - 1)
            {
                direction = false;
                return currentIndex - 1;
            }
            return currentIndex + 1;
        }
        else
        {
            if (currentIndex == 0)
            {
                direction = true;
                return currentIndex + 1;
            }
            return currentIndex - 1;
        }
    }
}
