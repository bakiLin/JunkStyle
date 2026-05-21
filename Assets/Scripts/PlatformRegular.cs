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
    private float _percent;

    private void Start()
    {
        NextPoint();
    }

    private void FixedUpdate()
    {
        _timeLeft -= Time.deltaTime;
        _percent = (_fullTime - _timeLeft) / _fullTime;
        transform.position = Vector3.Lerp(_oldPosition, _newPosition, _percent);

        if (_percent >= 1)
        {
            NextPoint();
        }
    }

    private void NextPoint()
    {
        if (_moveHorizontal)
        {
            _oldPosition = _horizontalPoints[_horizontalIndex].position;
            _oldPosition.y = transform.position.y;

            if (_moveRight)
            {
                if (_horizontalIndex == _horizontalPoints.Length - 1)
                {
                    _moveRight = false;
                    _horizontalIndex--;
                }
                else
                {
                    _horizontalIndex++;
                }
            }
            else
            {
                if (_horizontalIndex == 0)
                {
                    _moveRight = true;
                    _horizontalIndex++;
                }
                else
                {
                    _horizontalIndex--;
                }
            }

            _newPosition = _horizontalPoints[_horizontalIndex].position;
            _newPosition.y = transform.position.y;
        }
        else
        {
            _oldPosition = transform.position;
            _oldPosition.y = _verticalPoints[_verticalIndex].position.y;

            if (_moveUp)
            {
                if (_verticalIndex == _verticalPoints.Length - 1)
                {
                    _moveUp = false;
                    _verticalIndex--;
                }
                else
                {
                    _verticalIndex++;
                }
            }
            else
            {
                if (_verticalIndex == 0)
                {
                    _moveUp = true;
                    _verticalIndex++;
                }
                else
                {
                    _verticalIndex--;
                }
            }

            _newPosition = transform.position;
            _newPosition.y = _verticalPoints[_verticalIndex].position.y;
        }

        _fullTime = Vector3.Distance(_oldPosition, _newPosition) / _speed;
        _timeLeft = Vector3.Distance(transform.position, _newPosition) / _speed;
    }
}
