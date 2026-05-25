using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using VContainer;

public class PlatformRegular : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _moveHorizontal;
    [SerializeField] private Transform[] _horizontalPoints;
    [SerializeField] private Transform[] _verticalPoints;

    private bool _moveRight;
    private bool _moveUp;
    private int _horizontalIndex;
    private int _verticalIndex;
    private Vector3 _oldPosition;
    private Vector3 _newPosition;
    private float _timeLeft;
    private float _fullTime;

    [Inject]
    private void Construct(ISubscriber<ScreenStateChangedMessage> screenStateChanged)
    {
        DisposableBag.Create(
            screenStateChanged.Subscribe(HandleScreenStateChangedMessage)
        ).AddTo(destroyCancellationToken);
    }

    private void Start()
    {
        NextPoint();
    }

    private void FixedUpdate()
    {
        _timeLeft -= Time.deltaTime;
        float percent = (_fullTime - _timeLeft) / _fullTime;
        transform.position = Vector3.Lerp(_oldPosition, _newPosition, percent);

        if (percent >= 1)
        {
            if (_moveHorizontal)
            {
                _horizontalIndex = GetNextIndex(
                    _horizontalIndex, _horizontalPoints.Length, ref _moveRight);
            }
            else
            {
                _verticalIndex = GetNextIndex(
                    _verticalIndex, _verticalPoints.Length, ref _moveUp);
            }

            NextPoint();
        }
    }

    private void HandleScreenStateChangedMessage(ScreenStateChangedMessage message)
    {
        if (message.PlatformName == gameObject.name)
        {
            _moveHorizontal = !_moveHorizontal;
            NextPoint();
        }
    }

    private void NextPoint()
    {
        _oldPosition = transform.position;

        if (_moveHorizontal)
        {
            _newPosition = _horizontalPoints[_horizontalIndex].position;
            _newPosition.y = transform.position.y;
        }
        else
        {
            _newPosition = transform.position;
            _newPosition.y = _verticalPoints[_verticalIndex].position.y;
        }

        _fullTime = Vector3.Distance(_oldPosition, _newPosition) / _speed;
        _timeLeft = _fullTime;
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
